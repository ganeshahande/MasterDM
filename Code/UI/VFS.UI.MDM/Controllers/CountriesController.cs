using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using VFS.UI.MDM.Models;
namespace VFS.UI.MDM.Controllers
{
    public class CountriesController : Controller
    {
        CountryAPI _CountryAPI = new CountryAPI();
        
        public async Task<IActionResult> Index()
        {
            List<CountryDTO> dto = new List<CountryDTO>();

            HttpClient client = _CountryAPI.InitializeClient();

            HttpResponseMessage res = await client.GetAsync("api/Countries");

            //Checking the response is successful or not which is sent using HttpClient  
            if (res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var result = res.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  
                dto = JsonConvert.DeserializeObject<List<CountryDTO>>(result);

            }
            //returning the employee list to view  
            return View(dto);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Code,Isocode2,Isocode3,DialCode,Nationality")] CountryDTO countryDTO)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _CountryAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(countryDTO), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PostAsync("api/PutCountry", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(countryDTO);
        }

    }
}