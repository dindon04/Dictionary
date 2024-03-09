using System.Collections.Generic;

public static class DictionaryManager
{
    public static void SaveDictionaryToFile(Dictionary dictionary, string filename)
    {
        using (StreamWriter sw = new StreamWriter(filename))
        {
            foreach (var word in dictionary.WordInDictionary)
            {
                sw.WriteLine($"{word.Key}: {string.Join(", ", word.Value)}");
            }
        }

        Console.WriteLine($"Dictionary \"{dictionary.Name}\" exported to file \"{filename}\".");
    }
}
