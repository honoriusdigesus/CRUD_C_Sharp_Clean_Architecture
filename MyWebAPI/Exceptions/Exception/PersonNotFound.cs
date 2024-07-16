namespace MyWebAPI.Exceptions.Exception
{
    public class PersonNotFound: System.Exception
    {
        public PersonNotFound(string message) : base(message) { }
}
}
