using VolgaIT2022App5.Models;
using VolgaIT2022App5.DBContexts;

namespace VolgaIT2022App5.DBworkers
{
    public static class AppsWorker
    {
        public static int AppsCount(string mail)
        {

            return GetAppList(mail).Count;
        }
        public static bool CheckName(string mail, string name)
        {//true - Приложение есть
            return false;
        }
        public static string IdentityCreator()
        {
            string res = "";
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789abcdefghijklmnopqrstuvwxyz";
            Random rand = new Random();

            do
            {
                for (int a = 0; a < 6; a++)
                {
                    res += chars[rand.Next(chars.Length)];
                }
            } while (IdentityToId(res) != -1);

            return res;
        }
        public static void CreateApp(App app, string ownerMail)
        {
            int oid = UserWorker.MailToId(ownerMail);

            if (oid == -1) return;
            app.owner = oid;
            using (AppsContext db = new AppsContext())
            {
                App newApp = app;
                db.Add(newApp);
                db.SaveChanges();
            }
        }
        public static int IdentityToId(string identity)
        {//true - пользователь уже есть
            using (AppsContext db = new AppsContext())
            {
                App app = db.Apps
                    .Where(b => b.Identity == identity)
                    .FirstOrDefault();

                if (app == null)
                {
                    return -1;
                }
                return app.Id;
            }
        }

        public static List<App> GetAppList(string ownerMail)
        {
            List<App> appList = new List<App>();

            int oid = UserWorker.MailToId(ownerMail);

            if (oid == -1) return appList;

            using (AppsContext db = new AppsContext())
            {
                foreach (App entry in db.Apps.Where(b => b.owner == oid))
                {
                    appList.Add(entry);
                }
            }
            return appList;
        }
    }
}
