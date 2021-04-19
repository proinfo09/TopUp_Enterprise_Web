using System.Web;
using System.Web.Mvc;

namespace Enterprise_Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new AuthorizeAttribute()); //Need to login to access the page
        }
    }
}
