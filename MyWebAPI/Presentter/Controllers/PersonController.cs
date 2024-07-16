using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Domain.Mappers;

namespace MyWebAPI.Presentter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly Domain.CaseUse.GetAllPersonCaseUse _getAllPersonCaseUse;
        private readonly Presentter.Mappers.PersonMapperPresenter _personMapper;
        private readonly Domain.CaseUse.CreatePersonCaseUse _createPersonCaseUse;

        public PersonController(
            Domain.CaseUse.GetAllPersonCaseUse getAllPersonCaseUse,
            Presentter.Mappers.PersonMapperPresenter personMapper,
            Domain.CaseUse.CreatePersonCaseUse createPersonCaseUse)
        {
            _getAllPersonCaseUse = getAllPersonCaseUse;
            _personMapper = personMapper;
            _createPersonCaseUse = createPersonCaseUse;
        }

        [HttpGet]
        public async Task<IEnumerable<Presentter.Entity.PersonPresenter>> Get()
        {
            await Task.CompletedTask;
            var persons = await _getAllPersonCaseUse.GetAll();
            return persons.Select(p => _personMapper.ToPresenter(p));
        }

        [HttpPost]
        public async Task<Presentter.Entity.PersonPresenter> Post([FromBody]Presentter.Entity.PersonPresenter person)
        {
            await Task.CompletedTask;
            var personPresenter = _personMapper.ToDomain(person);
            var personCreated = await _createPersonCaseUse.Create(personPresenter);
            return _personMapper.ToPresenter(personCreated);
        }

    }
}
