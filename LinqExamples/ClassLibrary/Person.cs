namespace ClassLibrary
{
    public class Person
    {
        public Person(string firstName, int weight, int height, Gender gender)
        {
            FirstName = firstName;
            Weight = weight;
            Height = height;
            Gender = gender;
        }

        public Person(string firstName, string lastName, int age, int weight, int height, Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Weight = weight;
            Height = height;
            Gender = gender;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
    }

    public enum Gender{
        Male,
        Female
    }
}