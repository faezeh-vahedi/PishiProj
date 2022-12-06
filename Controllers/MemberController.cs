using CardWebApi1.Data;
using Microsoft.AspNetCore.Mvc;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CardWebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly DataContext _context;

        public MemberController(DataContext context)
        {

            _context = context;
        }
        // GET: api/<MemberController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MemberController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MemberController>
        [HttpPost("Register")]
        [Route("Register")]
        public async Task<ActionResult<Member>> Register([FromBody] Member request , string base64image, string extention)
        {
            var newMem = await _context.Members.FindAsync(request.Phone);
            if(newMem != null)
                return BadRequest("This phone is aleady exist!");
            
            request.Id = Guid.NewGuid().ToString();

            var bytes = Convert.FromBase64String(base64image);// a.base64image 
            request.ProfilePath = Path.Combine(Directory.GetCurrentDirectory(), "pictures");
            if (!Directory.Exists(request.ProfilePath))
            { //check if the folder exists;
                Directory.CreateDirectory(request.ProfilePath);
            }
            string filename = Guid.NewGuid().ToString();
            string file = Path.Combine(request.ProfilePath, filename + extention);
            if (bytes.Length > 0)
            {
                using (var stream = new FileStream(file, FileMode.Create))
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Flush();
                }
            }
            _context.Members.Add(request);
            await _context.SaveChangesAsync();
            return Ok("Member add successfully!");
        }

        [HttpPost("Login")]
        [Route("Login")]
        public async Task<ActionResult<Member>> Login(string tel, string pass)
        {
            var newMem = await _context.Members.FindAsync(tel);
            if (newMem == null)
                return BadRequest("No Member Found!");
            if (pass != newMem.Password)
                return BadRequest("Password is incorrect!");
            return Ok("Welcom "+newMem.fName+" "+newMem.lName);
        }

        // PUT api/<MemberController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MemberController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
