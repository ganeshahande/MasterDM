using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VFS.Common.Models.Masters;
using VFS.MicroServices.MDM.Repository;

namespace VFS.MicroServices.MDM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesMapController : Controller
    {
        private IDataRepository<MstcountryMap, int> _iRepo;

        public CountriesMapController(IDataRepository<MstcountryMap, int> repo)
        {
            _iRepo = repo;
        }
        [HttpGet]
        public IEnumerable<MstcountryMap> Get()
        {
            return _iRepo.GetAll();
        }
        [HttpGet("{id}")]
        public MstcountryMap Get(int id)
        {
            return _iRepo.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]MstcountryMap countryMap)
        {
            _iRepo.Add(countryMap);
        }

        [HttpPut]
        public void Put([FromBody]MstcountryMap countryMap)
        {
            _iRepo.Update(countryMap.Id, countryMap);
        }

        [HttpDelete("{id}")]
        public long Delete(int id)
        {
            return _iRepo.Delete(id);
        }
    }
}