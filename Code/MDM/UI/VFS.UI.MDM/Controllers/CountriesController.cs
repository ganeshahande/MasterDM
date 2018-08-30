using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Linq;
using Newtonsoft.Json;
using VFS.Common.Models.Masters;

namespace VFS.UI.MDM.Controllers
{
    public class CountriesController : Controller
    {
        APIClientHelper _CountryAPI = new APIClientHelper();

        public async Task<IActionResult> Index()
        {
            List<Country> dto = new List<Country>();

            HttpClient client = _CountryAPI.InitializeClient();

            HttpResponseMessage res = await client.GetAsync("api/Countries");

            //CHECKING THE RESPONSE IS SUCCESSFUL OR NOT WHICH IS SENT USING HTTPCLIENT  
            if (res.IsSuccessStatusCode)
            {
                //STORING THE RESPONSE DETAILS RECIEVED FROM WEB API   
                var result = res.Content.ReadAsStringAsync().Result;

                //DESERIALIZING THE RESPONSE RECIEVED FROM WEB API AND STORING INTO THE LIST  
                dto = JsonConvert.DeserializeObject<List<Country>>(result);

            }
            //RETURNING THE LIST TO VIEW  
            return View(dto);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Code,Isocode2,Isocode3,DialCode,Nationality")] Country country)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _CountryAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(country), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PostAsync("api/Countries", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(country);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<Country> dto = new List<Country>();
            HttpClient client = _CountryAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("api/Countries");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                dto = JsonConvert.DeserializeObject<List<Country>>(result);
            }

            var country = dto.SingleOrDefault(m => m.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("Id,Name,Code,Isocode2,Isocode3,DialCode,Nationality")] Country country)
        {
            if (id != country.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                HttpClient client = _CountryAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(country), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PutAsync("api/Countries", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(country);
        }

    }
}