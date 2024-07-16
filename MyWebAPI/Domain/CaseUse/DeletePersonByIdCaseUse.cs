namespace MyWebAPI.Domain.CaseUse
{
    public class DeletePersonByIdCaseUse
    {
        private readonly MyWebAPI.Data.MyDbContext.AppDbContext _context;
        private readonly MyWebAPI.Domain.Mappers.PersonMapperDomain _personMapperDomain;

        public DeletePersonByIdCaseUse(
            MyWebAPI.Data.MyDbContext.AppDbContext context, 
            MyWebAPI.Domain.Mappers.PersonMapperDomain personMapperDomain)
        {
            _context = context;
            _personMapperDomain = personMapperDomain;
        }

        public async Task<MyWebAPI.Domain.Entity.PersonDomain> DeleteById(int Id)
        {
            if (Id < 0) {
                throw new Exceptions.Exception.PersonIdInvalid("El id no debe ser menor a cero o nulo");
            }
            await Task.CompletedTask;
            var person = _context.Persons.FirstOrDefault(p => p.Id == Id);
            if (person == null) {
                throw new Exceptions.Exception.PersonNotFound("Persona no encontrada");
            }
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return _personMapperDomain.ToDomain(person);
        }
    }
}
