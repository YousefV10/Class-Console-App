

namespace _20._10_HomeTask
    {
        internal class Program
        {
            static void Main(string[] args)
            {

                bool check = true;
                Student student = new Student("Yusif ", "Veliyev", 20, 67);
                Student student1 = new Student("Ulker ", "Veliyeva ", 18, 96);
                Student student2 = new Student("Tahir ", "Eliyev", 19, 75);
                Student[] students = { student, student1, student2 };

                foreach (var person in students)
                {

                    Console.WriteLine($"{person.Name} , {person.Surname},  {person.Age}, {person.Grade}");
                }




                while (check)
                {
                    Console.WriteLine(1 + ".Create New Student");
                    Console.WriteLine(2 + ".Delete Student ");
                    Console.WriteLine(3 + ".Print All Students");
                    Console.WriteLine(4 + ".Print Fav Students");
                    Console.WriteLine(0 + ".Exit");

                    int number = int.Parse(Console.ReadLine());
                    switch (number)
                    {
                        case 1:

                            Console.WriteLine("Enter the name ");
                            string name3 = Console.ReadLine();

                            Console.WriteLine("Enter the Surname ");
                            string surname3 = Console.ReadLine();

                            Console.WriteLine("Enter the Age ");
                            int age3 = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter the Gradde");
                            int grade3 = int.Parse(Console.ReadLine());

                            Student student3 = new Student(name3, surname3, age3, grade3);

                            Array.Resize(ref students, students.Length + 1);
                            students[students.Length - 1] = student3;
                            break;




                        case 2:
                            Console.WriteLine("Enter the student ");
                            int del = int.Parse(Console.ReadLine());

                            if (del > students.Length)
                            {
                                Console.WriteLine("Student not found ");
                                break;
                            }
                            for (int i = del; i < students.Length; i++)
                            {
                                students[i - 1] = students[i];
                            }
                            Array.Resize(ref students, students.Length - 1);

                            foreach (var person in students)
                            {

                                Console.WriteLine($"{person.Name}, {person.Surname}, {person.Age}, {person.Grade}");
                            }

                            break;



                        case 3:
                            foreach (var person in students)
                            {

                                Console.WriteLine($"{person.Name}, {person.Surname}, {person.Age}, {person.Grade}");
                            }

                            break;



                        case 4:

                            int index = 0;
                            for (int i = 0; i <= students.Length; i++)
                            {
                                if (students[i].Grade > 90)
                                {

                                    index = i;
                                    Console.WriteLine($"{students[index].Name}, {students[index].Surname}, {students[index].Age}, {students[index].Grade}");
                                }






                            }

                            break;



                        case 0:

                            check = false;

                            break;
                    }


                }














            }
        }
    }

}
    }
}
