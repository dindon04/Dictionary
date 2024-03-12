using System;
using System.Collections.Generic;

class Program
{
    static List<Dictionary> dictionaries = new List<Dictionary>();

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        while (true)
        {
            Console.Clear();
            PrintMenu();

            string select = Console.ReadLine();

            MenuSwitchChoice(select);
        }
    }

    static void MenuSwitchChoice(string select)
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
            case "7":
                DictionaryActions.CopyWordsToFile(dictionaries);
                break;
            case "0":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Select a menu item again");
                break;
        }

        Console.Write("\nEnter to return to the menu...");
        Console.ReadLine();
    }

    static void PrintMenu()
    {
        Console.WriteLine("1. Create a dictionary");
        Console.WriteLine("2. Add word and translation to the dictionary");
        Console.WriteLine("3. Edit translation in the dictionary");
        Console.WriteLine("4. Delete word or translation from the dictionary");
        Console.WriteLine("5. Search for translation of word");
        Console.WriteLine("6. Export dictionary to a file");
        Console.WriteLine("7. Copy selected words from dictionary to a file"); // Add this line for the new option
        Console.WriteLine("0. Exit");
        Console.Write("\nChoose an action (0-7): ");
    }
}
