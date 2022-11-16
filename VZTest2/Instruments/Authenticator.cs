using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace VZTest2.Instruments
{
    public static class Authenticator
    {
        public static bool? CheckAdmin(ISession session, ViewDataDictionary viewData)
        {
            if (string.IsNullOrEmpty(session.GetString("login")))
            {
                return false;
            }
            if (!(session.GetBoolean("admin") ?? false))
            {
                return null;
            }
            LoadViewData(session, viewData);
            return true;
        }
        public static bool CheckUser(ISession session, ViewDataDictionary viewData)
        {
            if (string.IsNullOrEmpty(session.GetString("login")))
            {
                return false;
            }
            LoadViewData(session, viewData);
            return true;
        }
        private static void LoadViewData(ISession session, ViewDataDictionary viewData)
        {
            viewData["id"] = session.GetInt32("id") ?? 0;
            viewData["login"] = session.GetString("login") ?? "";
            viewData["name"] = session.GetString("name") ?? "";
            viewData["create"] = session.GetBoolean("create") ?? false;
            viewData["admin"] = session.GetBoolean("admin") ?? false;
        }
    }
}
