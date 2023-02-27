namespace _4laba
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Student[] students = new Student[3];

            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine("Введите фамилию и инициалы студента N " + i + " : ");
                string name = Console.ReadLine();

                Console.WriteLine("Введите номер группы студента, состоящий из цифр: ");
                int groupNumber = Convert.ToInt32(Console.ReadLine());

                int[] performance = new int[5];

                Console.WriteLine("Введите 5 оценок студента по очереди: ");
                for (int j = 0; j < performance.Length; j++)
                {
                    int mark = Convert.ToInt32(Console.ReadLine());
                    performance[j] = mark;
                }

                Student student = new Student(name, groupNumber, calculateАverageMark(performance), performance);
                students[i] = student;

                Console.WriteLine("Студент записан.");
            }

            Console.WriteLine("Несортированный массив студентов: ");
            printStudents(students);

            sortStudents(students);

            Console.WriteLine("Сортированный массив студентов: ");
            printStudents(students);

        }

        public static void printStudents(Student[] students)
        {

            for (int i = 0; i < students.Length; i++)
            {
                students[i].printStudentData();
            }
        }

        public static Student[] sortStudents(Student[] students)
        {
            for(int i = 0; i < students.Length; i++)
            {

                for (int j = 0; j < students.Length - 1; j++)
                {
                    
                    if (students[j].getAverageMark() > students[j + 1].getAverageMark())
                    {

                        int a = students[j].getAverageMark();
                        int b = students[j + 1].getAverageMark();

                        int number = a;
                        a = b;
                        b = number;

                        Student student = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = student;
                    }
                }
            }

            return students;
        }

        public static int calculateАverageMark(int[] performance)
        {

            int averageMark = 0;
            for (int i = 0; i < performance.Length; i++)
            {
                averageMark += performance[i];
            }

            averageMark /= performance.Length;

            return averageMark;
        }
    }

    struct Student
    {
        private string name;
        private int groupNumber;
        private int averageMark;
        private int[] performance = new int[5];

        public Student(string name, int groupNumber, int averageMark, int[] performance)
        {
            this.name = name;
            this.groupNumber = groupNumber;
            this.averageMark = averageMark;
            this.performance = performance;
        }


        public void printStudentData()
        {
            Console.WriteLine("Имя студента: " + name + ", номер группы: " + groupNumber + ", средняя оценка: " + averageMark);
        }

        public int getAverageMark()
        {
            return averageMark;
        }
    }
}