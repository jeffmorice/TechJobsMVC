using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        [HttpGet]
        [Route("/search/results")]
        public IActionResult Results(string searchType, string searchTerm)
        {
            if (searchType == "all")
            {
                List<Dictionary<string, string>> results = JobData.FindByValue(searchTerm);

                ViewBag.jobs = results;
            }
            else
            {
                List<Dictionary<string, string>> results = JobData.FindByColumnAndValue(searchType, searchTerm);

                ViewBag.jobs = results;
            }

            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";

            //System.Console.WriteLine("______________________________________________________");
            //System.Console.WriteLine(results);

            return View("Index");
        }

    }


}
