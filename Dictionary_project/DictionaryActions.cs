using System.Collections.Generic;

public static class DictionaryActions
{
    public static void CreateDictionary(List<Dictionary> dictionaries)
    {
        Console.Write("Enter dictionary name: ");
        string name = Console.ReadLine();

        if (IsDictionaryNameUnique(dictionaries, name))
        {
            Console.WriteLine("\nEnter the languages");
            Console.Write("translate from: ");
            string languageFrom = Console.ReadLine();
            Console.Write("translate to: ");
            string languageTo = Console.ReadLine();

            Dictionary newDictionary = new Dictionary(name, languageFrom, languageTo);
            dictionaries.Add(newDictionary);
            Console.WriteLine($"\ndictionary \"{newDictionary.Name}\" created");
        }
        else Console.WriteLine($"Dictionary  \"{name}\" already exists");

        //Console.Write($"\nEnter to return to menu...");
        //Console.ReadLine();
    }

    private static bool IsDictionaryNameUnique(List<Dictionary> dictionaries, string name)
    {
        foreach (var dictionary in dictionaries)
        {
            if (dictionary.Name == name)
            {
                return false;
            }
        }
        return true;
    }


    public static void AddWordToDictionary(List<Dictionary> dictionaries)
    {
        if (dictionaries.Count > 0)
        {
            Console.Write("Enter dictionary name: ");
            string dictionaryName = Console.ReadLine();
            Dictionary currentDictionary = dictionaries.FirstOrDefault(d => d.Name == dictionaryName);

            if (currentDictionary != null)
            {
                Console.Write("enter word to add to the dictionary: ");
                string wordToAdd = Console.ReadLine();

                Console.Write("enter translation(s), separated by \",\" : ");
                List<string> translationsToAdd = new List<string>(Console.ReadLine().Split(','));
                currentDictionary.AddWord(wordToAdd, translationsToAdd);
            }
            else Console.WriteLine($"Dictionary \"{dictionaryName}\" not found");
        }
        else Console.WriteLine("please, create a dictionary");

        //Console.Write($"\nEnter to return to menu...");
        //Console.ReadLine();
    }

    public static void EditTranslationInDictionary(List<Dictionary> dictionaries)
    {
        if (dictionaries.Count > 0)
        {
            Console.Write("Enter dictionary name: ");
            string dictionaryName = Console.ReadLine();
            Dictionary currentDictionary = dictionaries.FirstOrDefault(d => d.Name == dictionaryName);

            if (currentDictionary != null)
            {
                Console.Write("Enter word to edit in the dictionary: ");
                string wordToReplace = Console.ReadLine();
                Console.Write("Enter new translation(s), separated by \",\": ");
                List<string> newTranslations = new List<string>(Console.ReadLine().Split(','));
                currentDictionary.AddTranslate(wordToReplace, newTranslations);
            }
            else Console.WriteLine($"Dictionary \"{dictionaryName}\" not found");
        }
        else Console.WriteLine("please, create a dictionary");

        //Console.Write($"\nEnter to return to menu...");
        //Console.ReadLine();
    }

    public static void DeleteWordFromDictionary(List<Dictionary> dictionaries)
    {
        if (dictionaries.Count > 0)
        {
            Console.Write("Enter dictionary name: ");
            string dictionaryName = Console.ReadLine();
            Dictionary currentDictionary = dictionaries.FirstOrDefault(d => d.Name == dictionaryName);

            if (currentDictionary != null)
            {
                Console.Write("Enter word to delete from the dictionary: ");
                string wordToDelete = Console.ReadLine();

                Console.WriteLine("Choose deletion option:");
                Console.WriteLine("1. Delete word with all translations");
                Console.WriteLine("2. Delete all translations except the last one");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            currentDictionary.DeleteWord(wordToDelete);
                            break;
                        case 2:
                            currentDictionary.DeleteAllTranslationsExceptLast(wordToDelete);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. No changes made.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. No changes made.");
                }
            }
            else
            {
                Console.WriteLine($"Dictionary \"{dictionaryName}\" not found");
            }
        }
        else
        {
            Console.WriteLine("Please, create a dictionary");
        }

        Console.Write("\nEnter to return to menu...");
        Console.ReadLine();
    }


    public static void SearchForTranslation(List<Dictionary> dictionaries)
    {
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
            else Console.WriteLine($"Dictionary \"{dictionaryName}\" not found");
        }
        else Console.WriteLine("please, create a dictionary");

        //Console.Write($"\nEnter to return to menu...");
        //Console.ReadLine();
    }

    public static void ExportDictionaryToFile(List<Dictionary> dictionaries)
    {
        if (dictionaries.Count > 0)
        {
            Console.Write("Enter dictionary name: ");
            string dictionaryName = Console.ReadLine();
            Dictionary currentDictionary = dictionaries.FirstOrDefault(d => d.Name == dictionaryName);

            if (currentDictionary != null)
            {
                Console.Write("Enter filename to export the dictionary: ");
                string filename = Console.ReadLine();
                DictionaryManager.SaveDictionaryToFile(currentDictionary, filename);
            }
            else Console.WriteLine($"Dictionary \"{dictionaryName}\" not found");
        }
        else Console.WriteLine("please, create a dictionary");

        //Console.Write($"\nEnter to return to menu...");
        //Console.ReadLine();
    }

    public static void CopyWordsToFile(List<Dictionary> dictionaries)
    {
        if (dictionaries.Count > 0)
        {
            Console.Write("Enter dictionary name: ");
            string dictionaryName = Console.ReadLine();
            Dictionary currentDictionary = dictionaries.FirstOrDefault(d => d.Name == dictionaryName);

            if (currentDictionary != null)
            {
                Console.Write("Enter filename to copy the words: ");
                string filename = Console.ReadLine();

                Console.Write("Enter words to copy, separated by \",\": ");
                List<string> wordsToCopy = new List<string>(Console.ReadLine().Split(','));

                DictionaryManager.CopyWordsToFile(currentDictionary, filename, wordsToCopy);
            }
            else
            {
                Console.WriteLine($"Dictionary \"{dictionaryName}\" not found");
            }
        }
        else
        {
            Console.WriteLine("Please, create a dictionary");
        }

        //Console.Write($"\nEnter to return to menu...");
        //Console.ReadLine();
    }

}

