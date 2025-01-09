
namespace Task4
{
    [Serializable]
    internal class Student
    {
        public string Name { get; set; }
        public string Groop { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal AverageScore { get; set; }

        public Student(string name, string groop, DateTime dateOfBirth, decimal averageScore)
        {
            Name = name;
            Groop = groop;
            DateOfBirth = dateOfBirth;
            AverageScore = averageScore;
        }

    }
}
