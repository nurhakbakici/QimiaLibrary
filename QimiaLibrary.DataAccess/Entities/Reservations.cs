using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.DataAccess.Entities;

public class Reservations
{
    public int ReservationID { get; set; }
    public int WorkerID { get; set; }
    public int BookID { get; set; }
    public DateTime ReservationDate { get; set; }
    public DateTime ReturnDate { get; set; }

    public Workers Workers { get; set; }
    public Books Books { get; set; }
}