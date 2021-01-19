using System;

namespace EventExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var class1 = new CurrentClass();
            class1.Name = "DotNet";
            var currentStudNum = new StudentNumber();
            currentStudNum.StudentNumEvent += class1.HandleStudent;
            currentStudNum.NumberCount();
        }
    }
    public class LessNoOfStudents : EventArgs
    {
        public int studNum { get; set; }
        public LessNoOfStudents(int num)
        {
            this.studNum = num;
        }
    }
    public delegate void LessNoOfStudentsEventHandler(object source, LessNoOfStudents ob);
     public class StudentNumber
    {
        public event LessNoOfStudentsEventHandler StudentNumEvent;
        public void NumberCount()
        {
           
            LessNoOfStudentsEventHandler studNumEvent = StudentNumEvent;
            if(studNumEvent!=null)
            {
                studNumEvent(this, new LessNoOfStudents(10));
            }
        }
    }
    public class CurrentClass
    {
        public string Name { get; set; }
        public void HandleStudent(object source, LessNoOfStudents e)
        {
            Console.WriteLine("Class cancelled because of less than 30: Current Number is {0}", e.studNum);
        }
    }

}
