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

/* Funkcja pokazujaca aktualny czas gotowania, przyjmuje jako argumenty
 wyswietlany tekst, minuty - liczba dziesiatek, minuty - liczba jednosci, 
 * sekundy - liczba dziesiatek, sekundy - liczba jednosci */
void lcd_showTime(const char* text, unsigned int minutesTens,
        unsigned int minutesUnits, unsigned int secondsTens,
        unsigned int secondsUnits) {
    /* Wyswietlenie naszego tekstu */
    lcd_str(text);
    lcd_cmd(L_L2); //Przejscie do drugiej linii
    /* Wyswietlenie przerwy (zmiana kosmetyczna) */
    lcd_str("      ");
    /* Wyswietlenie minut (cz??ci dziesi?tnych) */
    lcd_int(minutesTens);
     /* Wyswietlenie minut (jedno?ci) */
    lcd_int(minutesUnits);
    lcd_str(":");
     /* Wyswietlenie sekund (cz??ci dziesi?tnych) */
    lcd_int(secondsTens);
    /* Wyswietlenie sekund (jedno?ci) */
    lcd_int(secondsUnits);
    /* Wyswietlenie przerwy (zmiana kosmetyczna) */
    lcd_str("     ");
    /* Ma?e opó?nienie na czas wy?wietlenia napisu */
    delay(1000);
}

/* Zmienna powerCounter wskazuje na aktualnie ustawiona moc */
unsigned int powerCounter = 1;

/* Zmienna minutesUnits to cyfra jednosci w minutach */
int minutesUnits = 48;
/* Zmienna minutesTens to cyfra dziesiatek w minutach */
int minutesTens = 48;

/* Zmienna secondsUnits to cyfra jednosci w sekundach */
int secondsUnits = 48;
/* Zmienna secondsTens to cyfra dziesiatek w sekundach */
int secondsTens = 48;

/* Zmienne ponizej wskazuja czy w poprzednim rozkazie zostal wcisniety 
 * okreslony w nazwie zmiennej przycisk. Wykorzystujemy to w momencie stanu 
 * wstrzymania */
int RB4clicked = 0;
int RB3clicked = 0;
int RB1clicked = 0;

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

    lcd_init(); //Inicjalizacja wyswietlacza
    lcd_cmd(L_CLR); //Czyszczenie wyswietlacza

    menu: while (1) {
        delay(1000);
        lcd_cmd(L_CLR);
        lcd_cmd(L_L1); //Ustawienie karetki w pierwszej linii
        lcd_str("  Podaj rozkaz  ");

        /* Jesli wcisniety zostal przycisk RB5 */
        if (PORTBbits.RB5 == 0) {
            /* Czyscimy ekran */
            lcd_cmd(L_CLR);
            lcd_cmd(L_L1); //Ustawienie karetki w pierwszej linii
            /* Wyswietlamy napist */
            lcd_str(" Wybrana moc:  ");
            lcd_cmd(L_L2); //Przejscie do drugiej linii
            /* W zaleznosci od zmiennej powerCounter wybieramy okreslony case */
            switch (powerCounter) {
                case 1:
                {
                    lcd_str("     800W       ");
                    /* Kazdy case z wyjatkiem 4 inkrementuje zmienna 
                     * powerCounter */
                    powerCounter++;
                    break;
                }

                case 2:
                {
                    lcd_str("     600W       ");
                    powerCounter++;
                    break;
                }

                case 3:
                {
                    lcd_str("     350W       ");
                    powerCounter++;
                    break;
                }

                case 4:
                {
                    lcd_str("     200W       ");
                    /* W ostatnim z case'ow zmienna powerCounter jest 
                     * zmieniana na 1 */
                    powerCounter = 1;
                    break;
                }
            }
            delay(1000);
        }
        /* Jesli wcisniety zostal przycisk RB4 lub zostal wcisniety 
         * podczas stanu wstrzymania wykonujemy ten blok instrukcji */
        else if (PORTBbits.RB4 == 0 || RB4clicked == 1) {
            /* Resetujemy ostatni rozkaz */
            RB4clicked = 0;
            /* Inkrementujemy licznik minut o 1 minute */
            minutesUnits++;
            /* W przypadku gdy cyfra jednosci minut wynosi 9+1 czyli 
             * jest znakiem : */
            if (minutesUnits == 58) {
                /* Ustawiamy cyfre jednosci minut na 0 */
                minutesUnits = 48;
                /* Inkrementujemy cyfre dziesiatek minut o 1 */
                minutesTens++;
            }

            /* Czyscimy ekran */
            lcd_cmd(L_CLR);
            lcd_cmd(L_L1); //Ustawienie karetki w pierwszej linii
            /* Wyswietlamy aktualny czas */
            lcd_showTime("  Wybrany czas: ", minutesTens, minutesUnits,
                    secondsTens, secondsUnits);
        }
        /* Jesli wcisniety zostal przycisk RB3 lub zostal wcisniety 
         * podczas stanu wstrzymania wykonujemy ten blok instrukcji */
        else if (PORTBbits.RB3 == 0 || RB3clicked == 1) {
            /* Resetujemy ostatni rozkaz */
            RB3clicked = 0;
            /* Inkrementujemy cyfre dziesiatek sekund o 1 */
            secondsTens++;
            /* Jesli cyfra dziesiatek sekund jest rowna 6 i cyfra 
             * jednosci minut jest rowna 9 to wykonujemy ten blok instrukcji */
            if (secondsTens == 54 && minutesUnits == 57) {
                /* Cyfra dziesiatek sekund ustawiana jest na 0 */
                secondsTens = 48;
                /* Cyfra jednosci minut ustawiana jest na 0 */
                minutesUnits = 48;
                /* Inkrementujemy cyfre dziesiatek minut o 1 */
                minutesTens++;
            }
            /* Jesli cyfra dziesiatek sekund jest rowna 6 */
            else if (secondsTens == 54) {
                /* Cyfra dziesiatek sekund ustawiana jest na 0 */
                secondsTens = 48;
                /* Cyfra jednosci minut inkrementowana jest o 1 */
                minutesUnits++;
            }

            /* Czyscimy ekran */
            lcd_cmd(L_CLR);
            lcd_cmd(L_L1); //Ustawienie karetki w pierwszej linii
            /* Wyswietlamy aktualny czas */
            lcd_showTime("  Wybrany czas: ", minutesTens, minutesUnits,
                    secondsTens, secondsUnits);
        }
        /* Jesli wcisniety zostal przycisk RB2 wykonujemy ten blok instrukcji */
        else if (PORTBbits.RB2 == 0) {
            /* Dopoki cyfra jednostek sekund jest wieksza od -1 wchodzimy do 
             * petli while */
            again: while (secondsUnits > -1) {
                /* Czyscimy ekran */
                lcd_cmd(L_CLR);
                lcd_cmd(L_L1); //Ustawienie karetki w pierwszej linii
                /* Wyswietlamy pozostaly czas */
                lcd_showTime("   Pozostalo:   ", minutesTens,
                        minutesUnits, secondsTens, secondsUnits);
                /* Jesli wcisniety zostal ponownie przycisk RB2 przerywamy 
                 * petle*/
                if (PORTBbits.RB2 == 0) {
                    break;
                }
                
                /* Ponizej jest cala magia mijania czasu gotowania */
                
                /* Jesli cyfra jednosci sekund jest rowna 0 */
                else if (secondsUnits == 48) {
                    /* Jesli cyfra dziesiatek sekund jest rowna 0 */
                    if (secondsTens == 48) {
                        /* Jesli cyfra jednosci minut jest rowna 0 */
                        if (minutesUnits == 48) {
                            /* Jesli cyfra dziesiatek minut jest rowna 0 */
                            if (minutesTens == 48) {
                                /* Chwilowo ustawiamy cyfre jednostek sekund na 
                                 * -1 aby opuscic petle i przejsc do okreslonego 
                                 * if'a */
                                secondsUnits = -1;
                            }
                            /* Pozyczamy cyfre jednosci minut od cyfry 
                             * dziesiatek minut, czyli robimy (x-1)9min 59sek*/
                            else {
                                secondsUnits = 57;
                                secondsTens = 53;
                                minutesUnits = 57;
                                minutesTens--;
                            }
                        }
                        /* Pozyczamy cyfre dziesiatek sekund od cyfry 
                         * jednosci minut, czyli z minuty robimy 59 sekund */
                        else {
                            secondsTens = 53;
                            secondsUnits = 57;
                            minutesUnits--;
                        }
                    }
                    /* Pozyczamy cyfre jednosci sekund od cyfry dziesiatek */
                    else {
                        secondsUnits = 57;
                        secondsTens--;
                    }
                }
                /* Poki cyfra jednosci sekund jest wieksza od 0, 
                 * zmniejszamy ja o 1 z kazda sekunda */
                else {
                    secondsUnits--;
                }
            }
            
            /* Jesli cyfra jednosci sekund jest rowna -1, czyli czas gotowania 
             * dobiegl konca, wykonujemy ten blok instrukcji */
            if (secondsUnits == -1)
            {
                /* Przywracamy cyfre jednosci sekund na 0 */
                secondsUnits = 48;
                /* Czyscimy ekran */
                lcd_cmd(L_CLR);
                lcd_cmd(L_L1); //Ustawienie karetki w pierwszej linii
                /* Wyswietlamy napis */
                lcd_str("   KONIEC !!!   ");
                delay(3000);
            }
            
            /* Jesli wcisniety zostal przycisk RB2, czyli doszlo do przerwania 
             * odliczania czasu, wykonujemy ten blok instrukcji */
            else
            {
                while(1)
                {
                    /* Czyscimy ekran */
                    lcd_cmd(L_CLR);
                    lcd_cmd(L_L1); //Ustawienie karetki w pierwszej linii
                    lcd_str("Stan wstrzymania"); //napis
                    lcd_cmd(L_L2); //Przejscie do drugiej linii
                    /* Wyswietlamy czas na ktorym ustal zegar */
                    lcd_showTime("", minutesTens, minutesUnits,
                    secondsTens, secondsUnits);
                    delay(1000);
                    /* Jesli wcisniety zostal przycisk RB2 to wracamy do 
                     * odliczania czasu gotowania */
                    if (PORTBbits.RB2 == 0)
                    {
                        goto again;
                    }
                    /* Jesli wcisniety zostal ktorys z przyciskow:
                     * RB4/RB3/RB1 to ustawiamy ostatni rozkaz na 
                     * odpowiednia zmienna i przechodzimy do glownej petli, 
                     * ktora od razu wykona blok instrukcji spod okreslonego w 
                     * warunku przycisku */
                    
                    else if (PORTBbits.RB4 == 0)
                    {
                        RB4clicked = 1;
                        break;
                    }
                    
                    else if (PORTBbits.RB3 == 0)
                    {
                        RB3clicked = 1;
                        break;
                    }
                    
                    else if (PORTBbits.RB1 == 0)
                    {
                        RB1clicked = 1;
                        break;
                    }
                }
            }
        }
        /* Jesli wcisniety zostal przycisk RB1 lub zostal wcisniety 
         * podczas stanu wstrzymania wykonujemy ten blok instrukcji */
        else if (PORTBbits.RB1 == 0 || RB1clicked == 1) {
            /* Resetujemy ostatni rozkaz */
            RB1clicked = 0;
            /* Czyscimy ekran */
            lcd_cmd(L_CLR);
            lcd_cmd(L_L1); //Ustawienie karetki w pierwszej linii
            /* Wyswietlamy napis */
            lcd_str(" Reset ustawien ");
            delay(1000);
            /* Resetujemy zmienna reprezentujaca moc mikrofali - ustawiamy 
             * na 1 */
            powerCounter = 1;
            /* Resetujemy czas, ustawiamy na 00min 00sek*/
            minutesUnits = 48;
            minutesTens = 48;
            secondsUnits = 48;
            secondsTens = 48;
        }
    }
    
    return;
}
