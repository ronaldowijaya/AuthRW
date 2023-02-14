using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users;

namespace Auth
{
    internal class Login
    {
        public void LoginUser(List<User> user)
        {
            Console.WriteLine("==LOGIN==");
            Console.Write("Username: ");
            string userName = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            bool status = false;

            for (int i = 0; i < user.Count(); i++)
            {
                if (user[i].userName == userName && user[i].passwords == password)
                {
                    status = true;
                }                
            }          

            if(status == true)
            {
                Console.WriteLine("Login Berhasil");
            }
            else
            {
                Console.WriteLine("Login gagal");
            }

            Console.ReadKey();
        }
    }
}
