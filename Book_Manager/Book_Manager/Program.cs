using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Manager
{
    class Program
    {
        static BookCollection books; 

        static void ShowOptions()
        {
            Console.Clear();
            Console.WriteLine("Book Manager 2020\n");
            Console.WriteLine("Select what action to perform:");

            Console.WriteLine("1. Show all books.");
            Console.WriteLine("2. Add a new book.");
            Console.WriteLine("3. Edit a book.");
            Console.WriteLine("4. Delete a book.");
            Console.WriteLine("5. Search books");
            Console.WriteLine("6. Exit appplication.");

            int option = 0;
            try
            {
                option = int.Parse(Console.ReadLine());
            } catch (Exception)
            {
                ShowOptions();
            }
            
            Console.Clear();
            SelectOption(option);
        }

        static void SelectOption(int option)
        {
            switch (option)
            {
                case 1:
                    ShowBooks();
                    break;
                case 2:
                    AddBook();
                    break;
                case 3:
                    EditBook();
                    break;
                case 4:
                    DeleteBook();
                    break;
                case 5:
                    SearchBooks();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }

        static void BackToMenu()
        {
            Console.WriteLine("\nPress any key to go back to the main menu.");
            Console.ReadKey();
            ShowOptions();
        }

        static void ShowBooks()
        {
            books.PrintAll();

            Console.WriteLine("\nPress 1 to import a sample collection. (Your previous books will be deleted).");
            Console.WriteLine("Press any other key to return to the main menu.");

            string input = Console.ReadLine();
            if (input == "1")
            {
                books.ImportSample();
                Console.Clear();
                books.PrintAll();

                BackToMenu();
            } else
            {
                ShowOptions();
            }
            
        }

        static void AddBook()
        {
            books.PrintAll();

            Console.WriteLine("\nInsert the name of the book to add: ");

            string bookName = Console.ReadLine();

            books.Add(bookName);

            Console.Clear();
            Console.WriteLine($"The book '{bookName}' has been added to the collection.\n");

            books.PrintAll();

            BackToMenu();
        }

        static void EditBook()
        {
            books.PrintAll();

            if (books.Count() == 0)
            {
                BackToMenu();
                return;
            }

            int index = 1;
            Console.Write("\nInsert the index of the book to edit: ");
            try
            {
                index = int.Parse(Console.ReadLine());

                if (index > books.Count() || index < 0)
                {
                    throw new Exception();
                }
            } catch (Exception)
            {
                Console.WriteLine("Invalid input, please try again.");
                Console.Clear();
                EditBook();
            }
            
            Console.Write("Insert a new title for the selected book: ");
            string newTitle = Console.ReadLine();

            books.Edit(index - 1, newTitle);

            Console.Clear();
            Console.WriteLine($"Book at index {index} has been changed to '{newTitle}'\n");

            books.PrintAll();

            BackToMenu();
        }

        static void DeleteBook()
        {
            books.PrintAll();
            if (books.Count() == 0)
            {
                BackToMenu();
                return;
            }

            Console.WriteLine("\nInsert the index of the book to delete: ");

            int input = 1;
            try
            {
                input = int.Parse(Console.ReadLine());
                if (input > books.Count() || input < 0)
                {
                    throw new Exception();
                }
            } catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Invalid input, please try again.\n ");
                
                DeleteBook();
            }
           

            Console.Clear();
            Console.WriteLine($"The book '{books.GetOne(input - 1)}' has been removed.\n");

            books.Remove(input - 1);

            books.PrintAll();

            BackToMenu();

        }

        static void SearchBooks()
        {
            Console.WriteLine("Insert a query to search by: ");
            string query = Console.ReadLine();

            var foundBooks = books.GetAll().FindAll(book => book.ToLower().Contains(query.ToLower()));

            if (foundBooks.Count == 0)
            {
                Console.WriteLine($"No books have been found for query '{query}'");
            } else
            {
                Console.WriteLine($"All books found by query '{query}':");
                for (int i = 0; i < foundBooks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {foundBooks[i]}");
                }
            }
            
            BackToMenu();
        }
        

        static void Main(string[] args)
        {
            books = new BookCollection();
            ShowOptions();
        }
    }
}
