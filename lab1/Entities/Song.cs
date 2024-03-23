using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace lab1.Entities;

[Table("Song")]
public class Song   
{
    [PrimaryKey, AutoIncrement, Indexed]
    public int Id { get; set; }
    [Indexed]
    public int GroupId { get; set; }
    public string SongName {  get; set; }
    public string GroupName { get; set; }
    public int PublicationYear { get; set; }
}
