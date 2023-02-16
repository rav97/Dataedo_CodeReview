# Dataedo_CodeReview
Zadanie rekrutacyjne mające na celu przeprowadzenie code-review dla kodu z repozytorium https://github.com/Dataedo/ConsoleApp/tree/main/ConsoleApp


## Lista uwag

Poniższa lista zawiera elementy, które zostały zmienione w odniesieniu do pierwotnego kodu. Dla każdej z klas wyszczególniono osobną listę.

### Program.cs

- Do 15 linijki kodu zakradła się literówka. Nazwa pliku CSV została wpisana jako "dataa.csv" podczas gdy dostarczony z projektem plik nazywa się "data.csv".

### DataReader.cs

- W pierwszej kolejności w oczy rzuca się mnogość zdefiniowanych klas w jednym pliku. W trosce o czytelność kodu zawsze należy dbać o to aby w jednym pliku znajdowała się jedna klasa. Ta, na którą wskazuje nazwa pliku. W celu uporządkowania kodu wydzieliłem każdą klasę do oddzielnego pliku, które dodatkowo uporządkowałem w odpowiednich folderach i przestrzeniach nazw (struktura projektu ułatwiająca zarządzanie nim w razie przyszłej rozbudowy funkcjonalności).
- Cała klasa DataReader jest zbudowana na zasadzie "scyzoryk szwajcarski" - robi wszystko na raz w dodaku w bardzo ukierunkowany sposób.
- Bardzo dużo pętli i "pętli w pętli". Ich liczbę można zmniejszyć na przykład poprzez wykonywanie więcej niż jednej operacji przy każdej iteracji.
- Liczbe błędy w implementacji powodujące zwracanie wyjątków w trakcie programu.
- Nigdy nie mamy gwarancji, że dane wejściowe są w pełni poprawne i jakaś podstawowa walidacja zawsze się przyda (przykładowo sprawdzić czy liczba elementów w każdym z wierszy pliku jest zgodna - zwłaszcza kiedy potem odwołujemy się do tych elementów po indeksie)
- Metoda zczytuje z pliku wszystkie linijki i umieszcza do kolekcji, pierwsza linijka w pliku zawiera nagłówki więc nie ma sensu jej uwzględniać.


### Wnioski

- Program tak naprawdę nie działa ze względu na liczne błędy. Naprawa jednego błędu skutkuje odkryciem kolejnych.
- Brak podejścia SOLID.
- Niska czytelność kodu.


## Co zmieniłem?

Po wielu namysłach zdecydowałem się na całkowite napisanie programu od nowa, zachowując jedynie fragmenty pierwotnego zamysłu.
Nowa aplikacja w większym stopniu respektuje zasady SOLID, a także implementuje podejście DDD (pewien wariant).
Dzięki takim zabiegom nowa aplikacja jest bardziej elastyczna, łatwiej będzie ją modyfikować w razie zmiany formatu danych wejściowych, a także możliwe będzie jej poszerzenie lub przełączenie na nowe formaty danych wejściowych.

