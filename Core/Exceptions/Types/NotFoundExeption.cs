using System.Runtime.Serialization;

namespace Core.Exceptions.Types;

public class NotFoundExeption : Exception
{
    public NotFoundExeption() { }

    protected NotFoundExeption(SerializationInfo info, StreamingContext context) : base(info, context) { }
    public NotFoundExeption(string? message) : base(message) { }
    public NotFoundExeption(string? message, Exception? exception) : base(message, exception) { }

}
