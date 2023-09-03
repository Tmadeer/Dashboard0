using Dashboard.Data;
using Dashboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;
        public HomeController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            var product=context.Products.ToList();
            return View(product);
        }


        public IActionResult PaymentAccept()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PaymentAccept(PaymentAccept paymentAccept)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        

		public IActionResult AddProductDetails(ProductDetails productDetails)
		{
			context.ProductDetails.Add(productDetails);
			context.SaveChanges();
			return RedirectToAction("ProductDetails");
		}

		public IActionResult Delete(int Id) 
        {
            var product=context.Products.SingleOrDefault(p => p.Id == Id);
            if (product != null) 
            {
            context.Products.Remove(product);
                context.SaveChanges();
            }



            return RedirectToAction("Index");

                
        }

           public IActionResult Edit(int Id)
        {


            var product = context.Products.SingleOrDefault(p => p.Id == Id);
            return View(product);
        }

        public IActionResult updateProducts(Product product) 
        {
            context.Products.Update(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult CreateNewProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult ProductDetails(int Productid)
        {
			var ProductDetails = context.ProductDetails.Where(p=>p.Productid == Productid).ToList();
			var product = context.Products.ToList();
			ViewBag.ProductDetails = ProductDetails;
			return View(product);
		}

		public IActionResult ProductDetails()
        {
			var product = context.Products.ToList();
            var ProductDetails = context.ProductDetails.ToList();
            ViewBag.ProductDetails = ProductDetails;
			return View(product);
        
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}