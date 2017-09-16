using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Platform.Services.UserService.Models;

namespace Platform.Services.UserService.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {

        private readonly WebApiDataContext _context;

        public UsersController(WebApiDataContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public IEnumerable<Models.Users> GetUsers()
        //{
        //    return _context.Users.ToList();
        //}
        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
