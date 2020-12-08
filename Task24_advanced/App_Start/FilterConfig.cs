using System.Web;
using System.Web.Mvc;
using Task24_advanced.FIlters;

namespace Task24_advanced
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new MyActionAttribute());
        }
    }
}
