using System;
using System.Collections.Generic;
using System.IO;

namespace Book_Manager
{
    public class BookCollection
    {
        List<string> books;
        public BookCollection()
        {
            books = new List<string>();
            try
            {
                using (var sr = new StreamReader("Books.txt"))
                {
                    while (sr.EndOfStream == false)
                    {
                        books.Add(sr.ReadLine());
                    }
                }
            } catch (IOException e)
            {
                Console.WriteLine("The file could not be read.");
                Console.WriteLine(e.Message);
            }
        }
        public void UpdateFile()
        {
            try
            {
                using (var sr = new StreamWriter("Books.txt", false))
                {
                    foreach(var book in books)
                    {
                        sr.WriteLine(book);
                    }
                }
            } catch (IOException e)
            {
                Console.WriteLine("The file could not be written.");
                Console.WriteLine(e.Message);
            }
        }
        public List<string> GetAll()
        {
            return books;
        }
        public string GetOne(int index)
        {
            return books[index];
        }
        public int Count()
        {
            return books.Count;
        }
        public void Add(string title)
        {
            books.Add(title);
            UpdateFile();
        }
        public void Edit(int index, string newTitle)
        {
            books[index] = newTitle;
            UpdateFile();
        }
        public void Remove(int index)
        {
            books.RemoveAt(index);
            UpdateFile();
        }
        public void PrintAll()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("Book collection is empty.");
            } else
            {
                Console.WriteLine("Your current collection: ");
                for (int i = 0; i < books.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {books[i]}");
                }
            }
            
        }
        public void ImportSample()
        {
            books.Clear();

            books.Add("Moby Dick");
            books.Add("Harry Potter");
            books.Add("Lord of the Rings");
            books.Add("Pinocchio");
            books.Add("Alice's Adventures in Wonderland");
            books.Add("Don Quixote");

            UpdateFile();
        }
    }
}
