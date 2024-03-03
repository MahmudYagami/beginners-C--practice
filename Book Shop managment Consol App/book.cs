using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labmidexam
{
    class Book
    {
        private string isbn;
        private string bookTitle;
        private string authorName;
        private double price;
        private int availableQuantity;

        public Book() { }

        public Book(string isbn, string bookTitle, string authorName, double price, int availableQuantity)
        {
            this.isbn = isbn;
            this.bookTitle = bookTitle;
            this.authorName = authorName;
            this.price = price;
            this.availableQuantity = availableQuantity;
        }

        public void setIsbn(string isbn) { this.isbn = isbn; }
        public void setBookTitle(string bookTitle) { this.bookTitle = bookTitle; }
        public void setAuthorName(string authorName) { this.authorName = authorName; }
        public void setPrice(double price) { this.price = price; }
        public void setAvailableQuantity(int availableQuantity) { this.availableQuantity = availableQuantity; }

        public string getIsbn() { return isbn; }
        public string getBookTitle() { return bookTitle; }
        public string getAuthorName() { return authorName; }
        public double getPrice() { return price; }
        public int getAvailableQuantity() { return availableQuantity; }

        public void addQuantity(int amount) { availableQuantity += amount; }
        public void sellQuantity(int amount) { availableQuantity -= amount; }

        public void showDetails(Book b)
        {
            Console.WriteLine($"ISBN: {b.getIsbn()}");
            Console.WriteLine($"Title: {b.getBookTitle()}");
            Console.WriteLine($"Author: {b.getAuthorName()}");
            Console.WriteLine($"Price: {b.getPrice()}");
            Console.WriteLine($"Available Quantity: {b.getAvailableQuantity()}");

            if (b is StoryBook)
            {
                StoryBook storyBook = (StoryBook)b;
                Console.WriteLine($"Category: {storyBook.getCategory()}");
            }
            else if (b is TextBook)
            {
                TextBook textBook = (TextBook)b;
                Console.WriteLine($"Standard: {textBook.getStandard()}");
            }
        }

    }

    class StoryBook : Book
    {
        private string category;

        public StoryBook() { }

        public StoryBook(string isbn, string bookTitle, string authorName, double price, int availableQuantity, string category)
            : base(isbn, bookTitle, authorName, price, availableQuantity)
        {
            this.category = category;
        }

        public void setCategory(string category) { this.category = category; }
        public string getCategory() { return category; }
    }

    class TextBook : Book
    {
        private int standard;

        public TextBook() { }

        public TextBook(string isbn, string bookTitle, string authorName, double price, int availableQuantity, int standard)
            : base(isbn, bookTitle, authorName, price, availableQuantity)
        {
            this.standard = standard;
        }

        public void setStandard(int standard) { this.standard = standard; }
        public int getStandard() { return standard; }
    }

    class BookShop
    {
        private string name;
        private Book[] books = new Book[100];
        private int bookCount = 0;

        public BookShop() { }

        public BookShop(string name)
        {
            this.name = name;
        }

        public void setName(string name) { this.name = name; }
        public string getName() { return name; }

        public bool insertBook(Book b)
        {
            if (bookCount < 100)
            {
                books[bookCount++] = b;
                return true;
            }
            else
            {
                Console.WriteLine("BookShop is full. Cannot insert more books.");
                return false;
            }
        }

        public bool removeBook(Book b)
        {
            for (int i = 0; i < bookCount; i++)
            {
                if (books[i] == b)
                {
                    for (int j = i; j < bookCount - 1; j++)
                    {
                        books[j] = books[j + 1];
                    }
                    books[bookCount - 1] = null;
                    bookCount--;
                    return true;
                }
            }
            Console.WriteLine("Book not found in the shop.");
            return false;
        }

        public void showAllBooks()
        {
            foreach (Book book in books)
            {
                if (book != null)
                {
                    book.showDetails(book);
                    Console.WriteLine();
                }
            }
        }

        public Book searchBook(string isbn)
        {
            foreach (Book book in books)
            {
                if (book != null && book.getIsbn() == isbn)
                {
                    return book;
                }
            }
            Console.WriteLine("Book not found in the shop.");
            return null;
        }
    }
}
