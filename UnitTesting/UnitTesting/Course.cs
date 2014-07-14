using System;
using System.Collections.Generic;
using System.Text;

public class Course
{
    public const int MAX_STUDENT_COUNT_IN_COURSE = 29;

    private string name;

    public Course(string name, IList<Student> students = null)
    {
        this.Students = new List<Student>();
        this.Name = name;
    }

    public List<Student> Students { get; set; }

    public string Name
    {
        get
        {
            return this.name;
        }

        set
        {
            if (value != null && value != string.Empty)
            {
                this.name = value;
            }
            else
            {
                throw new ArgumentNullException("Name should not be missing!");
            }
        }
    }

    public void AddStudent(Student student)
    {
        bool isStudentFound = this.CheckIfStudentExists(student);

        if (isStudentFound)
        {
            throw new ArgumentException("The student has already been added!");
        }

        if (this.Students.Count + 1 <= MAX_STUDENT_COUNT_IN_COURSE)
        {
            this.Students.Add(student);
        }
        else
        {
            throw new ArgumentOutOfRangeException("The course is full. No more students can be added!");
        }
    }

    public void RemoveStudent(Student student)
    {
        bool isStudentFound = this.CheckIfStudentExists(student);

        if (!isStudentFound)
        {
            throw new ArgumentException("The student does not exist in this course!");
        }

        this.Students.Remove(student);
    }

    private bool CheckIfStudentExists(Student student)
    {
        bool isFound = false;
        for (int i = 0; i < this.Students.Count; i++)
        {
            if (this.Students[i].UniqueNumber == student.UniqueNumber)
            {
                isFound = true;
            }
        }

        return isFound;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.Append(string.Format("Course name {0}; ", this.Name));

        for (int i = 0; i < this.Students.Count; i++)
        {
            result.Append(this.Students[i] + " ");
        }

        return result.ToString().Trim();
    }
}
