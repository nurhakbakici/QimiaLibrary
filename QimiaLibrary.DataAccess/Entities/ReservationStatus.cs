using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.DataAccess.Entities;

public class ReservationStatus
{
    public int RStatusID { get; set; }
    public string RStatusName { get; set; }
}
