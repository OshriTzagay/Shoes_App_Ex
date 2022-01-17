using System.Web;
using System.Web.Mvc;

namespace Re_Frameworks_Exs_ForTest
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
