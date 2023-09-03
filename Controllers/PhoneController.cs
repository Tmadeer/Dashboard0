using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Dashboard.Models;
using Dashboard.Data;
 
namespace Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PhoneController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public JsonResult GetPhone() {
        
        var PhoneData = _context.ProductDetails.ToList();
            if (PhoneData == null)
                return new JsonResult("Not Found");
            return new JsonResult(Ok(PhoneData));
        }
    }
}
