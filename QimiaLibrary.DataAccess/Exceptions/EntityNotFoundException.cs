using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.DataAccess.Exceptions;
[Serializable]
public class EntityNotFoundException<T> : Exception
{
    private readonly int id;

    public EntityNotFoundException()
    {
    }

    public EntityNotFoundException(int id)
    {
        this.id = id;
    }

    public EntityNotFoundException(string? message) : base(message)
    {
    }

    public EntityNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public int Id => id;
}