using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HW3103.Models
{
    public class BookService
    {
        private List<Book> _books;
        private readonly string _jsonPath = "books.json"; // Шлях до файлу JSON

        public BookService()
        {
            LoadData();
        }

        private void LoadData()
        {
            if (File.Exists(_jsonPath))
            {
                string json = File.ReadAllText(_jsonPath);
                _books = JsonConvert.DeserializeObject<List<Book>>(json);
            }
            else
            {
                _books = new List<Book>();
            }
        }

        private void SaveData()
        {
            string json = JsonConvert.SerializeObject(_books, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(_jsonPath, json);
        }

        public List<Book> GetBooks()
        {
            return _books;
        }

        public Book GetBookById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public void AddBook(Book book)
        {
            book.Id = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(book);
            SaveData();
        }

        public void UpdateBook(Book book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Genre = book.Genre;
                existingBook.Publisher = book.Publisher;
                existingBook.Year = book.Year;
                SaveData();
            }
        }

        public void DeleteBook(int id)
        {
            var bookToRemove = _books.FirstOrDefault(b => b.Id == id);
            if (bookToRemove != null)
            {
                _books.Remove(bookToRemove);
                SaveData();
            }
        }
    }
}
