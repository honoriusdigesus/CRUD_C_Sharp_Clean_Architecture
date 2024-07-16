using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Domain.Mappers;

namespace MyWebAPI.Presentter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private Domain.UseCase.GetAllPersonCaseUse _getAllPersonCaseUse;
        private Presentter.Mappers.PersonMapperPresenter _personMapper;

        public PersonController(Domain.UseCase.GetAllPersonCaseUse getAllPersonCaseUse, Presentter.Mappers.PersonMapperPresenter personMapper)
        {
            _getAllPersonCaseUse = getAllPersonCaseUse;
            _personMapper = personMapper;
        }

        [HttpGet]
        public IEnumerable<Presentter.Entity.PersonPresenter> Get()
        {
            var persons = _getAllPersonCaseUse.GetAll();
            return persons.Select(p => _personMapper.ToPresenter(p)); ;
        }
    }
}
