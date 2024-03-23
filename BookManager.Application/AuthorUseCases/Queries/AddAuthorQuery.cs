namespace BookManager.App.AuthorUseCases.Queries;

public record AddAuthorQuery : IRequest<int>
{
    public AddAuthorQuery(string name, string surname, DateTime dateOfBirth, DateTime dateOfDeath)
    {
        Name = name;
        Surname = surname;
        DateOfBirth = dateOfBirth;
        DateOfDeath = dateOfDeath;
    }

    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime DateOfDeath { get; set; }
}
