using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Domain.Mappers;

namespace MyWebAPI.Presentter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly Domain.UseCase.GetAllPersonCaseUse _getAllPersonCaseUse;

        private readonly Presentter.Mappers.PersonMapperPresenter _personMapper;

        private readonly Domain.UseCase.CreatePersonCaseUse _createPersonCaseUse;

        public PersonController(Domain.UseCase.GetAllPersonCaseUse getAllPersonCaseUse, Domain.UseCase.CreatePersonCaseUse createPersonCaseUse, Presentter.Mappers.PersonMapperPresenter personMapper)
        {
            _getAllPersonCaseUse = getAllPersonCaseUse;
            _createPersonCaseUse = createPersonCaseUse;
            _personMapper = personMapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Presentter.Entity.PersonPresenter>> Get()
        {
            await Task.CompletedTask;
            var persons = await _getAllPersonCaseUse.GetAll();
            return persons.Select(p => _personMapper.ToPresenter(p));
        }

        [HttpPost]
        public async Task<Presentter.Entity.PersonPresenter> Post(Presentter.Entity.PersonPresenter person)
        {
            await Task.CompletedTask;
            var personPresenter = _personMapper.ToDomain(person);
            var personCreated = await _createPersonCaseUse.Create(personPresenter);
            return _personMapper.ToPresenter(personCreated);
        }

    }
}
