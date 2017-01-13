using System.Web;
using System.Web.Mvc;

namespace MegaBite.Clients.Web.Sugar
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
