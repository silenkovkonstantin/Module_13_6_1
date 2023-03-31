using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace Module_13_6_1_LinkedList
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
                    string marker = " Чупакабра "; // Маркер используем для вставки в середину списка
                    var markedText = noPunctuationText.Insert(noPunctuationText.Length / 2, marker);
                    string[] wordsArray = markedText.Split(); // Разбиваем строку на слова и добавляем в массив                    
                    wordsList.AddRange(wordsArray); // Массив добавляем в список
                    wordsList.RemoveAll(c => c == ""); // Удаляем из списка все пустые строки
                }
            }

            LinkedList<string> wordsLinkedList = new(wordsList);

            // Вставка в начало списка

            var watchTwo = Stopwatch.StartNew();

            wordsLinkedList.AddAfter(wordsLinkedList.First, "Список");

            Console.WriteLine($"Вставка в начало списка: {watchTwo.Elapsed.TotalMilliseconds} мс");

            // Вставка в конец списка
            
            var watchOne = Stopwatch.StartNew();

            wordsLinkedList.AddAfter(wordsLinkedList.Last, "Список");

            Console.WriteLine($"Вставка в конец списка: {watchOne.Elapsed.TotalMilliseconds} мс");

            // Вставка в середину списка

            var watchThree = Stopwatch.StartNew();

            wordsLinkedList.AddAfter(wordsLinkedList.Find("Чупакабра"), "Список");

            Console.WriteLine($"Вставка в середину списка: {watchThree.Elapsed.TotalMilliseconds} мс");
        }
    }
}
