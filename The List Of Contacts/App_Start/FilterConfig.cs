using System.Web;
using System.Web.Mvc;

namespace The_List_Of_Contacts
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}