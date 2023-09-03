using Dashboard.Data;
using Dashboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;using MailKit.Net.Smtp;



namespace Dashboard.Controllers.Shopping
{
    public class ShoppingController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ShoppingController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<string> SendEMail()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Test", "tmaaaader@gmail.com"));
            message.To.Add(MailboxAddress.Parse("hanitmader@gmail.com"));
            message.Subject="Test Message";
            message.Body = new TextPart("plain")
            {
                Text = "Welcom"
             };

            using (var client = new SmtpClient())
                {
                try
                {
                    client.Connect("smtp.gmail.com", 587);
                    client.Authenticate("tmaaaader@gmail.com", "xmzibsohyjgdxzkh");
                    await client.SendAsync(message);
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());
                }
            };


            return "Ok";

        }

        public IActionResult LoginModel()
        { return RedirectToAction("LoginModel"); 
        }



        public IActionResult ProductDetails(int id)
        {
            var ProductDetails = _context.ProductDetails.Where(p => p.Productid == id).ToList();
          
            return View(ProductDetails);
           
        }
        //  [Authorize]
        public IActionResult CheckOut(int Id)
        {
            var user = HttpContext.User.Identity.Name;
            var ProductDetails = _context.ProductDetails.SingleOrDefault(p => p.id == Id);
            var cart = new Cart()
            {
                IdCostumer = user,
             IdProduct = ProductDetails.Productid,
             
                Images = ProductDetails.imag,
                Price = ProductDetails.Price,
                QTY = ProductDetails.Qty

            };
            _context.carts.Add(cart);
            _context.SaveChanges();
            return View(cart);
        }
       
        public IActionResult Index()
        {
            var Product = _context.Products.ToList();
            return View(Product);
        }
    }
}
