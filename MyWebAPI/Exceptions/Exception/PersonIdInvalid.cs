namespace MyWebAPI.Exceptions.Exception
{
    public class PersonIdInvalid: System.Exception
    {
        public PersonIdInvalid(string message): base(message) { }
    }
}
