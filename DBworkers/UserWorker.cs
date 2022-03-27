using VolgaIT2022App5.Models;
using VolgaIT2022App5.DBContexts;


namespace VolgaIT2022App5.DBworkers
{
    public static class UserWorker
    {
        public static bool AuthUser(string mail, string pass)
        {//true - пользователь есть
            using (UserContext db = new UserContext())
            {
                User usr = db.Users
                    .Where(b => b.Email == mail)
                    .Where(b=> b.Password==pass)
                    .FirstOrDefault();

                if (usr == null)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool CheckMail(string mail)
        {//true - пользователь уже есть
            using (UserContext db = new UserContext())
            {
                User usr = db.Users
                    .Where(b => b.Email == mail)
                    .FirstOrDefault();

                if (usr == null)
                {
                    return false;
                }
            }
            return true;
        }
        public static int MailToId(string mail)
        {//true - пользователь уже есть
            using (UserContext db = new UserContext())
            {
                User usr = db.Users
                    .Where(b => b.Email == mail)
                    .FirstOrDefault();

                if (usr == null)
                {
                    return -1;
                }
                return usr.Id;
            }
        }


        public static void AddUser(User usr)
        {
            using (UserContext db = new UserContext())
            {
                User newUser = usr;
                db.Add(newUser);
                db.SaveChanges();
            }
        }
    }
}
