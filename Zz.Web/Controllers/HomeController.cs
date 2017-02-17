using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace Zz.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : ZzControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}