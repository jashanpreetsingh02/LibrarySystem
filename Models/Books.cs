using System;

namespace LibrarySystem.Models
{
    public class Books
    {
        public int Id { get; set; } // Unique identifier for each book
    }

    public class Book : Books
    {
        public string Title { get; set; }
        public string Authors { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }
        public string Status { get; set; } // Status of the book (e.g., "Available", "Borrowed")

        public Book(int id, string title, string authors, string isbn, string genre, string publisher, int publicationYear)
        {
            // Validation logic here
            this.Id = id;
            this.Title = title;
            this.Authors = authors;
            this.ISBN = isbn;
            this.Genre = genre;
            this.Publisher = publisher;
            this.PublicationYear = publicationYear;
            this.Status = "Available"; // Default status
        }
    }

    public class Borrow : Books, ILoan
    {
        public DateTime LoanDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public Book BorrowedBook { get; set; }

        public Borrow(Book book, DateTime loanDate, DateTime expectedReturnDate)
        {
            // Validation logic here
            this.BorrowedBook = book;
            this.LoanDate = loanDate;
            this.ExpectedReturnDate = expectedReturnDate;
        }

        public void BorrowItem(Users user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User cannot be null when borrowing an item.");
            if (BorrowedBook.Status != "Available")
                throw new InvalidOperationException("The book is not available for borrowing.");

            BorrowedBook.Status = "Borrowed"; // Update the status of the book
            LoanDate = DateTime.Now; // Set the loan date to now
            ExpectedReturnDate = DateTime.Now.AddDays(14); // Set the expected return date to two weeks from now

            // Here, ideally, you would persist these changes to a database
            SaveChanges(); // Hypothetical method to persist changes
        }

        private void SaveChanges()
        {
            // Here you would interact with your data access layer to save changes
            Console.WriteLine("Changes saved to database");
        }
    }
}
