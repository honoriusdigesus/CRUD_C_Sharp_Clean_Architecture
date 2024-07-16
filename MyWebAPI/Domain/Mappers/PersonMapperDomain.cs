using MyWebAPI.Data.Entity;

namespace MyWebAPI.Domain.Mappers
{
    public class PersonMapperDomain
    {
        //Convert Entity to Domain
        public Data.Entity.Person ToEntity(MyWebAPI.Domain.Entity.PersonDomain personDomain)
        {
            return new Data.Entity.Person
            {
                Id = personDomain.Id,
                Name = personDomain.Name,
                LastName = personDomain.LastName,
                Email = personDomain.Email,
                Phone = personDomain.Phone,
                Address = personDomain.Address
            };
        }

        //Convert Domain to Entity
        public MyWebAPI.Domain.Entity.PersonDomain ToDomain(Data.Entity.Person person)
        {
            return new MyWebAPI.Domain.Entity.PersonDomain
            {
                Id = person.Id,
                Name = person.Name,
                LastName = person.LastName,
                Email = person.Email,
                Phone = person.Phone,
                Address = person.Address
            };
        }
    }
}
