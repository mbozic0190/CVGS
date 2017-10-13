using System.Web;
using System.Web.Mvc;

namespace Conestoga_Virtual_Game_Store
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
