using System.Web;
using System.Web.Mvc;
using cursomvc.Controllers;

namespace cursomvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Controllers.Filters.VerifySession());
        }
    }
}