using Labmidexam;
using System;

class Start
{
    static void Main(string[] args)
    {
        StoryBook[] storyBooks = new StoryBook[5];
        TextBook[] textBooks = new TextBook[5];
        BookShop bookShop = new BookShop();

        Console.WriteLine("Welcome to the Book Shop!");

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Remove a book");
            Console.WriteLine("3. Show all books");
            Console.WriteLine("4. Search for a book");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            int option=int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    AddBook(storyBooks, textBooks, bookShop);
                    break;
                case 2:
                    RemoveBook(storyBooks, textBooks, bookShop);
                    break;
                case 3:
                    ShowAllBooks(bookShop);
                    break;
                case 4:
                    SearchBook(bookShop);
                    break;
                case 5:
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
        }
    }

    static void AddBook(StoryBook[] storyBooks, TextBook[] textBooks, BookShop bookShop)
    {
        Console.WriteLine("\nAdding a book...");
        Console.WriteLine("Choose book type:");
        Console.WriteLine("1. Story Book");
        Console.WriteLine("2. Text Book");
        Console.Write("Enter your choice: ");
        int choice=int.Parse(Console.ReadLine());
        if ((choice != 1 && choice != 2))
        {
            Console.WriteLine("Invalid choice. Please enter 1 or 2.");
            return;
        }

        Console.Write("ISBN: ");
        string isbn = Console.ReadLine();
        Console.Write("Title: ");
        string title = Console.ReadLine();
        Console.Write("Author: ");
        string author = Console.ReadLine();
        Console.Write("Price: ");
        string priceInput = Console.ReadLine();
        double price=Double.Parse(priceInput);
        Console.Write("Available Quantity: ");
        string Quantity=Console.ReadLine();
        int quantity=int.Parse(Quantity);

        if (choice == 1)
        {
            Console.Write("Category: ");
            string category = Console.ReadLine();
            StoryBook storyBook = new StoryBook(isbn, title, author, price, quantity, category);
            bookShop.insertBook(storyBook);
        }
        else if (choice == 2)
        {
            Console.Write("Standard: ");
            int standard=int.Parse(Console.ReadLine());
            TextBook textBook = new TextBook(isbn, title, author, price, quantity, standard);
            bookShop.insertBook(textBook);
        }

        Console.WriteLine("Book added successfully.");
    }

    static void RemoveBook(StoryBook[] storyBooks, TextBook[] textBooks, BookShop bookShop)
    {
        Console.WriteLine("\nRemoving a book...");
        Console.Write("Enter ISBN of the book to remove: ");
        string isbn = Console.ReadLine();
        Book book = bookShop.searchBook(isbn);
        if (book != null)
        {
            bookShop.removeBook(book);
            Console.WriteLine("Book removed successfully.");
        }
        else
        {
            Console.WriteLine("Book not found in the shop.");
        }
    }

    static void ShowAllBooks(BookShop bookShop)
    {
        Console.WriteLine("\nShowing all books...");
        bookShop.showAllBooks();
    }

    static void SearchBook(BookShop bookShop)
    {
        Console.WriteLine("\nSearching for a book...");
        Console.Write("Enter ISBN to search for a book: ");
        string searchIsbn = Console.ReadLine();
        Book searchedBook = bookShop.searchBook(searchIsbn);
        if (searchedBook != null)
        {
            Console.WriteLine("Book found:");
            //bookShop.showDetails(searchedBook);
        }
        else
        {
            Console.WriteLine("Book not found in the shop.");
        }
    }
}
