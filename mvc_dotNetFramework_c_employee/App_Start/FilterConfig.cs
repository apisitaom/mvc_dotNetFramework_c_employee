using System.Web;
using System.Web.Mvc;

namespace mvc_dotNetFramework_c_employee
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
