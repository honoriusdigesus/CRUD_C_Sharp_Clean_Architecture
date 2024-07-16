namespace MyWebAPI.Domain.CaseUse
{
    public class GetAllPersonCaseUse
    {
        //Inject the DbContext
        private readonly MyWebAPI.Data.MyDbContext.AppDbContext _context;
        private readonly MyWebAPI.Domain.Mappers.PersonMapperDomain _personMapperDomain;

        public GetAllPersonCaseUse(
            MyWebAPI.Data.MyDbContext.AppDbContext context, 
            MyWebAPI.Domain.Mappers.PersonMapperDomain personMapperDomain)
        {
            _context = context;
            _personMapperDomain = personMapperDomain;
        }

        //Get all persons
        public async Task<IEnumerable<MyWebAPI.Domain.Entity.PersonDomain>> GetAll()
        {
            await Task.CompletedTask;
            var persons = _context.Persons.ToList();
            return persons.Select(p => _personMapperDomain.ToDomain(p));
        }
    }
}
