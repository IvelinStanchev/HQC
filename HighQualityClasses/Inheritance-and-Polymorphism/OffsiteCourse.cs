﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course
    {
        private string town;

        public OffsiteCourse(string name, string teacherName, IList<string> students, string town)
            :base(name, teacherName, students)
        {
            this.Town = town;
        }

        public OffsiteCourse(string name)
            : this(name, null, null, null)
        {
        }

        public OffsiteCourse(string name, string teacherName)
            : this(name, teacherName, null, null)
        {
        }

        public OffsiteCourse(string name, string teacherName, IList<string> students)
            : this(name, teacherName, students, null)
        {
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("OffsiteCourse { ");
            result.Append(base.ToString());

            if (this.Town != null)
            {
                result.AppendFormat("; Town = {0}", this.Town);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}
