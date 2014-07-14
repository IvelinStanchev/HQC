using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("The grade should be a positive number!");
        }
        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("The minimal grade should be a positive number!");
        }
        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("The maximum grade should be bigger than the minimal grade!");
        }
        if (comments == null)
        {
            throw new ArgumentNullException("Comments cannot be null!");
        }
        if (comments == string.Empty)
        {
            throw new ArgumentException("The comments should consist of minimum one character!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; private set; }
}
