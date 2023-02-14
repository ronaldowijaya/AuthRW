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
    public class Show 
    {        
        public void ShowUser(List<User> user)
        {           
            bool check = true;
            bool cek = true;
            bool x = true;

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            do
            {
                Console.Clear();
                Console.WriteLine("==SHOW USER==");
                for (int i = 0; i < user.Count(); i++)
                {                    
                    Console.WriteLine("=======================");
                    Console.WriteLine($"ID       : {user[i].id}");
                    Console.WriteLine($"Name     : {user[i].firstName} {user[i].lastName}");
                    Console.WriteLine($"Username : {user[i].userName}");
                    Console.WriteLine($"Password : {user[i].passwords}");
                    Console.WriteLine("=======================");
                }

                Console.WriteLine("\nMenu");
                Console.WriteLine("1. Edit User");
                Console.WriteLine("2. Delete User");
                Console.WriteLine("3. Back");
                Console.Write("Pilih: ");
                int input2 = Convert.ToInt16(Console.ReadLine());

                switch (input2)
                {
                    case 1:                        
                        Console.Write("\nID yang ingin diubah: ");
                        int id = Convert.ToInt16(Console.ReadLine());
                        var result = from r in user where r.id == id select r;
                            
                        Console.Write("First Name: ");
                        string first = Console.ReadLine();
                        result.First().firstName = first;

                        Console.Write("Last Name: ");
                        string last = Console.ReadLine();
                        result.First().lastName = last;

                        result.First().userName = first.Substring(0, 2) + last.Substring(0, 2);

                        do
                        {
                            Console.Write("Password: ");
                            string password = Console.ReadLine();
                            var isValidated = hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasLowerChar.IsMatch(password) && hasMinimum8Chars.IsMatch(password);

                            if (isValidated)
                            {
                                result.First().passwords = password;
                                Console.WriteLine("\nUser sudah berhasil diedit");
                                cek = false;
                            }
                            else
                            {
                                Console.WriteLine("\nPassword must have at least 8 characters");
                                Console.WriteLine("with at least one Capital letter, at least one lower case letter and at least one number.\n");
                            }
                        } while (cek);                        

                        string? enterin = Console.ReadLine();         
                        
                        break;
                    case 2:
                        do
                        {
                            Console.Write("\nID yang ingin dihapus: ");
                            int idd = Convert.ToInt16(Console.ReadLine());
                            var res = from r in user where r.id == idd select r;
                            if (idd > user.Count)
                            {
                                Console.WriteLine("\nUser tidak ditemukan");
                                Console.ReadKey();
                            }
                            else
                            {
                                user.Remove(res.First());
                                Console.WriteLine("\nUser berhasil dihapus");
                                Console.ReadKey();
                                x = false;
                            }                            
                        } while (x);                        

                        break;
                    case 3:
                        check = false;
                        break;
                }
            } while (check);

        }
    }
}
