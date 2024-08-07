﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Domain.Mappers;

namespace MyWebAPI.Presentter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly Domain.CaseUse.GetAllPersonCaseUse _getAllPersonCaseUse;
        private readonly Domain.CaseUse.CreatePersonCaseUse _createPersonCaseUse;
        private readonly Domain.CaseUse.UpdatePersonCaseUse _updatePersonCaseUse;
        private readonly Domain.CaseUse.GetByIdPersonCaseUse _getByIdPersonCaseUse;
        private readonly Domain.CaseUse.DeletePersonByIdCaseUse _deletePersonByIdCaseUse;
        private readonly Presentter.Mappers.PersonMapperPresenter _personMapper;

        public PersonController(
            Domain.CaseUse.GetAllPersonCaseUse getAllPersonCaseUse,
            Domain.CaseUse.CreatePersonCaseUse createPersonCaseUse,
            Domain.CaseUse.UpdatePersonCaseUse updatePersonCaseUse,
            Domain.CaseUse.GetByIdPersonCaseUse getByIdPersonCaseUse,
            Domain.CaseUse.DeletePersonByIdCaseUse deletePersonByIdCaseUse,
            Presentter.Mappers.PersonMapperPresenter personMapper)
        {
            _getAllPersonCaseUse = getAllPersonCaseUse;
            _createPersonCaseUse = createPersonCaseUse;
            _updatePersonCaseUse = updatePersonCaseUse;
            _getByIdPersonCaseUse = getByIdPersonCaseUse;
            _deletePersonByIdCaseUse = deletePersonByIdCaseUse;
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
        public async Task<Presentter.Entity.PersonPresenter> Post([FromBody]Presentter.Entity.PersonPresenter person)
        {
            await Task.CompletedTask;
            var personPresenter = _personMapper.ToDomain(person);
            var personCreated = await _createPersonCaseUse.Create(personPresenter);
            return _personMapper.ToPresenter(personCreated);
        }

        [HttpPut("{id}")]
        public async Task<Presentter.Entity.PersonPresenter> Put(int id, [FromBody]Presentter.Entity.PersonPresenter person)
        {
            await Task.CompletedTask;
            var personPresenter = _personMapper.ToDomain(person);
            var personUpdated = await _updatePersonCaseUse.Update(personPresenter, id);
            return _personMapper.ToPresenter(personUpdated);
        }

        [HttpGet("{id}")]
        public async Task<Presentter.Entity.PersonPresenter> Get(int id)
        {
            await Task.CompletedTask;
            var person = await _getByIdPersonCaseUse.GetById(id);
            return _personMapper.ToPresenter(person);
        }

        [HttpDelete("{id}")]
        public async Task<Presentter.Entity.PersonPresenter> Delete(int id)
        {
            await Task.CompletedTask;
            var person = await _deletePersonByIdCaseUse.DeleteById(id);
            return _personMapper.ToPresenter(person);
        }

    }
}
