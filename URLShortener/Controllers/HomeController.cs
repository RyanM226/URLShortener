using BL;
using System.Web.Mvc;

namespace URLShortener.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string URL)
        {
            
            if (string.IsNullOrWhiteSpace(URL))
            {
                return View();
            }

            return View();
        }

        public ActionResult Create(string URL)
        {
            if (string.IsNullOrWhiteSpace(URL))
            {
                var error = new { Message = "Empty request parameter"};
                return Json(error, JsonRequestBehavior.AllowGet);
            }

            var requestBaseURL = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
            string shortenedURL = URLManager.Instance.CreateShortenedURL(requestBaseURL, URL);

            var resObj = new { Message = "", url = shortenedURL };
            return Json(resObj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult URLRedirect(string URL)
        {

            if (string.IsNullOrWhiteSpace(URL))
            {
                return View("Index");
            }

            string longURL = URLManager.Instance.GetExistingShortenedURL(URL);
            if(!string.IsNullOrWhiteSpace(longURL))
            {
                return new RedirectResult($"//{longURL}", true);
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "So what is TeenyURL?";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}