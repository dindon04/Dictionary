using System.Collections.Generic;
using static DictionaryActions;
class Program
{
    static List<Dictionary> dictionaries = new List<Dictionary>();
    // static List<Dictionary> dictionaries;

    static void Main()
    {
        //dictionaries = DictionaryManager.LoadDictionaries();
        while (true)
        {
            Console.Clear();
            PrintMenu();

            string select = Console.ReadLine();

            MenuSwitchChoise(select);
        }
    }

    static void MenuSwitchChoise(string select)
    {
        Console.Clear();

        switch (select)
        {
            case "1":
                DictionaryActions.CreateDictionary(dictionaries);
                break;
            case "2":
                DictionaryActions.AddWordToDictionary(dictionaries);
                break;
            case "3":
                DictionaryActions.EditTranslationInDictionary(dictionaries);
                break;
            case "4":
                DictionaryActions.DeleteWordFromDictionary(dictionaries);
                break;
            case "5":
                DictionaryActions.SearchForTranslation(dictionaries);
                break;
            case "6":
                DictionaryActions.ExportDictionaryToFile(dictionaries);
                break;
            case "0":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("invalid choice. Select menu item again");
                break;
        }
    }

    static void PrintMenu()
    {
        Console.WriteLine("1. Create a dictionary");
        Console.WriteLine("2. Add word and translation to the dictionary");
        Console.WriteLine("3. Edit translation in the dictionary");
        Console.WriteLine("4. Delete word or translation from the dictionary");
        Console.WriteLine("5. Search for translation of word");
        Console.WriteLine("6. Export dictionary to a file");
        Console.WriteLine("0. Exit");
        Console.Write("\nChoose an action (0-6): ");
    }
}
