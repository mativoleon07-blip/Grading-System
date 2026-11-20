using System.Collections.Generic;

// Stores a student's subject names, marks, and calculated results.
public class StudentRecord
{
    // Basic student and grade information.
    public string Name { get; set; }
    public List<string> Subjects { get; set; }
    public List<int> Marks { get; set; }
    public int Total { get; private set; }
    public double Average { get; private set; }
    public string Grade { get; private set; }

    // Initializes a new student record with empty values and lists.
    public StudentRecord()
    {
        Name = string.Empty;
        Subjects = new List<string>();
        Marks = new List<int>();
        Grade = string.Empty;
    }

    // Adds all entered marks and updates the student's total.
    public int CalculateTotalMarks()
    {
        var total = 0;
        foreach (var mark in Marks)
        {
            total += mark;
        }

        Total = total;
        CalculateAverage();
        return Total;
    }

    // Calculates the average mark, or returns zero when no marks exist.
    public double CalculateAverage()
    {
        Average = Marks.Count == 0 ? 0 : (double)Marks.Sum() / Marks.Count;
        return Average;
    }

    // Assigns a letter grade based on the student's average mark.
    public string AssignGrade()
    {
        CalculateAverage();

        if (Average >= 80)
        {
            Grade = "A";
        }
        else if (Average >= 70)
        {
            Grade = "B";
        }
        else if (Average >= 60)
        {
            Grade = "C";
        }
        else if (Average >= 50)
        {
            Grade = "D";
        }
        else if (Average >= 40)
        {
            Grade = "E";
        }
        else
        {
            Grade = "F";
        }

        return Grade;
    }
}
// Entry point for collecting student information and displaying results.
public class Program
{
    public static void Main()
    {
        // Create a record and collect the student's name.
        StudentRecord Student = new StudentRecord();
        Console.Write("Enter Your Name: ");
        Student.Name = Console.ReadLine()?? String.Empty;
        // Keep prompting until the user enters a positive subject count.
        int Subjectcount;
        while (true)
        {
            Console.Write("Enter Number of Subjects");
            if(int.TryParse(Console.ReadLine(),out Subjectcount) && Subjectcount>0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Please enter a valid number of subjects greater than 0.");
            }
        }
        // Collect each subject name and its corresponding mark.
        for(int i = 0; i < Subjectcount; i++)
        {
            Console.Write($"Enter Subject {i + 1} Name: ");
            string subjectName = Console.ReadLine()?? String.Empty;
            Student.Subjects.Add(subjectName);

            // Repeat until the entered mark is an integer from 0 through 100.
            int mark;
            while (true)
            {
                Console.Write($"Enter Marks for {subjectName}: ");
                if (int.TryParse(Console.ReadLine(), out mark) && mark >= 0 && mark <= 100)
                {
                    Student.Marks.Add(mark);
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid mark between 0 and 100.");
                }
            }
        }

        // Calculate the results before displaying them.
        Student.CalculateTotalMarks();
        Student.AssignGrade();

        // Print the final student report.
        Console.WriteLine("\n--- RESULTS ---");
        Console.WriteLine($"Name: {Student.Name}");
        for (int i = 0; i < Student.Subjects.Count; i++)
        {
            Console.WriteLine($"{Student.Subjects[i],-12} {Student.Marks[i],3}");
        }
        Console.WriteLine($"Total: {Student.Total}");
        Console.WriteLine($"Average: {Student.Average:F1}");
        Console.WriteLine($"Grade: {Student.Grade}");

    }
}
    