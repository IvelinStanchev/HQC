﻿using System;

public class CSharpExam : Exam
{
    public int Score { get; private set; }

    public CSharpExam(int score)
    {
        if (score < 0)
        {
            throw new ArgumentOutOfRangeException("Invalid input scores. The scores should be positive!");
        }

        this.Score = score;
    }

    public override ExamResult Check()
    {
        if (Score < 0 || Score > 100)
        {
            throw new ArgumentOutOfRangeException("Invalid input scores. The scores must be in the range 0-100!");
        }

        return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
    }
}
