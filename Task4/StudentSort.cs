using System.Text.Json;

namespace Task4
{
    internal class StudentSort
    {
        private string _jsonPath = AppDomain.CurrentDomain.BaseDirectory;//путь к исполняемому файлу
        private string _dekstop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        private string _pathStudentWrite;
        private string[] _groops;
        public void GroopSort()
        {
            // Десериализация
            string path = Path.Combine(_jsonPath, "Students\\Students.json");
            string jsonString = File.ReadAllText(path);
            Student[] arrayStudent = JsonSerializer.Deserialize<Student[]>(jsonString);
            Console.WriteLine("Объект десериализован");

            _pathStudentWrite = _dekstop + @"\Student";
            if (!Directory.Exists(_pathStudentWrite))
            {
                Directory.CreateDirectory(_pathStudentWrite);  //если нет директории Student, то создаем
            }

            _groops = arrayStudent.Select(x => new string(x.Groop)).Distinct().ToArray(); //Из списка студентов получаем список групп

            foreach (Student student in arrayStudent)
            {
                foreach (string groop in _groops)
                {
                    if (student.Groop.Equals(groop))
                    { //пропускаем если группа студента совпала с группой
                        string filePath = _pathStudentWrite + $"\\{groop}.txt";
                        if (!File.Exists(filePath))
                        {
                            using (StreamWriter sw = File.CreateText(filePath))
                            {
                                StudentWrite(sw, student); //создаем текстовые файл по названию группы и добавляем первого студента
                            }
                        }
                        else
                        {
                            using (StreamWriter sw = new StreamWriter(filePath, true))
                            {
                                StudentWrite(sw, student); //текстовый файл уже существует, добавляем студента
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Студенты распределены по группам");
            Console.ReadLine();
        }

        private void StudentWrite(StreamWriter sw, Student student)
        {
            sw.WriteLine($"Имя: {student.Name}");
            sw.WriteLine($"Дата рождения: {student.DateOfBirth}");
            sw.WriteLine($"Средний балл: {student.AverageScore}\n");
        }
    }
}
