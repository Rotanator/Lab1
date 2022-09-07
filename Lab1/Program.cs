// See https://aka.ms/new-console-template for more information

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

string input = "29535123p48723487597645723645";
input = "436845320h3343493-43545954934224545393333";

double result = 0;
int processInputIndex = 0;


foreach (char c in input)
{
    if (char.IsDigit(c) == true)
    {   

        // string - numbers returned from FindNumbersInString.
        // int - index of where numbers start.
        // int - index of where numbers end.

        Tuple<string, int, int>? numbers;

        numbers = FindNumberInString(input, c, processInputIndex);
        if (numbers != null)
        {
            HighlightNumberInInput(input, numbers);
            result += double.Parse(numbers.Item1);
        }
    }
    processInputIndex++;
}

Console.WriteLine(result);

Tuple<string, int, int>? FindNumberInString(string inputString, char startingChar, int startingCharIndexStart)
{
    string result = String.Empty;

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
                result += c;
                startingCharOccurence++;

                if (startingCharOccurence == 2)
                {
                    startingCharIndexEnd = i;
                }
            }
            else if (startingCharOccurence == 1)
            {
                result += c;
            }
        }
    }
    
    if (startingCharOccurence < 2)
    {
        return null;
    } else
    {
        return Tuple.Create(result, startingCharIndexStart, startingCharIndexEnd);
    }
    
}

void HighlightNumberInInput(string input, Tuple<string, int, int>? numbers)
{
    int startingCharIndexStart = numbers.Item2;
    int startingCharIndexEnd = numbers.Item3;

    for (int i = 0; i < input.Length; i++)
    {
        char c = input[i];
        char startingChar = input[startingCharIndexStart];

        if (i >= startingCharIndexStart && i <= startingCharIndexEnd)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(input[i]);
        } else
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(input[i]);
        }
    }
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine();
}

Console.ReadKey();