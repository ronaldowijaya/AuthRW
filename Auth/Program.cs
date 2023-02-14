using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Users;

namespace Auth
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Create create = new Create();
            Show show = new Show();
            Login login = new Login();
            List<User> userList = new List<User>();

            bool check = true;                      

            do
            {
                Console.Clear();    
                Console.WriteLine("== Basic Authentication RW ==");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Show User");
                Console.WriteLine("3. Login User");
                Console.WriteLine("4. Exit");
                Console.Write("Input: ");
                int input = Convert.ToInt16(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        userList.Add(create.CreateUser());
                        if(userList.Count == 1)
                        {
                            userList[0].id = 1;
                        } else if (userList.Count > 1) 
                        {
                            userList[userList.Count-1].id = userList.Max(a=>a.id)+1;
                        }                        
                        break;
                    case 2:
                        Console.Clear();                        
                        show.ShowUser(userList);                        
                        break;
                    case 3:
                        Console.Clear();
                        login.LoginUser(userList);
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }
            } while (check);
            
            
        }
    }
}