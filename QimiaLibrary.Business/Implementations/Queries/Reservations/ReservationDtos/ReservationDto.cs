using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Queries.Reservations.ReservationDtos;

public class ReservationDto
{
    public int ReservationID { get; set; }
    public int WorkerID { get; set; }
    public int BookID { get; set; } 
    public int RStatusID { get; set; }
    public DateTime ReservationDate { get; set; }
    public DateTime ReturnDate { get; set; }
}
