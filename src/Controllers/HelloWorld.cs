using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace src.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/
    /*/public IActionResult Index()
    {
        return View();
    }   
    /*/public string Index()
    {
        return "This is my default action...Hello World";
    }

    // 
    // GET: /HelloWorld/Welcome/ 

    public string Welcome()
    {
        return "This is the Welcome action method...Hello World!!! (Welcome)";
    }
    }
}