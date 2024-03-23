using System.Net;

namespace BookManager.Domain.Entities;

public class Author : Entity
{
    public Author() { }
    public Author(int id, string name, string surname, DateTime dateOfBirth, DateTime dateOfDeath)
    {
        Id = id;
        Name = name;
        Surname = surname;
        DateOfBirth = dateOfBirth;
        DateOfDeath = dateOfDeath;
        Books = [];
    }

    public string Name { get; private set; } = string.Empty;
    public string Surname { get; private set; } = string.Empty;
    public DateTime DateOfBirth { get; private set; }
    public DateTime DateOfDeath { get; private set; }
    public List<Book> Books { get; private set; } = [];

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public string GetLifeYears()
    {
        return $"{DateOfBirth.Year} - {DateOfDeath.Year}";
    }

    public string GetFullName()
    {
        return $"{Name} {Surname}";
    }

}
