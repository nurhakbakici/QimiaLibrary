using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Commands.Reservations.ReservationDtos;

public class UpdateReservationDto
{
    public int WorkerId { get; set; }
    public int BookId { get; set; }
    public int RStatusId { get; set; }
}
