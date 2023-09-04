using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.DataAccess.Entities;

public class WorkerStatus
{
    public int WStatusID { get; set; }
    public string WStatusName { get; set; } = string.Empty;
}