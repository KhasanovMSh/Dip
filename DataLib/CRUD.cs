using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataLib
{
    public static class CRUD
    {
        public static bool Regin(string userType, string login, string password, string name, string surname)
        {
            if (userType == "" || login == "" || password == "" || name == "" || surname == "")
            {
                MessageBox.Show("Заполните все поля!", "Ошибка!");
                return false;
            }
            else
            {
                string[] dataLogin = login.Split('@'); // делим строку на две части
                if (dataLogin.Length == 2) // проверяем если у нас две части
                {
                    string[] data2Login = dataLogin[1].Split('.'); // делим вторую часть ещё на две части
                    if (data2Login.Length == 2)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Укажите логин в форме х@x.x");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Укажите логин в форме х@x.x");
                    return false;
                }

                using (MathEntities db = new MathEntities())
                {
                    if (db.Users.Where(p => p.Login.Equals(login)).FirstOrDefault() != null)
                    {
                        MessageBox.Show("Такой пользователь уже существует");
                        return false;
                    }
                }

                if (password.Length >= 6)
                {
                    bool en = true; // английская раскладка
                    bool symbol = false; // символ
                    bool number = false; // цифра

                    for (int i = 0; i < password.Length; i++) // перебираем символы
                    {
                        if (password[i] >= 'А' && password[i] <= 'Я') en = false; // если русская раскладка
                        if (password[i] >= '0' && password[i] <= '9') number = true; // если цифры
                        if (password[i] == '_' || password[i] == '-' || password[i] == '!') symbol = true; // если символ
                    }

                    if (!en)
                    {
                        MessageBox.Show("Доступна только английская раскладка"); // выводим сообщение
                        return false;
                    }
                    else if (!symbol)
                    {
                        MessageBox.Show("Добавьте один из следующих символов: _ - !"); // выводим сообщение
                        return false;
                    }

                    else if (!number)
                    {
                        MessageBox.Show("Добавьте хотя бы одну цифру"); // выводим сообщение
                        return false;
                    }

                    if (en && symbol && number) // проверяем соответствие
                    {

                    }
                }
                else
                {
                    MessageBox.Show("пароль слишком короткий, минимум 6 символов");
                    return false;
                }

                try
                {
                    using (MathEntities db = new MathEntities())
                    {
                        var tempUser = new Users() { UserType = userType, Login = login, Password = password, Name = name, Surname = surname };
                        db.Users.Add(tempUser);
                        db.SaveChanges();
                        if (userType == "client")
                        {
                            CurrentUser.currentUser = tempUser;
                        }
                        MessageBox.Show("Пользователь добавлен!", "Успешно!");
                    }
                    return true;
                }
                catch
                {
                    MessageBox.Show("Невозможно добавить пользователя!", "Ошибка", MessageBoxButton.OK);
                    return false;
                }
            }
        }

        public static bool Login(string login, string password)
        {
            if (login.Length > 0) // проверяем введён ли логин     
            {
                if (password.Length > 0) // проверяем введён ли пароль         
                {
                    try
                    {
                        using (MathEntities db = new MathEntities())
                        {
                            CurrentUser.currentUser = db.Users.Where(p => p.Login.Equals(login) && p.Password.Equals(password)).FirstOrDefault();
                        }
                        if (CurrentUser.currentUser != null)
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Такого пользователя не существует!", "Ошибка", MessageBoxButton.OK);
                            return false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Такого пользователя не существует!", "Ошибка", MessageBoxButton.OK);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Введите пароль"); // выводим ошибку    
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Введите логин"); // выводим ошибку 
                return false;
            }
        }

        public static List<Users> LoadUsers()
        {
            using (MathEntities db = new MathEntities())
            {
                return db.Users.ToList();
            }
        }

        public static bool AddUser(Users tempUser)
        {
            if (tempUser.Login == "" || tempUser.Password == "" || tempUser.Name == "" || tempUser.Surname == "")
            {
                MessageBox.Show("Не оставляйте поле пустым!", "Ошибка!");
                return false;
            }
            try
            {
                using (MathEntities db = new MathEntities())
                {
                    if (db.Users.Where(p => p.Login.Equals(tempUser.Login)).FirstOrDefault() != null)
                    {
                        MessageBox.Show("Такой пользователь уже существует");
                        return false;
                    }
                    
                    db.Users.Add(tempUser);
                    db.SaveChanges();
                    MessageBox.Show("Пользователь успешно добавлен");
                    return true;
                }
            }
            catch
            {
                MessageBox.Show("Не удалось добавить администратора");
                return false;
            }
        }

        public static bool DeleteUser(Users tempUser)
        {
            try
            {
                using (MathEntities db = new MathEntities())
                {
                    var delitableUser = db.Users.Where(p => p.Id.Equals(tempUser.Id)).FirstOrDefault();
                    db.Users.Remove(delitableUser);
                    db.SaveChanges();
                }
                MessageBox.Show("Пользователь удален!");
                return true;
            }
            catch
            {
                MessageBox.Show("Невозможно удалить пользователя!", "Ошибка", MessageBoxButton.OK);
                return false;
            }
        }

        public static bool UpdateUser(Users tempUser)
        {
            if (tempUser.Login == "" || tempUser.Password == "" || tempUser.Name == "" || tempUser.Surname == "")
            {
                MessageBox.Show("Не оставляйте поле пустым!", "Ошибка!");
                return false;
            }
            try
            {
                MessageBox.Show(tempUser.Id.ToString());
                MessageBox.Show(tempUser.UserType.ToString());
                MessageBox.Show(tempUser.Login.ToString());
                MessageBox.Show(tempUser.Password.ToString());
                MessageBox.Show(tempUser.Name.ToString());
                MessageBox.Show(tempUser.Surname.ToString());

                using (MathEntities db = new MathEntities())
                {
                    var editableUser = db.Users.Where(p => p.Id.Equals(tempUser.Id)).FirstOrDefault();
                    editableUser.UserType = tempUser.UserType;
                    editableUser.Login = tempUser.Login;
                    editableUser.Password = tempUser.Password;
                    editableUser.Name = tempUser.Name;
                    editableUser.Surname = tempUser.Surname;
                    editableUser.Patronomic = tempUser.Patronomic;
                    db.SaveChanges();
                }
                MessageBox.Show("Данные успешно изменены");
                return true;
            }
            catch
            {
                MessageBox.Show("Невозможно изменить данные пользователя!", "Ошибка", MessageBoxButton.OK);
                return false;
            }
        }

        #region 
        public static List<Administrator> LoadAdministrators()
        {
            using (MathEntities db = new MathEntities())
            {
                return db.Administrator.ToList();
            }
        }
        public static List<Teacher> LoadTeachers()
        {
            using (MathEntities db = new MathEntities())
            {
                return db.Teacher.ToList();
            }
        }
        public static List<Student> LoadStudents()
        {
            using (MathEntities db = new MathEntities())
            {
                return db.Student.ToList();
            }
        }

        public static bool AddAdministrator(string login, string password, string surname, string name, string patronomic = null)
        {
            try
            {
                using (MathEntities db = new MathEntities())
                {
                    if (db.Administrator.Where(p => p.Login.Equals(login)).FirstOrDefault() != null)
                    {
                        MessageBox.Show("Такой пользователь уже существует");
                        return false;
                    }
                    var temp = new Administrator() { Login = login, Password = password, Surname = surname, Name = name, Patronomic = patronomic };
                    db.Administrator.Add(temp);
                    //db.SaveChanges();
                    MessageBox.Show("Администратор успешно добавлен");
                    return true;
                }
            }
            catch
            {
                MessageBox.Show("Не удалось добавить администратора");
                return false;
            }
        }
        public static bool AddTeacher(string login, string password, string surname, string name, string patronomic = null)
        {
            try
            {
                using (MathEntities db = new MathEntities())
                {
                    if (db.Teacher.Where(p => p.Login.Equals(login)).FirstOrDefault() != null)
                    {
                        MessageBox.Show("Такой пользователь уже существует");
                        return false;
                    }
                    var temp = new Teacher() { Login = login, Password = password, Surname = surname, Name = name, Patronomic = patronomic };
                    db.Teacher.Add(temp);
                    //db.SaveChanges();
                    MessageBox.Show("Администратор успешно добавлен");
                    return true;
                }
            }
            catch
            {
                MessageBox.Show("Не удалось добавить администратора");
                return false;
            }
        }
        public static bool AddStudent(string login, string password, string surname, string name, Group group = null)
        {
            try
            {
                using (MathEntities db = new MathEntities())
                {
                    if (db.Student.Where(p => p.Login.Equals(login)).FirstOrDefault() != null)
                    {
                        MessageBox.Show("Такой пользователь уже существует");
                        return false;
                    }
                    var temp = new Student() { Login = login, Password = password, Surname = surname, Name = name, Group = group };
                    db.Student.Add(temp);
                    //db.SaveChanges();
                    MessageBox.Show("Студент успешно добавлен");
                    return true;
                }
            }
            catch
            {
                MessageBox.Show("Не удалось добавить студента");
                return false;
            }
        }

        public static bool DeleteAdmin(int id)
        {
            try
            {
                using (MathEntities db = new MathEntities())
                {
                    var delitableUser = db.Administrator.Where(p => p.Id.Equals(id)).FirstOrDefault();
                    db.Administrator.Remove(delitableUser);
                    //db.SaveChanges();
                }
                MessageBox.Show("Пользователь удален!");
                return true;
            }
            catch
            {
                MessageBox.Show("Невозможно удалить пользователя!", "Ошибка", MessageBoxButton.OK);
                return false;
            }
        }

        public static bool DeleteTeacher(int id)
        {
            try
            {
                using (MathEntities db = new MathEntities())
                {
                    var delitableUser = db.Teacher.Where(p => p.Id.Equals(id)).FirstOrDefault();
                    db.Teacher.Remove(delitableUser);
                    //db.SaveChanges();
                }
                MessageBox.Show("Пользователь удален!");
                return true;
            }
            catch
            {
                MessageBox.Show("Невозможно удалить пользователя!", "Ошибка", MessageBoxButton.OK);
                return false;
            }
        }

        public static bool DeleteStudent(int id)
        {
            try
            {
                using (MathEntities db = new MathEntities())
                {
                    var delitableUser = db.Student.Where(p => p.Id.Equals(id)).FirstOrDefault();
                    db.Student.Remove(delitableUser);
                    //db.SaveChanges();
                }
                MessageBox.Show("Пользователь удален!");
                return true;
            }
            catch
            {
                MessageBox.Show("Невозможно удалить пользователя!", "Ошибка", MessageBoxButton.OK);
                return false;
            }
        }

        public static bool UpdateAdmin(Administrator tempUser)
        {
            if (tempUser.Login == "" || tempUser.Password == "" || tempUser.Name == "" || tempUser.Surname == "")
            {
                MessageBox.Show("Не оставляйте поле пустым!", "Ошибка!");
                return false;
            }
            try
            {
                using (MathEntities db = new MathEntities())
                {
                    var editableUser = db.Administrator.Where(p => p.Id.Equals(tempUser.Id)).FirstOrDefault();
                    editableUser.Login = tempUser.Login;
                    editableUser.Password = tempUser.Password;
                    editableUser.Name = tempUser.Name;
                    editableUser.Surname = tempUser.Surname;
                    editableUser.Patronomic = tempUser.Patronomic;
                    //db.SaveChanges();
                }

                return true;
            }
            catch
            {
                MessageBox.Show("Невозможно изменить данные пользователя!", "Ошибка", MessageBoxButton.OK);
                return false;
            }
        }

        public static bool UpdateTeacher(Administrator tempUser)
        {
            if (tempUser.Login == "" || tempUser.Password == "" || tempUser.Name == "" || tempUser.Surname == "")
            {
                MessageBox.Show("Не оставляйте поле пустым!", "Ошибка!");
                return false;
            }
            try
            {
                using (MathEntities db = new MathEntities())
                {
                    var editableUser = db.Teacher.Where(p => p.Id.Equals(tempUser.Id)).FirstOrDefault();
                    editableUser.Login = tempUser.Login;
                    editableUser.Password = tempUser.Password;
                    editableUser.Name = tempUser.Name;
                    editableUser.Surname = tempUser.Surname;
                    editableUser.Patronomic = tempUser.Patronomic;
                    //db.SaveChanges();
                }

                return true;
            }
            catch
            {
                MessageBox.Show("Невозможно изменить данные пользователя!", "Ошибка", MessageBoxButton.OK);
                return false;
            }
        }

        public static bool UpdateStudent(Administrator tempUser)
        {
            if (tempUser.Login == "" || tempUser.Password == "" || tempUser.Name == "" || tempUser.Surname == "")
            {
                MessageBox.Show("Не оставляйте поле пустым!", "Ошибка!");
                return false;
            }
            try
            {
                using (MathEntities db = new MathEntities())
                {
                    var editableUser = db.Student.Where(p => p.Id.Equals(tempUser.Id)).FirstOrDefault();
                    editableUser.Login = tempUser.Login;
                    editableUser.Password = tempUser.Password;
                    editableUser.Name = tempUser.Name;
                    editableUser.Surname = tempUser.Surname;
                    //db.SaveChanges();
                }

                return true;
            }
            catch
            {
                MessageBox.Show("Невозможно изменить данные пользователя!", "Ошибка", MessageBoxButton.OK);
                return false;
            }
        }
        #endregion
    }
}
