

/* Lab1 – Hitta tal i sträng med tecken
 
Skapa en konsollapplikation som tar en textsträng (string) som input.
Textsträngen ska sedan sökas igenom efter alla delsträngar som är tal som börjar
och slutar på samma siffra, utan att start/slutsiffran, eller något annat tecken än
siffror förekommer där emellan.

ex. 3463 är ett korrekt sådant tal, men 34363 är det inte eftersom det finns
ytterligare en 3:a i talet, förutom start och slutsiffran. Strängar som innehåller
andra tecken än siffror, t.ex 95a9 är inte heller ett korrekt tal.

Skriv ut och markera varje korrekt delsträng

För varje sådan delsträng som matchar kriteriet ovan ska programmet skriva ut en
rad med hela strängen, men där delsträngen är markerad i en annan färg.

*/

string input = ObtainUserInput();

double sumOfNumbers = 0;
int processInputIndex = 0;


foreach (char c in input)
{
    if (char.IsDigit(c) == true)
    {   

        // string - numbers returned from FindNumbersInString.
        // int - index of where numbers start.
        // int - index of where numbers end.

        Tuple<string, int, int>? numbersData;

        numbersData = FindNumberInString(input, c, processInputIndex);

        if (numbersData != null)
        {
            HighlightNumberInInput(input, numbersData);
            sumOfNumbers += double.Parse(numbersData.Item1);
        }
    }
    processInputIndex++;
}

Console.WriteLine();
Console.WriteLine("Sum of all marked numbers in provided string: " + sumOfNumbers);

string ObtainUserInput()
{
    Console.WriteLine("Lab 1 - Hitta tal i sträng med tecken \n\n" +
        "Skapa en konsollapplikation som tar en textsträng (string) som input. \n" +
        "Textsträngen ska sedan sökas igenom efter alla delsträngar som är tal som börjar \n" +
        "och slutar på samma siffra, utan att start/slutsiffran, eller något annat tecken än \n" +
        "siffror förekommer där emellan. \n\n" +
        "ex. 3463 är ett korrekt sådant tal, men 34363 är det inte eftersom det finns \n" +
        "ytterligare en 3:a i talet, förutom start och slutsiffran. Strängar som innehåller \n" +
        "andra tecken än siffror, t.ex 95a9 är inte heller ett korrekt tal. \n\n" +
        "Skriv ut och markera varje korrekt delsträng \n\n" +
        "För varje sådan delsträng som matchar kriteriet ovan ska programmet skriva ut en \n" +
        "rad med hela strängen, men där delsträngen är markerad i en annan färg. \n\n\n");

    Console.WriteLine("Tryck valfri knapp för att fortsätta");
    Console.ReadKey();
    Console.Clear();
    Console.Write("Provide a string to process: ");

    string input = Console.ReadLine();
    Console.Clear();

    return input;
}

Tuple<string, int, int>? FindNumberInString(string inputString, char startingChar, int startingCharIndexStart)
{
    string numbersResult = String.Empty;

    int startingCharOccurence = 0;
    int startingCharIndexEnd = 0;

    for (int i = startingCharIndexStart; i < inputString.Length; i++)
    {
        char c = inputString[i];

        if (startingCharOccurence >= 2 || char.IsDigit(c) == false )
        {
            break;
        } else
        {
            if (c == startingChar && startingCharOccurence < 2)
            {
                numbersResult += c;
                startingCharOccurence++;

                if (startingCharOccurence == 2)
                {
                    startingCharIndexEnd = i;
                }
            }
            else if (startingCharOccurence == 1)
            {
                numbersResult += c;
            }
        }
    }
    
    if (startingCharOccurence < 2)
    {
        return null;
    } else
    {
        return Tuple.Create(numbersResult, startingCharIndexStart, startingCharIndexEnd);
    }
    
}

void HighlightNumberInInput(string input, Tuple<string, int, int>? numbersData)
{
    int startingCharIndexStart = numbersData.Item2;
    int startingCharIndexEnd = numbersData.Item3;

    for (int i = 0; i < input.Length; i++)
    {
        char currentChar = input[i];

        if (i >= startingCharIndexStart && i <= startingCharIndexEnd)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(currentChar);
        } else
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(currentChar);
        }
    }
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine();
}
