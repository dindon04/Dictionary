using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Dictionary
{
    public string Name { get; set; }
    public string LanguageFrom { get; set; }
    public string LanguageTo { get; set; }
    public Dictionary<string, List<string>> WordInDictionary { get; set; }

    public Dictionary(string name, string languageFrom, string languageTo)
    {
        Name = name;
        LanguageFrom = languageFrom;
        LanguageTo = languageTo;
        WordInDictionary = new Dictionary<string, List<string>>();
    }

    public void AddWord(string word, List<string> translations)
    {
        WordInDictionary[word] = translations;
        Console.WriteLine($"word \"{word}\" added to dictionary \"{Name}\"");
        SaveToFile();
    }

    public void AddTranslate(string word, List<string> newTranslations)
    {
        if (WordInDictionary.ContainsKey(word))
        {
            WordInDictionary[word] = newTranslations;
            Console.WriteLine($"translation for word \"{word}\" updated");
            SaveToFile();
        }
    }

    public void DeleteWord(string word)
    {
        if (WordInDictionary.ContainsKey(word))
        {
            WordInDictionary.Remove(word);
            Console.WriteLine($"word \"{word}\" deleted");
            SaveToFile();
        }
        else Console.WriteLine($"word \"{word}\" not found in the dictionary. No changes");
    }

    public string SearchTranslation(string word)
    {
        if (WordInDictionary.ContainsKey(word)) return string.Join(", ", WordInDictionary[word]);
        else return $"translation for word \"{word}\" not found";
    }

    public void ExportToFile(string filename)
    {
        using (StreamWriter sw = new StreamWriter(filename))
        {
            foreach (var word in WordInDictionary)
            {
                sw.WriteLine($"{word.Key}: {string.Join(", ", word.Value)}");
            }
        }

        Console.WriteLine($"dictionary \"{Name}\" exported to file \"{filename}\"");
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

        Console.WriteLine($"Selected words copied from dictionary \"{sourceDictionary.Name}\" to file \"{filename}\"");
    }

    private void SaveToFile()
    {
        ExportToFile($"{Name}.txt");
    }
}
