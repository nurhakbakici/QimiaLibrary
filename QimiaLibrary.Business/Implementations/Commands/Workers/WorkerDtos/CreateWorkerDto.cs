using QimiaLibrary.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Commands.Workers.WorkerDtos;

public class CreateWorkerDto 
{
    public string? FirstMidName { get; set; }
    public string? LastName { get; set; }
    public WorkerStatus? WorkerStatus { get; set; }
}
