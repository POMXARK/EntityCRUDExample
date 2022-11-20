using EntityCRUDExample;
using EntityCRUDExample.Extantions;
using GenRepApp;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;
using YamlDotNet.Core.Tokens;

namespace HelloApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Добавление
            using (ApplicationContext db = new ApplicationContext())
            {
                User user1 = new User { Name = "Tom", Age = 33 };
                User user2 = new User { Name = "Alice", Age = 26 };

                // Добавление
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();
            }

            // получение
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим на консоль
                var users = db.Users.ToList();
                Console.WriteLine("Данные после добавления:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }

            // Редактирование
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем первый объект
                User user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    user.Name = "Bob";
                    user.Age = 44;
                    //обновляем объект
                    //db.Users.Update(user);
                    db.SaveChanges();
                }
                // выводим данные после обновления
                Console.WriteLine("\nДанные после редактирования:");
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }

            // Удаление
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем первый объект
                User user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    //удаляем объект
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
                // выводим данные после обновления
                Console.WriteLine("\nДанные после удаления:");
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
            var phoneRepo = new EFGenericRepository<User>(new ApplicationContext());

            var user10 = new User { Name = "Tom", Age = 33 };

            phoneRepo.Create(user10);

            //var user11 = new User { Name = "Tom", Age = 33 };
            //var user12 = new User { Name = "Alice", Age = 26 };
            //List<User> usersList = new List<User>();

            //usersList.Add(user11, user12);

            var people = new Dictionary<string, int>()
                {
                    {"Tom",   33 },
                    {"Alice", 26 }
                };
            //phoneRepo.Add(people);

            //phoneRepo.Create(new List<User>().Add(people));

            //phoneRepo.Create(new List<User>().Add(user11, user12));
            Console.Read();
        }
    }
}