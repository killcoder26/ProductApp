using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductApp.Data;
using ProductApp.Models;
using System.Text;

namespace ProductApp.Controllers
{
    public class CCartInfoesController : Controller
    {
        //IConfiguration _configuration;
        //string apibaseurl;
        //private readonly ProductAppContext _context;

        //public CCartInfoesController(ProductAppContext context, IConfiguration configuration)
        //{
        //    _context = context;
        //    _configuration = configuration;
        //    apibaseurl = _configuration.GetValue<string>("WebAPIbaseURL");
        //}

        // GET: CCartInfoes
        public async Task<IActionResult> Index()
        {
            return View(CRepository.CartLists);  
        }
        //public List<CCartInfo> getCartItems()
        //{
        //    List<CCartInfo> cCartInfos = new();
        //    HttpClient client = new();
        //    HttpResponseMessage response =client.GetAsync(apibaseurl + string.Format("/CCartInfoes")).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        cCartInfos = JsonConvert.DeserializeObject<List<CCartInfo>>(response.Content.ReadAsStringAsync().Result);
        //    }
        //    return cCartInfos;

        //}
        // GET: CCartInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            return View(CRepository.CartLists.FirstOrDefault(item=>item.productId==id));
        }

        // GET: CCartInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CCartInfoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                CCartInfo cart = new CCartInfo();
                CRepository.CreateCInterface(cart);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
            
        }

        // GET: CCartInfoes/Edit/5
        public IActionResult Edit(int? id)
        {
           CCartInfo? cart=CRepository.CartLists.Where(item=>item.productId==id).FirstOrDefault();
            return View(cart);
        }

        // POST: CCartInfoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,IFormCollection collection
            )
        {
            try
            {
                if(ModelState.IsValid)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: CCartInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            return View(CRepository.CartLists.FirstOrDefault(item => item.productId == id));
        }

        // POST: CCartInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id,IFormCollection collection)
        {
            try
                {
                    CRepository.RemoveFromCart(CRepository.CartLists.FirstOrDefault(item => item.productId == id));
                    return RedirectToAction(nameof(Index));
                }
            catch (Exception ex)
            {
                return View();
            }
        }
        public async Task<IActionResult> Invoice()
        {

            decimal totalprice = 0;
            foreach (var item in CRepository.CartLists)
            {
                totalprice = (decimal)(totalprice + item.productPrice);
            }
            return View(totalprice);
        }


    }
}
