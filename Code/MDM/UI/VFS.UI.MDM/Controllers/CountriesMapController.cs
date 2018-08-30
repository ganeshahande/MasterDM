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
    public class CountriesMapController : Controller
    {
        APIClientHelper _CountryMapAPI = new APIClientHelper();
        public async Task<IActionResult> Index()
        {
            List<MstcountryMap> dto = new List<MstcountryMap>();

            HttpClient client = _CountryMapAPI.InitializeClient();

            HttpResponseMessage res = await client.GetAsync("api/CountriesMap");

            //CHECKING THE RESPONSE IS SUCCESSFUL OR NOT WHICH IS SENT USING HTTPCLIENT  
            if (res.IsSuccessStatusCode)
            {
                //STORING THE RESPONSE DETAILS RECIEVED FROM WEB API   
                var result = res.Content.ReadAsStringAsync().Result;

                //DESERIALIZING THE RESPONSE RECIEVED FROM WEB API AND STORING INTO THE LIST  
                dto = JsonConvert.DeserializeObject<List<MstcountryMap>>(result);

            }
            //RETURNING THE LIST TO VIEW  
            return View(dto);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<MstcountryMap> dto = new List<MstcountryMap>();
            HttpClient client = _CountryMapAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("api/CountriesMap");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                dto = JsonConvert.DeserializeObject<List<MstcountryMap>>(result);
            }

            var mstcountryMap = dto.SingleOrDefault(m => m.Id == id);
            if (mstcountryMap == null)
            {
                return NotFound();
            }
            
            return View(mstcountryMap);
        }


    }

}
