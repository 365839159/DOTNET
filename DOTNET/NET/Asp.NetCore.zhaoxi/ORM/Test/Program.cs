using Orm.BLL.User;
using System;
using Newtonsoft.Json;

namespace Test
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var bll = new UserBLL();
            var users = bll.GetUser();
            Console.WriteLine("[");
            var count = users.Count;
            foreach (var user in users)
            {
                Console.WriteLine("  {");
                foreach (var item in typeof(Orm.Model.User).GetProperties())
                {
                    Console.WriteLine($"    {item.Name} = {item.GetValue(user)} ");
                }

                Console.WriteLine(count > 1 ? "  }," : "  }");
            }

            Console.WriteLine("]");

            //var userJson = JsonConvert.SerializeObject(users);
            //Console.WriteLine(userJson);
            Console.WriteLine("Hello World!");
        }
    }
}