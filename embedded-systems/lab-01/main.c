#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

/* Funkcja realizujaca opóznienie */
void Delay()
{
    int c,d = 0;
    for (c = 1; c <= 32767; c++)
            for (d = 1; d <= 8192; d++)
            {}
}

/* Funkcja zamieniajaca 8-bitowa liczbe na 8 bitowy binarny odpowiednik */
void IntToBinary(unsigned char input)
{
    printf("\r");
    short i = 7;
    while(i>=0)
    {
        printf("%d",(input >> i) & 1);
        i--;
    }
    printf("   ");
    Delay();
}

/* Funkcja zamieniajaca 8-bitowa liczbe na jej odpowiednik w kodzie Graya */
unsigned char IntToGray(unsigned char input)
{
    return input ^ (input >> 1);
}

/* Funkcja zamieniajaca 8-bitowa liczbe na jej odpowiednik w kodzie BCD */
unsigned char IntToBCD(unsigned char input)
{
    return ((input / 10) << 4) | (input % 10);
}

/* Funkcja wyszukujaca dany bit w liczbie binarnej, zwraca unsigned char, oraz przyjmuje
jako argumenty nasza liczbe binarna oraz numer "n" bitu ktorego szukamy */
unsigned char FindBit(unsigned char input, int n)
{
    /* Wejsciowa liczba binarna jest przesuwana o "n-1" pozycji a nastepnie za pomoca koniunkcji z 1 wyluskana i zwrócona */
    return (input >> (n-1)) & 1;
}

int main()
{
    /* -----STEROWANIE-----
       1 - przejscie w lewo
       2 - przejscie w prawo */

    /* Zmienne potrzebne do sterowania:
    key - do sprawdzania jaki klawisz zostal wcisniety,
    progCounter - licznik aktualnie uruchomionego podprogramu */
    unsigned char key;
    unsigned int progCounter=1;

    /* Zmienne potzebne do podprogramu nr 1 i 2:
    display - zmienna wyswietlana
    counter - odpowiada za dodawanie/odejmowanie wartosci 1 w kolejnych wywolaniach */
    unsigned char display=0;
    unsigned char counter=0;

    /* Zmienna potrzebna do podprogramu nr 3 i 4:
    grayCounter - odpowiada za dodawanie/odejmowanie wartosci 1 w kolejnych wywolaniach */
    unsigned char grayCounter=0;

    /* Zmienna potrzebna do podprogramu nr 5 i 6:
    bcdCounter - odpowiada za dodawanie/odejmowanie wartosci 1 w kolejnych wywolaniach */
    unsigned char bcdCounter=0;

    /* Zmienne potrzebne do podprogramu nr 7 - wezyka:
    snake - poczatkowo okresla wartosc startowa, czyli 00000111. Nastepnie zostaje przesuwany w zaleznosci od zmiennej direction
    direction - zmienna definiujaca kierunek poruszania wezyka. Jezeli direction = 1 - wezyk przesuwa sie w lewo, jezeli direction = 0 - wezyk przesuwa sie w prawo */
    unsigned char snake=7;
    unsigned int direction;

    /* Zmienne potrzebne do podprogramu nr 8 - kolejki:
    head - zmienna odpowiadajaca za zapamietywanie stanu na poczatkowych bitach kolejki, poczatkowo 00000000 => 10000000, itd.
    one - zmienna, która uwidacznia ruch kolejki miedzy kolejnymi wywolaniami: poczatkowo 00000001 => 00000010 => 00000100 itd.
    queueCounter - licznik okreslajacy ile razy ma nastapic przesuniecie zmiennej one w lewa strone
    i - zmienna inkrementowana w kolejnych krokach kolejki i resetowana przy dojsciu do jej konca */
    unsigned char head = 0;
    unsigned char one = 1;
    unsigned int queueCounter = 8;
    unsigned int i=1;

    /* Zmienne potrzebne do podprogramu nr 9 - generator liczb pseudolosowych:
    start - odpowiada za wartosc startowa czyli 00000001, na niej dokonywane jest tez przesuniecie w prawo
    first, second, fifth, sixth - zmienne zdefiniowane w celu przetrzymywanie wartosci z okreslonych bitow liczby (numeracja rzecz jasna od prawej do lewej) */
    unsigned char start = 1;
    unsigned char first, second, fifth, sixth, xorResult;

    while (1)
    {
        printf("Jestem w programie numer: %d | Sterowanie: 1-Kolejny podprogram, 2-Poprzedni podprogram", progCounter);

        if (kbhit())
            key=getch();

        /* Kazdy case - to osobny podprogram */
        switch (progCounter)
        {
        case 1:
            display = counter;
            IntToBinary(display);
            counter++;
            break;
        case 2:
            display = counter;
            IntToBinary(display);
            counter--;
            break;
        case 3:
            display = IntToGray(grayCounter);
            IntToBinary(display);
            grayCounter++;
            break;
        case 4:
            display = IntToGray(grayCounter);
            IntToBinary(display);
            grayCounter--;
            break;
        case 5:
            display = IntToBCD(bcdCounter);
            IntToBinary(display);
            bcdCounter++;
            if (bcdCounter > 99)
                bcdCounter = 0;
            break;
        case 6:
            display = IntToBCD(bcdCounter);
            IntToBinary(display);
            bcdCounter--;
            if (bcdCounter > 99)
                bcdCounter = 99;
            break;
        case 7:
            /* Do zmiennej wyswietlanej - display przypisujemy zmienna snake */
            display = snake;
            /* Zmienna display jest wyswietlana na ekranie w formie 8 bitowej liczby binarnej */
            IntToBinary(display);
            /* Jezeli wezyk dochodzi do lewej sciany to (...) */
            if (snake == 224)
                /* (...) zmieniamy kierunek na "w prawo", czyli do zmiennej direction przypisujemy 0 */
                direction = 0;
            /* Jezeli wezyk dochodzi do prawej sciany to (...) */
            else if (snake == 7)
                /* (...) zmieniamy kierunek na "w lewo", czyli do zmiennej direction przypisujemy 1 */
                direction = 1;\
            /* Jezeli zmienna direction jest równa 1, to wezyk przesuwamy w lewo */
            if (direction)
                snake <<= 1;
            /* Jezeli zmienna direction jest równa 0, to wezyk przesuwamy w prawo */
            else
                snake >>=1;
            break;
        case 8:
            /* Jezeli kolejka jest juz pelna, resetujemy wszystkie zmienne */
            if (display==255)
            {
                head = 0;
                one = 1;
                queueCounter = 8;
                i=1;
            }
            /* Zmienna wywolywana na ekranie - display sklada sie ze zmiennej head oraz one */
            display = head | one;
            /* Zmienna display jest wyswietlana na ekranie w formie 8 bitowej liczby binarnej */
            IntToBinary(display);
            /* Dopóki licznik i jest mniejszy od zmiennej queueCounter, inkrementujemy i oraz przesuwany kolejke w lewo.
            Czyli zmienna one zmienia sie w kolejnych wywolaniach w nastepujacy sposób: 0000001 => 00000010 => 00000100 itd. */
            if (i<queueCounter)
            {
                i++;
                one <<=1;
            }
            /* Jezeli licznik "i" równa sie ze zmienna queueCounter, to do zmiennej head przypisujemy head
            oraz aktualny stan zmiennej one, czyli moment gdy dochodzi ona do konca kolejki. Nastepnie zmienna i jest resetowana, a zmienna
            queueCounter zmniejszana, zeby w nastepnych krokach pomijala juz elementy dopisane do kolejki
            Kolejne zmiany na zmiennej head wygladaja nastepujaca: 1000000 => 110000000 => 11100000 itd. */
            else if (i==queueCounter)
            {
                head = head | one;
                one = 1;
                i=1;
                queueCounter--;
            }
            break;
        case 9:
            /* Zmienna wywolywana na ekranie - display z kazdym wywolaniem ma przypisana wartosc zmiennej start*/
            display = start;
            /* Zmienna display jest wyswietlana na ekranie w formie 8 bitowej liczby binarnej */
            IntToBinary(display);
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

        /* Jezeli wciskamy klawisz 1, to zmienna progCounter jest zmniejszana, a wiec uruchamiamy poprzedni program */
        if (key =='1')
        {
            progCounter--;
            key = "x";
        }

        /* Jezeli wciskamy klawisz 2, to zmienna progCounter jest zwiekszana, a wiec uruchamiamy nastepny program */
        else if (key =='2')
        {
            progCounter++;
            key = "x";
        }

        /* Jezeli zmienna progCounter osiaga nr 10, to przeskakujemy do programu nr 1 */
        if(progCounter == 10)
            progCounter = 1;
        /* Jezeli zmienna progCounter osiaga nr 0, to przeskakujemy do programu nr 9 */
        else if (progCounter == 0)
            progCounter = 9;
    }
}
