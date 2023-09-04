using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.DataAccess.Entities;

public class Workers
{
    public int WorkerID { get; set; }
    public string FirstMidName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int WStatusID { get; set; }

    public WorkerStatus WorkerStatus { get; set; }
    public ICollection<Reservations> Reservations { get; set; }    
}