using NUnit.Framework;
using System;
using System.Text;

namespace WebAaddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            //          app = new ApplicationManager();
            app = ApplicationManager.GetInstance();
            app.Auth.Login(new AccountData("admin", "secret"));
        }
        //чтобы исключить запуск нескольких гсч одномоментно убираем его из метода и преносим на уровень класса
        public static Random rnd = new Random();
       

        public static string GenerateRandomString(int max)
        {
            //Random rnd = new Random();
            //создаем число в диапазоне от 0 до указанного макс
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            //формируем строку
            StringBuilder builder = new StringBuilder();
            for (int i=0; i<l; i++)
            {
                builder.Append(Convert.ToChar(32 +Convert.ToInt32(rnd.NextDouble() * 223 )));//ковертируем в символы числовые коды символов asci
            }
            //извлекаем из buildera получившуюся строчку и возвращаем ее

            return builder.ToString();
        }

    }
}
