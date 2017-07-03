using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloMVC.Controllers
{
    public class HelloController : Controller
    {
        // GET: /<controller>/
        [HttpGet] //specifies this method responds to get requests
        public IActionResult Index() 
        {
            string html = "<form method='post'>" +
                "<input type 'text' name='name' />" +
                "<input type ='submit' value='Greet me!' />" +
                "</form>";

           return Redirect("/hello/goodbye"); //redirect
        }

        [Route("/hello")] //maps to /hello
        [HttpPost] //responds to post requests at /hello
        public IActionResult Display(string name = "world")
        {
            return Content(string.Format("<h1>What up, {0}</h1>", name), "text/html");
        }

        //Handle requests to /hello/NAME (URL segment)
        [Route("/hello/{name}")] //requests in this format will go to this handler and pull the name from the URL segment
        public IActionResult Index2(string name)
        {
            return Content(string.Format("<h1>What up, {0}</h1>", name), "text/html");
        }

        public IActionResult Goodbye()
        {
            return Content("Later", "text/html");
        }
    }
}
