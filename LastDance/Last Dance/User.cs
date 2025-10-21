

namespace Last_Dance
{
    internal class User
    {
        public string Id; 
        public string Fullname;
        public string Email;
        public string Password;
        public int Age;
    }

    internal class AdvancedUser
    {
        private static int _counter = 0;

        public int Id { get; } 

        public string Fullname { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        private string _password;
        public string Password
        {
            get { return _password; }
            private set
            {
                if (PasswordChecker(value))
                {
                    _password = value;
                }
                else
                {
                    Console.WriteLine("Şifrə tələbləri ödəmir. Minimum 8 simvol, ən az 1 böyük hərf, 1 kiçik hərf və 1 rəqəm olmalıdır.");
                }
            }
        }

       

        public bool PasswordChecker(string password)
        {
            if (password.Length < 8)
            {
                return false;
            }

            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    hasUpper = true;
                }
                else if (char.IsLower(c))
                {
                    hasLower = true;
                }
                else if (char.IsDigit(c))
                {
                    hasDigit = true;
                }

                if (hasUpper && hasLower && hasDigit)
                {
                    return true;
                }
            }

            return hasUpper && hasLower && hasDigit;
        }

        public string GetInfo()
        {
            return $"ID: {Id}, Tam Ad: {Fullname ?? "Qeyd edilməyib"}, Email: {Email}";
        }
    }
}
