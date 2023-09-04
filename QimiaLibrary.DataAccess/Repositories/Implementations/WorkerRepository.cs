using QimiaLibrary.DataAccess.Entities;
using QimiaLibrary.DataAccess.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.DataAccess.Repositories.Implementations;

public class WorkerRepository : RepositoryBase<Workers>, IWorkerRepository
{
    public WorkerRepository(QimiaLibraryDbContext dbContext) : base(dbContext, dbContext.Set<Workers>())
    {

    }
}