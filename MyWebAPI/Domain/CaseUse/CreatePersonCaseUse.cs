namespace MyWebAPI.Domain.CaseUse
{
    public class CreatePersonCaseUse
    {
        private readonly MyWebAPI.Data.MyDbContext.AppDbContext _context;
        private readonly MyWebAPI.Domain.Mappers.PersonMapperDomain _personMapperDomain;

        public CreatePersonCaseUse(
            MyWebAPI.Data.MyDbContext.AppDbContext context, 
            MyWebAPI.Domain.Mappers.PersonMapperDomain personMapperDomain)
        {
            _context = context;
            _personMapperDomain = personMapperDomain;
        }

        public async Task<MyWebAPI.Domain.Entity.PersonDomain> Create(MyWebAPI.Domain.Entity.PersonDomain person)
        {
            if (person == null) {
                throw new Exceptions.Exception.PersonException("Faltan datos personales en la solicitud.");
            }
            else { 
            await Task.CompletedTask;
            var personEntity = _personMapperDomain.ToEntity(person);
            _context.Persons.Add(personEntity);
            await _context.SaveChangesAsync();
            return _personMapperDomain.ToDomain(personEntity);
            }
        }
    }
}
