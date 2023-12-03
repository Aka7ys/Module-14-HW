using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Game game = new Game(3);
        game.PlayGame();

        string text = "Это пример текста. Пример текста может быть любым, но для данной задачи используется этот текст.";

        Dictionary<string, int> wordStatistics = CountWordOccurrences(text);

        Console.WriteLine("Статистика по тексту:");
        Console.WriteLine("Слово\t\tЧастота");
        foreach (var pair in wordStatistics)
        {
            Console.WriteLine($"{pair.Key}\t\t{pair.Value}");
        }
    }

    static Dictionary<string, int> CountWordOccurrences(string text)
    {
        string[] words = text.Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> wordStatistics = new Dictionary<string, int>();

        foreach (var word in words)
        {
            string normalizedWord = word.ToLower();

            if (wordStatistics.ContainsKey(normalizedWord))
            {
                wordStatistics[normalizedWord]++;
            }
            else
            {
                wordStatistics[normalizedWord] = 1;
            }
        }

        return wordStatistics;
    }
}
