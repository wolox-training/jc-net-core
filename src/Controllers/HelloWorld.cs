using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace src.Controllers
{
    public class HelloWorldController : Controller
    {

    public string Index()
    {
        return "This is my default action...Hello World";
    }

    public string Welcome()
    {
        return "This is the Welcome action method...Hello World!!! (Welcome)";
    }
    }
}
