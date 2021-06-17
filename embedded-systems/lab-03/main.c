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

/* Funkcja sprawdzajaca, czy podana jako argument wartosc wychodzi ponad 
 * polowe liczby 1024 - potrzebna nam przy okreslaniu progu uruchomienia alarmu */
int isAboveHalf(unsigned int tmp)
{
    if (tmp > (1024/2))
        return 1;
    else
        return 0;
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
    
    /* Zmienna counter jest potrzebna przy odliczaniu sekund (tych 5 sekund, 
     * podczas ktorych miga tylko jedna lampka */
    unsigned int counter = 0;
    
    while(1)
    {
        /* Odczytujemy wartosc z przycisku P1 */
        tmp=((unsigned int)adc(0));
        /* Jesli wartosc z przycisku P1 wychodzi poza polowe to wchodzimy do pierwszego while'a */
        if (isAboveHalf(tmp))
        {
            /* Dopoki wartosc z przycisku przekraca polowe zakresu, 
             * oraz zmienna counter jest mniejsza od 5 
             * oraz nie zostal wcisniety klawisz RB3 wykonujemy blok instrukcji */
            while (isAboveHalf(tmp) && counter< 5 && PORTBbits.RB3 > 0)
            {
                /* Zapalamy jedna lampke */
                display = 1;
                PORTD = display;
                /* Sprawdzamy na biezaco wartosc z przycisku P1 */
                tmp=((unsigned int)adc(0));
                /* Robimy p�l-sekundowe opoznienie na czas zapalenia lampki */
                delay(500);
                /* Zgaszamy lampke */
                display = 0;
                PORTD = display;
                /* Ponownie sprawdzamy wartosc z przycisku P1 */
                tmp=((unsigned int)adc(0));
                /* Robimy p�l-sekundowe opoznienie na czas zgaszenia lampki */
                delay(500);
                /* Inkrementujemy licznik w zwiazku z minieciem sekundy */
                counter++;
            }
            
            /* Jesli alarm trwal juz 5 sekund (counter >=5) to wchodzimy do drugiego while'a */
            while (isAboveHalf(tmp) && PORTBbits.RB3 > 0)
            {
                /* Zapalamy wszystkie lampki */
                display = 255;
                PORTD = display;
                /* Sprawdzamy na biezaco wartosc z przycisku P1 */
                tmp=((unsigned int)adc(0));
                /* Mozemy inkrementowac dalej licznik, choc tak naprawde nie jest to konieczne */
                counter++;
            }
            
            /* Jesli w trakcie wykonywania ktorejs z petli while, dojdzie do wcisniecia klawisza RB3, 
             * zerujemy licznik */
            if (PORTBbits.RB3 == 0)
            {
                counter = 0;
            }
        }
        
        /* Jesli zakres na przycisku P1 nie jest przekroczony, to zmienna display wynosi 0 
         * i jest wyswietlona na diodach. Zerujemy takze licznik */
        else
        {
            display = 0;
            PORTD = display;
            counter = 0;
        }
        
    }
    
    return;
}
