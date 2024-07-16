namespace MyWebAPI.Presentter.Mappers
{
    public class PersonMapperPresenter
    {
        //From Domain to Presenter
        public Entity.PersonPresenter ToPresenter(MyWebAPI.Domain.Entity.PersonDomain personDomain)
        {
            return new Entity.PersonPresenter
            {
                Id = personDomain.Id,
                Name = personDomain.Name,
                LastName = personDomain.LastName,
                Email = personDomain.Email,
                Phone = personDomain.Phone,
                Address = personDomain.Address
            };
        }

        //From Presenter to Domain
        public MyWebAPI.Domain.Entity.PersonDomain ToDomain(Entity.PersonPresenter personPresenter)
        {
            return new MyWebAPI.Domain.Entity.PersonDomain
            {
                Id = personPresenter.Id,
                Name = personPresenter.Name,
                LastName = personPresenter.LastName,
                Email = personPresenter.Email,
                Phone = personPresenter.Phone,
                Address = personPresenter.Address
            };
        }
    }
}
