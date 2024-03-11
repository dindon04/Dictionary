using System.Collections.Generic;
using System.IO;

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
    public static void CopyWordsToFile(Dictionary sourceDictionary, string filename, List<string> wordsToCopy)
    {
        using (StreamWriter sw = new StreamWriter(filename))
        {
            foreach (var word in wordsToCopy)
            {
                if (sourceDictionary.WordInDictionary.TryGetValue(word, out var translations))
                {
                    sw.WriteLine($"{word}: {string.Join(", ", translations)}");
                }
                else
                {
                    Console.WriteLine($"Word \"{word}\" not found in the dictionary. Skipping...");
                }
            }
        }

        Console.WriteLine($"words copied from dictionary \"{sourceDictionary.Name}\" to file \"{filename}\"");
    }
    
}
