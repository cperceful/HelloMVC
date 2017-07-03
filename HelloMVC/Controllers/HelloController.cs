using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloMVC.Controllers
{
    public class HelloController : Controller
    {
        static int count = 0;

        // GET: /<controller>/
        [HttpGet] //specifies this method responds to get requests
        public IActionResult Index() 
        {
            string html = "<form method='post'>" +
                "<input type 'text' name='name' />" +
                "<select name='language'>" +
                "<option value='english'>English</option>" +
                "<option value='russian'>Russian</option>" +
                "<option value='romulan'>Romulan</option>" +
                "<option value='german'>German</option>" +
                "<option value='spanish'>Spanish</option>" +
                "</select>" +
                "<input type ='submit' value='Greet me!' />" +
                "</form>";

           return Content(html, "text/html"); //redirect
        }

        [Route("/hello")] //maps to /hello
        [HttpPost] //responds to post requests at /hello
        public IActionResult Display(string name = "friend", string language = "english")
        {
            count++;
            string greeting = "Hello";
            
            if (language == "english")
            {
                greeting = "Hello";
            } else if (language == "russian")
            {
                greeting = "Privyet";
            } else if (language == "romulan")
            {
                greeting = "Jolan Tru";
            } else if (language == "german")
            {
                greeting = "Guten Tag";
            } else if (language == "spanish")
            {
                greeting = "Hola";
            }

            return Content(string.Format("<h1>{0}, {1}!</h1> <h2>You've been greeted {2} times!</h2>", greeting, name, count), "text/html");
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
