using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace lab1.Entities;

[Table("Performer")]
public class Group
{
    [PrimaryKey, AutoIncrement, Indexed]
    public int Id { get; set; }
    public string GroupName { get; set; }
    public string? Country { get; set; }
    public int? YearFormed { get; set; }
}
