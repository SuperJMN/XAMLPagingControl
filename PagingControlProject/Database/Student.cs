namespace PagingControlProject.Database
{
    public class Student
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return FirstName + "." + MiddleName + "." + LastName + " (" + Age + ")";
        }
    }
}