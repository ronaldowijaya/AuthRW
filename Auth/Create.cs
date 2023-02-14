using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Users;

namespace Auth
{
    
    public class Create 
    {

        //public List<String> firstName { get; set; } = new List<String>();
        //public List<String> lastName { get; set; } = new List<String>();
        //public List<String> passwords { get; set; } = new List<String>();
        //public List<String> userName { get; set; } = new List<String>();        
        
        public User CreateUser() 
        {
            User user = new User();
            //List<User> userList = new List<User>();
    
            bool check = true;
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");         

            Console.Write("First Name: ");
            string first = Console.ReadLine();
            //firstName.Add(first);
            user.firstName = first;
            Console.Write("Last Name: ");
            string last = Console.ReadLine();
            //lastName.Add(last);
            user.lastName = last;
            //userName.Add(first.Substring(0, 2) + last.Substring(0, 2));
            user.userName = first.Substring(0, 2) + last.Substring(0, 2);          

            do
            {
                Console.Write("Password: ");
                string password = Console.ReadLine();

                var isValidated = hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasLowerChar.IsMatch(password) && hasMinimum8Chars.IsMatch(password);

                if (isValidated)
                {
                    //passwords.Add(password);
                    user.passwords = password;
                    Console.WriteLine("\nData user berhasil dibuat");
                    //userList.Add(user);

                    //for (int i = 0; i < firstName.Count(); i++)
                    //{
                    //    Console.WriteLine($"{firstName[i]}-{lastName[i]}-{passwords[i]}-{userName[i]}");
                    //}

                    string? enterin = Console.ReadLine();
                    check = false;
                                
                }
                else
                {
                    Console.WriteLine("\nPassword must have at least 8 characters");
                    Console.WriteLine("with at least one Capital letter, at least one lower case letter and at least one number.");

                }
            } while(check);
            return user;
        }
       
    }
    
}
