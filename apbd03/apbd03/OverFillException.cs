namespace apbd03;


public class OverFillException : Exception
{
    
    public OverFillException(string message) : base(message)
    {
    }
    
    
    public override string ToString()
    {
        return Message;
    }
}