﻿using System;
using System.Collections.Generic;

public class School
{
    public School(List<Course> courses = null)
    {
        this.Courses = new List<Course>();
    }

    public List<Course> Courses { get; set; }

    public void AddCourse(Course course)
    {
        this.Courses.Add(course);
    }

    public void RemoveCourse(Course course)
    {
        bool isCourseFound = false;
        for (int i = 0; i < this.Courses.Count; i++)
        {
            if (this.Courses[i].Name == course.Name)
            {
                isCourseFound = true;
                this.Courses.Remove(course);
            }
        }

        if (!isCourseFound)
        {
            throw new ArgumentException("The course does not exist in this course!");
        }
    }
}
