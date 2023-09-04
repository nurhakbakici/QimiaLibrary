using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.DataAccess.Entities;

public class Books
{
    public int BookID { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int Count { get; set; }
    public int BStatusID { get; set; }

    public BookStatus BookStatus { get; set; }
    public Reservations Reservations { get; set; }
}