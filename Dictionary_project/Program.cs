class Dictionary
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
            Console.WriteLine($"translation for word \"{word}\" in the dictionary \"{Name}\" updated");
            SaveToFile();
        }
    }

    public void DeleteWord(string word)
    {
        if (WordInDictionary.ContainsKey(word))
        {
            WordInDictionary.Remove(word);
            Console.WriteLine($"word \"{word}\" deleted from the dictionary \"{Name}\"");
            SaveToFile();
        }
        else Console.WriteLine($"word \"{word}\" not found in the dictionary \"{Name}\".No changes");
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

    private void SaveToFile()
    {
        ExportToFile($"{Name}.txt");
    }
}

class Program
{
    static List<Dictionary> dictionaries = new List<Dictionary>();

    static void Main()
    {
        while (true)
        {
            PrintMenu();

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.Write("Enter dictionary name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter the language you translate from: ");
                    string languageFrom = Console.ReadLine();
                    Console.Write("Enter the language you translate to: ");
                    string languageTo = Console.ReadLine();
                    Dictionary newDictionary = new Dictionary(name, languageFrom, languageTo);
                    dictionaries.Add(newDictionary);
                    Console.WriteLine($"Dictionary 《{newDictionary.Name}》 created.");
                    //Console.WriteLine("Press Enter to continue...");
                    //Console.ReadLine(); // Added user input wait
                    break;

                case "2":
                    Console.Clear();
                    if (dictionaries.Count > 0)
                    {
                        Console.Write("Enter dictionary name: ");
                        string dictionaryName = Console.ReadLine();
                        Dictionary currentDictionary = dictionaries.FirstOrDefault(d => d.Name == dictionaryName);

                        if (currentDictionary != null)
                        {
                            Console.Write("Enter word to add to the dictionary: ");
                            string wordToAdd = Console.ReadLine();
                            Console.Write("Enter translation(s), separated by commas: ");
                            List<string> translationsToAdd = new List<string>(Console.ReadLine().Split(','));
                            currentDictionary.AddWord(wordToAdd, translationsToAdd);
                        }
                        else
                        {
                            Console.WriteLine($"Dictionary \"{dictionaryName}\" not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please create a dictionary first.");
                    }
                    break;

                case "3":
                    Console.Clear();
                    if (dictionaries.Count > 0)
                    {
                        Console.Write("Enter dictionary name: ");
                        string dictionaryName = Console.ReadLine();
                        Dictionary currentDictionary = dictionaries.FirstOrDefault(d => d.Name == dictionaryName);

                        if (currentDictionary != null)
                        {
                            Console.Write("Enter word to replace in the dictionary: ");
                            string wordToReplace = Console.ReadLine();
                            Console.Write("Enter new translation(s), separated by commas: ");
                            List<string> newTranslations = new List<string>(Console.ReadLine().Split(','));
                            currentDictionary.AddTranslate(wordToReplace, newTranslations);
                        }
                        else
                        {
                            Console.WriteLine($"Dictionary \"{dictionaryName}\" not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please create a dictionary first.");
                    }
                    break;

                case "4":
                    Console.Clear();
                    if (dictionaries.Count > 0)
                    {
                        Console.Write("Enter dictionary name: ");
                        string dictionaryName = Console.ReadLine();
                        Dictionary currentDictionary = dictionaries.FirstOrDefault(d => d.Name == dictionaryName);

                        if (currentDictionary != null)
                        {
                            Console.Write("Enter word to delete from the dictionary: ");
                            string wordToDelete = Console.ReadLine();
                            currentDictionary.DeleteWord(wordToDelete);
                        }
                        else
                        {
                            Console.WriteLine($"Dictionary \"{dictionaryName}\" not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please create a dictionary first.");
                    }
                    break;

                case "5":
                    Console.Clear();
                    if (dictionaries.Count > 0)
                    {
                        Console.Write("Enter dictionary name: ");
                        string dictionaryName = Console.ReadLine();
                        Dictionary currentDictionary = dictionaries.FirstOrDefault(d => d.Name == dictionaryName);

                        if (currentDictionary != null)
                        {
                            Console.Write("Enter word to search for translation: ");
                            string wordToSearch = Console.ReadLine();
                            string result = currentDictionary.SearchTranslation(wordToSearch);
                            Console.WriteLine(result);
                        }
                        else
                        {
                            Console.WriteLine($"Dictionary \"{dictionaryName}\" not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please create a dictionary first.");
                    }
                    break;

                case "6":
                    Console.Clear();
                    if (dictionaries.Count > 0)
                    {
                        Console.Write("Enter dictionary name: ");
                        string dictionaryName = Console.ReadLine();
                        Dictionary currentDictionary = dictionaries.FirstOrDefault(d => d.Name == dictionaryName);

                        if (currentDictionary != null)
                        {
                            Console.Write("Enter filename to export the dictionary: ");
                            string filename = Console.ReadLine();
                            currentDictionary.ExportToFile(filename);
                        }
                        else
                        {
                            Console.WriteLine($"Dictionary \"{dictionaryName}\" not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please create a dictionary first.");
                    }
                    break;

                case "0":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select an existing menu item.");
                    break;
            }
        }
    }

    static void PrintMenu()
    {
        Console.WriteLine("1. Create a dictionary");
        Console.WriteLine("2. Add word and translation to the dictionary");
        Console.WriteLine("3. Replace word or translation in the dictionary");
        Console.WriteLine("4. Delete word or translation from the dictionary");
        Console.WriteLine("5. Search for translation of a word");
        Console.WriteLine("6. Export dictionary to a file");
        Console.WriteLine("0. Exit");
        Console.Write("Choose an action (enter the number): ");
    }
}
