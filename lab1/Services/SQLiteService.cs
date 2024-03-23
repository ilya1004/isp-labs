using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab1.Entities;

namespace lab1.Services;

public class SQLiteService : IDbService
{
    private SQLiteConnection? _database;

    public SQLiteService(string dbpath)
    {
        _database = new SQLiteConnection(dbpath);
        _database.DropTable<Group>();
        _database.DropTable<Song>();
        _database.CreateTable<Group>();
        _database.CreateTable<Song>();
        Init();
    }

    public IEnumerable<Group> GetAllGroups()
    {
        return _database.Table<Group>().ToList();
    }
             
    public IEnumerable<Song> GetSongsByGroup(int id)
    {
        return _database.Table<Song>().Where(s => s.GroupId == id).ToList();
    }

    public void Init()
    {
        if (_database != null)
        {
            _database.Insert(new Group()
            {
                GroupName = "Metallica",
                Country = "USA",
                YearFormed = 1981
            });
            _database.Insert(new Group()
            {
                GroupName = "Rammstein",
                Country = "Germany",
                YearFormed = 1994
            });
            _database.Insert(new Group()
            {
                GroupName = "Кино",
                Country = "СССР",
                YearFormed = 1981
            });
            

            _database.Insert(new Song()
            {
                GroupId = 1,
                GroupName = "Metallica",
                SongName = "Enter Sandman",
                PublicationYear = 1991
            });
            _database.Insert(new Song()
            {
                GroupId = 1,
                GroupName = "Metallica",
                SongName = "Nothing Else Matters",
                PublicationYear = 1992
            });
            _database.Insert(new Song()
            {
                GroupId = 1,
                GroupName = "Metallica",
                SongName = "Master Of Puppets",
                PublicationYear = 1986
            });
            _database.Insert(new Song()
            {
                GroupId = 1,
                GroupName = "Metallica",
                SongName = "Better Than You",
                PublicationYear = 1997
            });
            _database.Insert(new Song()
            {
                GroupId = 1,
                GroupName = "Metallica",
                SongName = "Fade to Black",
                PublicationYear = 1984
            });
            _database.Insert(new Song()
            {
                GroupId = 1,
                GroupName = "Metallica",
                SongName = "The Unforgiven",
                PublicationYear = 1991
            });


            _database.Insert(new Song()
            {
                GroupId = 1,
                GroupName = "Rammstein",
                SongName = "Du hast",
                PublicationYear = 1997
            });
            _database.Insert(new Song()
            {
                GroupId = 1,
                GroupName = "Rammstein",
                SongName = "Deutschland",
                PublicationYear = 2019
            });
            _database.Insert(new Song()
            {
                GroupId = 1,
                GroupName = "Rammstein",
                SongName = "Radio",
                PublicationYear = 2019
            });
            _database.Insert(new Song()
            {
                GroupId = 1,
                GroupName = "Rammstein",
                SongName = "Du riechst so gut",
                PublicationYear = 1995
            });
            _database.Insert(new Song()
            {
                GroupId = 1,
                GroupName = "Rammstein",
                SongName = "Ohne dich",
                PublicationYear = 2011
            });
            _database.Insert(new Song()
            {
                GroupId = 1,
                GroupName = "Rammstein",
                SongName = "Wo bist du",
                PublicationYear = 2005
            });


            _database.Insert(new Song()
            {
                GroupId = 1,
                GroupName = "Кино",
                SongName = "Восьмиклассница",
                PublicationYear = 1992
            });
            _database.Insert(new Song()
            {
                GroupId = 1,
                GroupName = "Кино",
                SongName = "Группа крови",
                PublicationYear = 1988
            });
            _database.Insert(new Song()
            {
                GroupId = 1,
                GroupName = "Кино",
                SongName = "Звезда по имени Солнце",
                PublicationYear = 1989
            });
            _database.Insert(new Song()
            {
                GroupId = 1,
                GroupName = "Кино",
                SongName = "Кончится лето",
                PublicationYear = 1990
            });
            _database.Insert(new Song()
            {
                GroupId = 1,
                GroupName = "Кино",
                SongName = "Хочу перемен!",
                PublicationYear = 1989
            });
            _database.Insert(new Song()
            {
                GroupId = 1,
                GroupName = "Кино",
                SongName = "Кукушка",
                PublicationYear = 1991
            });
            _database.Insert(new Song()
            {
                GroupId = 1,
                GroupName = "Кино",
                SongName = "Пачка сигарет",
                PublicationYear = 1986
            });

            _database.Insert(new Song()
            {
                GroupId = 1,
                GroupName = "Кино",
                SongName = "Фильмы",
                PublicationYear = 1986
            });
            _database.Insert(new Song()
            {
                GroupId = 1,
                GroupName = "Кино",
                SongName = "Спокойная ночь",
                PublicationYear = 1988
            });
        }
    }
}
