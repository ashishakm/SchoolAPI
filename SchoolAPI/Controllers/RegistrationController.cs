using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SchoolAPI.Data;
using SchoolAPI.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    public class RegistrationController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext _context;
        public RegistrationController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationModel registrationmodel)
        {
            var user = await userManager.FindByNameAsync(registrationmodel.UserName);            
            if (user == null)
            {
                //var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
                //var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                //context.Database.EnsureCreated();
                //if (!context.Users.Any())
                //{
                ApplicationUser reguser = new ApplicationUser();
                //{
                //    Email = "ashish.akm@gmail.com",
                //    SecurityStamp = Guid.NewGuid().ToString(),
                //    UserName = "Ashish"
                //};
                reguser.UserName = registrationmodel.UserName;
                reguser.Email = registrationmodel.Email;
                reguser.SecurityStamp = Guid.NewGuid().ToString();
                reguser.PhoneNumber = registrationmodel.PhoneNo;
                await userManager.CreateAsync(reguser, registrationmodel.Password.ToString());
                // }
                //Save the Registration detail 

                _context.Registrations.Add(registrationmodel);
               
                //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
                return CreatedAtAction("registration","login", registrationmodel.UserName);
            }
            return CreatedAtAction("registration", "login", registrationmodel.UserName + ", Already exist");
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
