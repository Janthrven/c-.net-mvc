namespace Mvc.Models
{
    public class Student
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int ClassEnityId { get; set; }

        public string Sex { get; set; }

        public string Place { get; set; }

        public ClassEntiy classEnity { get; set; }

    }
}
