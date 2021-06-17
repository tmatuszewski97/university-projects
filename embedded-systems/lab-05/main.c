// CONFIG1H
#pragma config OSC = HSPLL      // Oscillator Selection bits (HS oscillator, PLL enabled (Clock Frequency = 4 x FOSC1))
#pragma config FCMEN = OFF      // Fail-Safe Clock Monitor Enable bit (Fail-Safe Clock Monitor disabled)
#pragma config IESO = OFF       // Internal/External Oscillator Switchover bit (Oscillator Switchover mode disabled)

// CONFIG2L
#pragma config PWRT = ON        // Power-up Timer Enable bit (PWRT enabled)
#pragma config BOREN = OFF      // Brown-out Reset Enable bits (Brown-out Reset disabled in hardware and software)
#pragma config BORV = 3         // Brown Out Reset Voltage bits (Minimum setting)

// CONFIG2H
#pragma config WDT = OFF        // Watchdog Timer Enable bit (WDT disabled (control is placed on the SWDTEN bit))
#pragma config WDTPS = 32768    // Watchdog Timer Postscale Select bits (1:32768)

// CONFIG3H
#pragma config CCP2MX = PORTC   // CCP2 MUX bit (CCP2 input/output is multiplexed with RC1)
#pragma config PBADEN = OFF     // PORTB A/D Enable bit (PORTB<4:0> pins are configured as digital I/O on Reset)
#pragma config LPT1OSC = OFF    // Low-Power Timer1 Oscillator Enable bit (Timer1 configured for higher power operation)
#pragma config MCLRE = ON       // MCLR Pin Enable bit (MCLR pin enabled; RE3 input pin disabled)

// CONFIG4L
#pragma config STVREN = OFF     // Stack Full/Underflow Reset Enable bit (Stack full/underflow will not cause Reset)
#pragma config LVP = OFF        // Single-Supply ICSP Enable bit (Single-Supply ICSP disabled)
#pragma config XINST = OFF      // Extended Instruction Set Enable bit (Instruction set extension and Indexed Addressing mode disabled (Legacy mode))

// CONFIG5L
#pragma config CP0 = OFF        // Code Protection bit (Block 0 (000800-003FFFh) not code-protected)
#pragma config CP1 = OFF        // Code Protection bit (Block 1 (004000-007FFFh) not code-protected)
#pragma config CP2 = OFF        // Code Protection bit (Block 2 (008000-00BFFFh) not code-protected)
#pragma config CP3 = OFF        // Code Protection bit (Block 3 (00C000-00FFFFh) not code-protected)

// CONFIG5H
#pragma config CPB = OFF        // Boot Block Code Protection bit (Boot block (000000-0007FFh) not code-protected)
#pragma config CPD = OFF        // Data EEPROM Code Protection bit (Data EEPROM not code-protected)

// CONFIG6L
#pragma config WRT0 = OFF       // Write Protection bit (Block 0 (000800-003FFFh) not write-protected)
#pragma config WRT1 = OFF       // Write Protection bit (Block 1 (004000-007FFFh) not write-protected)
#pragma config WRT2 = OFF       // Write Protection bit (Block 2 (008000-00BFFFh) not write-protected)
#pragma config WRT3 = OFF       // Write Protection bit (Block 3 (00C000-00FFFFh) not write-protected)

// CONFIG6H
#pragma config WRTC = OFF       // Configuration Register Write Protection bit (Configuration registers (300000-3000FFh) not write-protected)
#pragma config WRTB = OFF       // Boot Block Write Protection bit (Boot Block (000000-0007FFh) not write-protected)
#pragma config WRTD = OFF       // Data EEPROM Write Protection bit (Data EEPROM not write-protected)

// CONFIG7L
#pragma config EBTR0 = OFF      // Table Read Protection bit (Block 0 (000800-003FFFh) not protected from table reads executed in other blocks)
#pragma config EBTR1 = OFF      // Table Read Protection bit (Block 1 (004000-007FFFh) not protected from table reads executed in other blocks)
#pragma config EBTR2 = OFF      // Table Read Protection bit (Block 2 (008000-00BFFFh) not protected from table reads executed in other blocks)
#pragma config EBTR3 = OFF      // Table Read Protection bit (Block 3 (00C000-00FFFFh) not protected from table reads executed in other blocks)

// CONFIG7H
#pragma config EBTRB = OFF

#include <xc.h>

#define LENA  PORTEbits.RE1
#define LDAT  PORTEbits.RE2
#define LPORT PORTD

#define L_ON	0x0F
#define L_OFF	0x08
#define L_CLR	0x01
#define L_L1	0x80
#define L_L2	0xC0
#define L_CR	0x0F		
#define L_NCR	0x0C	

#define L_CFG   0x38

void delay(unsigned int ms) {
    unsigned int i;
    unsigned char j;

    for (i = 0; i < ms; i++) {

        for (j = 0; j < 200; j++) {
            Nop();
            Nop();
            Nop();
            Nop();
            Nop();
        }
    }
}

void lcd_wr(unsigned char val) {
    LPORT = val;
}

void lcd_cmd(unsigned char val) {
    LENA = 1;
    lcd_wr(val);
    LDAT = 0;
    //delay(3);
    LENA = 0;
    //delay(3);
    LENA = 1;
}

void lcd_dat(unsigned char val) {
    LENA = 1;
    lcd_wr(val);
    LDAT = 1;
    //delay(3);
    LENA = 0;
    //delay(3);
    LENA = 1;
}

void lcd_init(void) {
    LENA = 0;
    LDAT = 0;
    delay(20);
    LENA = 1;

    lcd_cmd(L_CFG);
    delay(5);
    lcd_cmd(L_CFG);
    delay(1);
    lcd_cmd(L_CFG); //configura
    lcd_cmd(L_OFF);
    lcd_cmd(L_ON); //liga
    lcd_cmd(L_CLR); //limpa
    lcd_cmd(L_CFG); //configura
    lcd_cmd(L_L1);
}

void lcd_str(const char* str) {
    unsigned char i = 0;

    while (str[i] != 0) {
        lcd_dat(str[i]);
        i++;
    }
}

void lcd_int(int val) {
    lcd_dat(val);
}

/* Funkcja odczytu z okreslenego kanalu (wartosci przycisku) */
unsigned int adc(unsigned char kanal)
{
    switch(kanal)
    {
        case 0: ADCON0=0x01; break; //P1
        case 1: ADCON0=0x05; break; //P2
        case 2: ADCON0=0x09; break; 
    }
    
    ADCON0bits.GO=1;
    while(ADCON0bits.GO == 1);

   return ((((unsigned int)ADRESH)<<2)|(ADRESL>>6));
}

/* Funkcja zwracajaca 1/3/5 w zaleznosci od wartosci podanej w argumencie.
 * Ma swój uzytek wtedy gdy wybieramy czas trwania partii szachowej */
unsigned int countMinutes(unsigned int adc)
{
    /* Dzielimy zakres potencjometru na 3 progi */
    double step = 1024/3;
    /* Deklarujemy zmienna ktora zwrocimy */
    unsigned int time;
    /* Jesli zakres potencjometru miedzy 0 a pierwszym progiem */
    if (adc <= step)
        /* Zmienna wynikowa = 1 */
        time = 1;
    /* Jesli zakres potencjometru miedzy pierwszym a drugim progiem */
    else if (adc > step && adc <= (step * 2))
        /* Zmienna wynikowa = 3 */
        time = 3;
    /* W pozostalych przypadkach */
    else
        /* Zmienna wynikowa = 5 */
        time = 5;
    /* Zwracamy zmienna wynikowa */
    return time;
}

/* Funkcja pomoca przy wyswietlaniu aktualnego czasu dla obu graczy */
void lcd_showTime(const char* text1, const char* text2, 
        unsigned int minutesUnits1, unsigned int minutesUnits2, 
        unsigned int secondsTens1, unsigned int secondsTens2,
        unsigned int secondsUnits1, unsigned int secondsUnits2) {
    lcd_cmd(L_CLR); //Czyszczenie wyswietlacza
    /* Pierwszy gracz */
    lcd_cmd(L_L1);
    /* Wyswietlamy napisy - Gracz 1 i Gracz 2 w naszym przypadku */
    lcd_str(text1);
    lcd_str(text2);
    
    /* Dla kazdego gracza wyswietlamy czas w ponizszym formacie w linii drugiej 
                     mm1:ss     mm:ss
     gdzie pierwsze (od lewej) m=0 (bo nie mamy wi?kszego dost?pnego 
     czasu do ustawienia), drugie m=minutesUnits, pierwsze s=secondsTens, 
     * drugie s=secondsUnits. I tak samo dla drugiego gracza obok */
    lcd_cmd(L_L2);
    lcd_str(" ");
    lcd_int(48);
    lcd_int(minutesUnits1);
    lcd_str(":");
    lcd_int(secondsTens1);
    lcd_int(secondsUnits1);
    
    lcd_str("    ");
    lcd_int(48);
    lcd_int(minutesUnits2);
    lcd_str(":");
    lcd_int(secondsTens2);
    lcd_int(secondsUnits2);
    lcd_str(" ");
    
    delay(1000);
}

/* Funkcja przydatna przy zamianie wartosci dostepnych czasow (1/3/5) na 
 liczbe zdatna do wyswietlenia na ekranie urzadzenia */
/* Jako argument funkcji podajemy wartosc ktora konwertujemy */
int timeToLCDchar(int value)
{
    /* Definiujemy zmienna wynikowa funkcji */
    int result;
    /* W zaleznosci od zmiennej z argumentu wchodzimy do odpowiedniego case'a */
    switch (value)
    {
        case 1:
            /* Jesli argument funkcji == 1, zmienna wynikowa = 1 (na ekranie)*/
            result = 49;
            break;
        case 3:
            /* Jesli argument funkcji == 3, zmienna wynikowa = 3 (na ekranie)*/
            result = 51;
            break;
        case 5:
            /* Jesli argument funkcji == 5, zmienna wynikowa = 5 (na ekranie)*/
            result = 53;
            break;
    }
    /* Zwracamy zmienna wynikowa */
    return result;
            
}

/* Funkcja sluzaca do resetowania zmiennych obu graczy, do ich stanu sprzed 
 * rozpoczecia gry */
void resetValues(int mU1, int sT1, int sU1, 
        int mU2, int sT2, int sU2, int gS, int sC, int tP1, int tP2)
{
    /* 48 odpowiada na ekranie zerom */
    mU1 = 48;
    sT1 = 48;
    sU1 = 48;
    
    mU2 = 48;
    sT2 = 48;
    sU2 = 48;
    
    gS = 0;
    sC = 0;
    tP1 = 0;
    tP2 = 0;
}

void main(void) {

    //Inicjalizacja konwertera analogowo cyfrowego
    ADCON0 = 0x01;
    ADCON1 = 0x0B;
    ADCON2 = 0x01;

    TRISA = 0xC3;
    TRISB = 0x3F;
    TRISC = 0x01;
    TRISD = 0x00;
    TRISE = 0x00;

    /* p2value - zmienna odczytujaca dane z potencjometru P2 */
    unsigned int p2value;
    /* time - zmienna przetrzymujaca ustawiona wartosc czasu partii */
    int time = 0;
    
    /* Pierwszy gracz */
    /* Zmienna minutesUnits to cyfra jednosci w minutach */
    int minutesUnits1 = 48;
    /* Zmienna secondsTens to cyfra dziesiatek w sekundach */
    int secondsTens1 = 48;
    /* Zmienna secondsUnits to cyfra jednosci w sekundach */
    int secondsUnits1 = 48;
    
    /* Drugi gracz - nazwy zmiennych analogicznie jak wyzej, 
     * tylko dla drugiego gracza */
    int minutesUnits2 = 48;
    int secondsTens2 = 48;
    int secondsUnits2 = 48;
    
    /* Zmienna okreslajaca czy gra sie juz rozpoczela, tj. 
     * czas zostal wybrany */
    int gameStarted = 0;
    /* Zmienna okreslajaca czy ktorys z graczy wcisnal juz swoj przycisk, 
     * czyli rozpoczal gre*/
    int startedClick = 0;
    /* Zmienne odpowiadajace za to, do kogo nalezy aktualny ruch */
    int turnP1 = 0;
    int turnP2 = 0;
    
    lcd_init(); //Inicjalizacja wyswietlacza
    lcd_cmd(L_CLR); //Czyszczenie wyswietlacza

    while (1) {
        /* Czyscimy ekran */
        lcd_cmd(L_CLR);
        lcd_cmd(L_L1); //Ustawienie karetki w pierwszej linii
        /* Odczytujemy wartosc z potencjometru P2 */
        p2value=((unsigned int)adc(1));
        /* W zaleznosci od ustawienia potencjometru time przyjmuje wartosc 
         * 1/3/5 */
        time = countMinutes(p2value);
        /* Dopoki time nie zostalo okreslone i gra sie nie 
         * rozpoczela wykonujemy ten blok instrukcji*/
        if (time != 0 && gameStarted==0)
        {
            /* Czyscimy ekran */
            lcd_cmd(L_CLR);
            lcd_cmd(L_L1); //Ustawienie karetki w pierwszej linii
            /* Wyswietlamy napis */
            lcd_str(" Ustaw czas gry:");
            lcd_cmd(L_L2); //Przejscie do drugiej linii
            /* Wyswietlamy napis*/
            lcd_str("    ");
            /* W zaleznosci od wartosci time (1/3/5) wyswietlamy na 
             * ekranie 1/3/5 i dopisujemy odpowiednia koncowke */
            switch(time)
            {
                case 1:
                    lcd_int(49);
                    lcd_str(" minuta    ");
                    break;
                case 3:
                    lcd_int(51);
                    lcd_str(" minuty    ");
                    break;
                case 5:
                    lcd_int(53);
                    lcd_str(" minut     ");
                    break;
            }
            /* Robimy sekundowe opoznienie */
            delay(1000);
        }
        
        /* Jesli gracz pierwszy wcisnie RB3 lub jest aktualnie tura gracza2 oraz 
         * nie skonczyl sie jego czas, wykonujemy ten blok 
         * instrukcji */
        if ((PORTBbits.RB3 == 0 || turnP2 == 1) && secondsUnits1!=-1)
        {
            /* Jesli gra sie jeszcze nie rozpoczela szybko wykonujemy ten 
             * blok instrukcji*/
            if (startedClick == 0)
            {
                /* Okreslamy ze gra sie rozpoczela przypisujac 1 do zmiennej 
                 * gameStarted */
                gameStarted = 1;
                /* Okreslamy ze gracz juz wcisnal klawisz rozpoczynajacy 
                 * rozgrywke */
                startedClick = 1;
                /* Do zmiennej przechowujacej minuty (jednosci) obu graczy 
                 * przypisujemy odpowiednia wartosc int im odpowiadajaca, np. 
                 * dla 3 minut przypisane zostanie 51, gdyz odpowiada 
                 * to na ekranie wartosci 3*/
                minutesUnits1 = timeToLCDchar(time);
                minutesUnits2 = timeToLCDchar(time);
            }
            
            /* Dopoki wartosc sekund (jednosci) jest wieksze od -1 wykonujemy 
             * ten blok instrukcji */
            while (secondsUnits2 > -1)
            {
                /* Okreslamy ze nastepna tura bedzie nalezec do przeciwnego gracza */
                turnP1 = 1;
                /* Okreslamy ze tura tego gracza bedzie zakonczona */
                turnP2 = 0;
                /* Czyscimy ekran */
                lcd_cmd(L_CLR);
                /* Przechodzimy do pierwszej linii ekranu */
                lcd_cmd(L_L1);
                /* Wyswietlamy czasy dla obu graczy */
                lcd_showTime("Gracz 1  ", "Gracz 2", minutesUnits1, minutesUnits2, 
                    secondsTens1, secondsTens2, secondsUnits1, secondsUnits2);
                /* W przypadku gdy gracz przeciwny, w tym przypadku gracz2 
                 * wcisnie przycisk, to jego czas przestaje uplywac */
                if (PORTBbits.RB5 == 0) {
                    break;
                }
                
                /* W przeciwnym razie czas gracza2 up?ywa */
                /* Jesli jednosci sekund sa rowne 0, to pozyczamy wartosci od
                 * dziesiatek sekund */
                else if (secondsUnits2 == 48) {
                    /* Jesli dziesiatki sekund tez sa rowne 0, to pozyczamy 
                     * wartosci od jednosci minut */
                    if (secondsTens2 == 48) {
                        /* Jesli jednosci minut tez sa rowne 0, to jednosci 
                         * sekund przyjmuja wartosc -1 (symboliczna wartosc 
                         * powodujaca wyjscie z petli while) */
                        if (minutesUnits2 == 48) {
                            secondsUnits2 = -1;
                        }
                        else {
                            /* Pozyczenie wartosci z jednosci minut */
                            secondsTens2 = 53;
                            secondsUnits2 = 57;
                            minutesUnits2--;
                        }
                    }
                    else {
                        /* Pozyczenie wartosci z dziesiatek sekund */
                        secondsUnits2 = 57;
                        secondsTens2--;
                    }
                }
                
                else {
                    /* Odejmowanie z kazda sekunda kolejnej sekundy na 
                     * ekranie */
                    secondsUnits2--;
                }
            }
        }
        
        /* To wszystko co w bloku (else if) wyzej, tylko odwrocone w kontekscie
         * uplywu czasu pierwszego gracza, oraz wciskaniu przycisku RB5 przez 
         * drugiego gracza. */
        else if ((PORTBbits.RB5 == 0 || turnP1 == 1) && secondsUnits2!=-1)
        {
            if (startedClick == 0)
            {
                gameStarted = 1;
                startedClick = 1;
                minutesUnits1 = timeToLCDchar(time);
                minutesUnits2 = timeToLCDchar(time);
            }
            while (secondsUnits1 > -1)
            {
                turnP2 = 1;
                turnP1 = 0;
                lcd_cmd(L_CLR);
                lcd_cmd(L_L1);
                lcd_showTime("Gracz 1  ", "Gracz 2", minutesUnits1, minutesUnits2, 
                    secondsTens1, secondsTens2, secondsUnits1, secondsUnits2);
                if (PORTBbits.RB3 == 0) {
                    break;
                }
                
                else if (secondsUnits1 == 48) {
                    if (secondsTens1 == 48) {
                        if (minutesUnits1 == 48) {
                            secondsUnits1 = -1;
                        }
                        else {
                            secondsTens1 = 53;
                            secondsUnits1 = 57;
                            minutesUnits1--;
                        }
                    }
                    else {
                        secondsUnits1 = 57;
                        secondsTens1--;
                    }
                }
                
                else {
                    secondsUnits1--;
                }
            }
        }
        
        /* W tym miejscu sprawdzamy czy czas ktorego z graczy dobiegl konca, 
         * jesli tak wchodzimy do bloku instrukcji */
        else if (secondsUnits1 == -1 || secondsUnits2 == -1 )
        {
            /* Czyscimy ekran */
            lcd_cmd(L_CLR);
            lcd_cmd(L_L1); //Ustawienie karetki w pierwszej linii
            /* Wyswietlamy napis */
            lcd_str("KONIEC CZASU!!! ");
            /* Jesli czas dobiegl konca w trakcie tury gracza1, to 
             * informujemy o jego przegranej */
            if (secondsUnits1 == -1)
            {
                lcd_cmd(L_L2); //Przejscie do drugiej linii
                lcd_str("PRZEGRAL GRACZ1 ");
            }
            else if (secondsUnits2 == -1)
            {
            /* Jesli czas dobiegl konca w trakcie tury gracza2, to 
             * informujemy o jego przegranej */
                lcd_cmd(L_L2); //Przejscie do drugiej linii
                lcd_str("PRZEGRAL GRACZ2 ");
            }
         
            /* Resetujemy wszystkie wartosci do stanu sprzed wyboru czasu 
             * partii, i mozna zaczynac od poczatku */
            resetValues(minutesUnits1, secondsTens1, secondsUnits1, 
                    minutesUnits2, secondsTens2, secondsUnits2, gameStarted, 
                    startedClick, turnP1, turnP2);
            /* Maly delay zeby uzytkownik zdazyl odczytac kto przegral */
            delay(3000);
            break;
        }
        
    }
    
    return;
}
