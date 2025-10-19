

namespace _20._10_HomeTask
{
    internal class Student
    {
        public string Name;
        public string Surname;
        public int Age;
        public int Grade;


        public Student(string name, string surname, int age, int grade)
        {
            Name = name;

            if (surname.Length < 3)
            {
                Surname = surname;
            }
            else
            {
                Surname = "XXXXXXX";
            }

            if (age < 0)
            {
                Age = 0;

            }
            else
            {
                Age = age;
            }

            if (grade >= 0 && grade <= 100)
            {
                Grade = grade;

            }
            else if (grade < 0)
            {
                Grade = 0;
            }
            else
            {
                Grade = 100;
            }


        }
    }
}
