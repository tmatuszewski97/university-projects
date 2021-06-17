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

void delay(unsigned int ms)
{
    unsigned int i;
    unsigned char j;
    
 for (i =0; i< ms; i++)
 {
 
  for (j =0 ; j < 200; j++)
   {
      Nop();
      Nop();
      Nop();
      Nop();
      Nop();
   }
 }
}

unsigned char IntToBCD(unsigned char input)
{
    return ((input / 10) << 4) | (input % 10);
}

/* Funkcja wyszukujaca dany bit w liczbie binarnej, zwraca unsigned char, oraz przyjmuje
jako argumenty nasza liczbe binarna oraz numer "n" bitu ktorego szukamy */
unsigned char FindBit(unsigned char input, int n)
{
    /* Wejsciowa liczba binarna jest przesuwana o "n-1" pozycji a nastepnie 
     * za pomoca koniunkcji z 1 wyluskana i zwrócona */
    return (input >> (n-1)) & 1;
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

/* Zakres adc to 0 - 1024, wiec znajdujemy 5 progów */
double countDelay (unsigned int adc)
{
    /* Zmienna step przetrzymuje wyliczony próg */
    double step = 1024/5;
    /* Zmienna result to zwracany wynik */
    double result;
    /* Jesli wartosc z przycisku mniejsza niz pierwszy prog, to wynik jest pierwsza wartoscia progowa*/
    if (adc <= step)
        result = step;
    /* W dalszych krokach wartosc progowa jest zwiekszana o kolejny prog */
    else if (adc > step && adc <= (step * 2))
        result = (step * 2);
    else if (adc > (step * 2) && adc <= (step * 3))
        result = (step * 3);
    else if (adc > (step * 3) && adc <= (step * 4))
        result = (step * 4);
    else
        result = (step * 5);
    /* Na koniec zwracamy wynik */
    return result;
}

void main(void) {
    
    //Inicjalizacja konwertera analogowo cyfrowego
    ADCON0=0x01;
    ADCON1=0x0B;
    ADCON2=0x01;
    
    TRISA=0xC3;
    TRISB=0x3F;   
    TRISC=0x01;
    TRISD=0x00;
    TRISE=0x00;
    
    unsigned char display = 0;
    unsigned int tmp = 0;
    double time = 0;
    
    /* Zmienna potrzebna do sterowania:
    progCounter - licznik aktualnie uruchomionego podprogramu */
    unsigned int progCounter = 1;
    
    /* Zmienna potrzebna do podprogramu nr 1 - 2x4 bitowy licznik BCD zliczajacy w góre:
    bcdCounter - odpowiada za dodawanie/odejmowanie wartosci 1 w kolejnych wywolaniach */
    unsigned char bcdCounter=0;
    
    /* Zmienne potrzebne do podprogramu nr 2 - generator liczb pseudolosowych:
    start - odpowiada za wartosc startowa czyli 00000001, na niej dokonywane jest tez przesuniecie w prawo
    first, second, fifth, sixth - zmienne zdefiniowane w celu przetrzymywanie wartosci z okreslonych bitow liczby (numeracja rzecz jasna od prawej do lewej) */
    unsigned char start = 1;
    unsigned char first, second, fifth, sixth, xorResult;
    
    while(1)
    {
        /* Wyswietlamy zmienna display na diodach */
        PORTD = display;
        /* Zmienna tmp przyjmuje wartosc z przycisku 1 - P2*/
        tmp=((unsigned int)adc(1));
        /* Korzystajac z funkcji countDelay wyliczamy czas w zaleznosci od zmiennej tmp */
        time = countDelay(tmp);
        /* Wywolujemy funkcje opozniajaca z naszym parametrem time */
        delay(time); //Opoznienie
        
        //Symulator nie jest doskonaly - drobne spowolnienie odczytu przycisków
        unsigned int i = 6000;
        while(PORTBbits.RB4 && PORTBbits.RB3 && i > 0)
        {
            i--;
        }
        
        /* Jesli wcisniemy przycisk RB3 - przechodzimy do nastepnego podprogramu 
        (inkrementujemy zmienna progCounter) */
        if(PORTBbits.RB3 == 0)
        {
            progCounter++;
        }
        
        /* Jesli wcisniemy przycisk RB4 - przechodzimy do poprzedniego podprogramu 
        (dekrementujemy zmienna progCounter) */
        else if(PORTBbits.RB4 == 0)
        {
            progCounter--;
        }
        
        /* Jesli zmienna progCounter wyszla poza zakres dostepnych programów, przywracamy
        ja na odpowiednia wartosc poczatku/konca zakresu */
        if (progCounter == 3)
        {
            progCounter = 1;
        }
        else if (progCounter == 0)
        {
            progCounter = 2;
        }
        
        /* W tym bloku dzieje sie wszystko to, co ma miejsce gdy nic nie naciskamy */
        else
        {
            /* Kazdy case - to osobny podprogram */
            switch(progCounter)
            {
                /* 2x4 bitowy licznik BCD zliczajacy w góre*/
                case 1:
                    display = IntToBCD(bcdCounter);
                    bcdCounter++;
                    if (bcdCounter > 99)
                    {
                        bcdCounter = 0;
                    }
                    break;
                /* Generator liczb pseudolosowych */
                case 2:
                    /* Zmienna wywolywana na ekranie - display z kazdym wywolaniem ma przypisana wartosc zmiennej start*/
                    display = start;
                    /* Zmienna start jest przesuwana w prawo o jeden bit */
                    start >>= 1;
                    /* Do kolejnych zmiennych przypisujemy okreslone bity zmiennej display */
                    first = FindBit(display, 1);
                    second = FindBit(display, 2);
                    fifth = FindBit(display, 5);
                    sixth = FindBit(display, 6);
                    /* Szukamy wartosci skrajnie lewej w nowo-wygenerowanej liczbie - XORujemy wiec wartosci pobrane z poszczegolnych bitow */
                    xorResult = ((first ^ second) ^ fifth) ^ sixth;
                    /* Zmienna wynikowa wspomnianego XORa przesuwamy o 5 w lewo */
                    xorResult <<= 5;
                    /* Pozostaje juz tylko dopisac ja na poczatek zmiennej start przechowujacej stan po przesunieciu, dokonujemy tego za pomoca operatora | czyli alternatywy bitowej */
                    start = xorResult | start;
                    break;
            }
        }
    }
    
    
    return;
}
