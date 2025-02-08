using konyvtar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace konyvtar.Pages;

public class BooksModel : PageModel
    {
        private readonly string _csvFilePath = "books.csv";

        public List<Book> Books { get; set; }

        [BindProperty]
        public Book NewBook { get; set; }

        public void OnGet()
        {
            Books = ReadBooksFromCsv();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Books = ReadBooksFromCsv();
                return Page();
            }

            await AppendBookToCsvAsync(NewBook);
            return RedirectToPage();
        }

        private List<Book> ReadBooksFromCsv()
        {
            var books = new List<Book>();
            var lines = System.IO.File.ReadAllLines(_csvFilePath).Skip(1);

            foreach (var line in lines)
            {
                var values = line.Split(',');
                books.Add(new Book
                {
                    Title = values[0],
                    Author = values[1],
                    PublicationYear = int.Parse(values[2])
                });
            }

            return books;
        }
        private async Task AppendBookToCsvAsync(Book book)
        {
            var line = $"{book.Title},{book.Author},{book.PublicationYear}";
            await System.IO.File.AppendAllTextAsync(_csvFilePath, Environment.NewLine + line);
        }
    }
