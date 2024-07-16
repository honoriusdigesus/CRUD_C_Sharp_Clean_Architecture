namespace MyWebAPI.Domain.UseCase
{
    public class GetAllPersonCaseUse
    {
        //Inject the DbContext
        private MyWebAPI.Data.MyDbContext.AppDbContext _context;
        private MyWebAPI.Domain.Mappers.PersonMapperDomain _personMapperDomain;

        public GetAllPersonCaseUse(MyWebAPI.Data.MyDbContext.AppDbContext context, MyWebAPI.Domain.Mappers.PersonMapperDomain personMapperDomain)
        {
            _context = context;
            _personMapperDomain = personMapperDomain;
        }

        //Get all persons
        public IEnumerable<MyWebAPI.Domain.Entity.PersonDomain> GetAll()
        {
            var persons = _context.Persons.ToList();
            return persons.Select(p => _personMapperDomain.ToDomain(p));
        }
    }
}
