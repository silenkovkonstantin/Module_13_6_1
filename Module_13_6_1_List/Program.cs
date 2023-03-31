using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace Module_13_6_1_List
{
    class Program
    {
        static List<string> wordsList = new();

        static void Main(string[] args)
        {
            string text = string.Empty;

            string path = @"C:\Users\home\Downloads\cdev_Text.txt";

            using (StreamReader sr = File.OpenText(path))
            {
                while ((text = sr.ReadLine()) != null) // Пока не кончатся строки - считываем из файла по одной
                {
                    var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray()); // Убираем знаки пунктуации
                    string[] wordsArray = noPunctuationText.Split(); // Разбиваем строку на слова и добавляем  в массив
                    wordsList.AddRange(wordsArray); // Массив добавляем в список
                    wordsList.RemoveAll(c => c == ""); // Удаляем из списка все пустые строки
                }
            }

            List<string> listToInsert = new() { "Слово1", "Слово2"};

            // Вставка в конец списка
            
            var watchTwo = Stopwatch.StartNew();

            wordsList.Add("Список");

            Console.WriteLine($"Вставка элемента в список: {watchTwo.Elapsed.TotalMilliseconds} мс");

            // Вставка другой коллекции

            var watchOne = Stopwatch.StartNew();

            wordsList.AddRange(listToInsert);

            Console.WriteLine($"Вставка коллекции в список: {watchOne.Elapsed.TotalMilliseconds} мс");
        }
    }
}
