using LapShop.Bl;
using LapShop.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LapShop.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        ISettings oClsSettings;
        public SettingController(ISettings oISettings)
        {
            oClsSettings=oISettings;
        }
        // GET: api/<SettingController>
        [HttpGet]
        public TbSettings Get()
        {
            var oSeeting= oClsSettings.GetAll();
            return oSeeting;
        }

        // GET api/<SettingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SettingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SettingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SettingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
