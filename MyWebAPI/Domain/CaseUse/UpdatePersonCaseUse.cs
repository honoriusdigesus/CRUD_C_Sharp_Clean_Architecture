using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI.Domain.CaseUse
{
    public class UpdatePersonCaseUse
    {
        private readonly MyWebAPI.Data.MyDbContext.AppDbContext _context;
        private readonly MyWebAPI.Domain.Mappers.PersonMapperDomain _personMapperDomain;

        public UpdatePersonCaseUse(
            MyWebAPI.Data.MyDbContext.AppDbContext context, 
            MyWebAPI.Domain.Mappers.PersonMapperDomain personMapperDomain)
        {
            _context = context;
            _personMapperDomain = personMapperDomain;
        }


        public async Task<MyWebAPI.Domain.Entity.PersonDomain> Update([FromBody]MyWebAPI.Domain.Entity.PersonDomain person, int Id)
        {
            if (person == null) {
                throw new ArgumentNullException(nameof(person));
            }
            if (Id < 0) {
                throw new ArgumentNullException(nameof(Id));
            }
            await Task.CompletedTask;
            var personEntity = _personMapperDomain.ToEntity(person);
            var personToUpdate = _context.Persons.FirstOrDefault(p => p.Id == Id);
            if (personToUpdate == null) {
                throw new ArgumentNullException(nameof(personToUpdate));
            }
            personToUpdate.Name = personEntity.Name;
            personToUpdate.LastName = personEntity.LastName;
            personToUpdate.Email = personEntity.Email;
            personToUpdate.Phone = personEntity.Phone;
            personToUpdate.Address = personEntity.Address;
            await _context.SaveChangesAsync();
            return _personMapperDomain.ToDomain(personToUpdate);
        }
    }
}
