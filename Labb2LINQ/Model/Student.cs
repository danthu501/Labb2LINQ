using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2LINQ.Model
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Förnamn { get; set; }
        public string  Efternamn { get; set; }
        //public int fKursenId { get; set; }
        public Ämne Ämnen { get; set; }

    }
}
