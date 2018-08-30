using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VFS.Common.Models.Masters;
using VFS.MicroServices.MDM.Repository;

namespace VFS.MicroServices.MDM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : Controller
    {
        //private readonly ApplicationContext _context;
        private IDataRepository<Country, int> _iRepo;

        public CountriesController(IDataRepository<Country, int> repo)
        {
            _iRepo = repo;
        }
        [HttpGet]
        public IEnumerable<Country> Get()
        {
            return _iRepo.GetAll();
        }

        [HttpGet("{id}")]
        public Country Get(int id)
        {
            return _iRepo.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]Country country)
        {
            _iRepo.Add(country);
        }

        [HttpPut]
        public void Put([FromBody]Country country)
        {
            _iRepo.Update(country.Id, country);
        }

        [HttpDelete("{id}")]
        public long Delete(int id)
        {
            return _iRepo.Delete(id);
        }
    }
}