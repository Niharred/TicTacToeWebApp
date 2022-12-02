using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        [HttpPost]
        public JsonResult checker(string inputModelx)
        {
            string[] inputModel = inputModelx.Split('|');

            string[,] inputModel1 = new string[3,3];
            int l = 0;
            
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        inputModel1[x,y] = inputModel[l];
                        l++;
                    }

                }


           
            HashSet<string> hash = new HashSet<string>();
            HashSet<string> hashCol = new HashSet<string>();
            //  HashSet<char> hashDia = new HashSet<char>();
            int Count = 1;
           
            // checking row wise
          

                for ( int i = 0; i < 3; i++)
                {
                     if (inputModel1[i,0]== inputModel1[i, 1] && inputModel1[i, 1] == inputModel1[i, 2])
                    {
                        
                        var resu = string.Concat(inputModel1[i, 1], "1true");
                        return Json(resu);
                    }
                }

            for (int j = 0; j < 3; j++)
            {
                // checking column wise-
                if (inputModel1[0, j] == inputModel1[1, j] && inputModel1[1, j] == inputModel1[2, j])
                {

                    var resu = string.Concat(inputModel1[1,j], "1true");
                    return Json(resu);
                }
                
            }
            // checking diagonal wise

            if ((inputModel1[0,0] == inputModel1[1,1] && inputModel1[1,1] == inputModel1[2,2]) ||(inputModel1[0,2] == inputModel1[1,1])&&(inputModel1[1,1] == inputModel1[2,0]))
            {
                
                // inputModel.isCompleted = true;
                var resu = string.Concat(inputModel1[1,1], "1true");
                return Json(resu);
               

            }
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (!"abcdefghikl".Contains(inputModel1[x, y]))
                    {
                        Count++;
                    }
                }

            }
            if(Count==10)
                return Json("true1false");




            return Json("false1false");

        }
    }
}