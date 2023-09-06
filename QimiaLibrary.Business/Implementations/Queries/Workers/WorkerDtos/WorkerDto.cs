using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Queries.Workers.WorkerDtos;

public class WorkerDto
{
    public int WorkerId { get; set; }
    public string? FirstMidName { get; set; }
    public string? LastName { get; set; }
    public int WStatusID { get; set; }
}
