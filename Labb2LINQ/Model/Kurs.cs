using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2LINQ.Model
{
    public class Kurs
    {
        public int KursId { get; set; }
        public string KursNamn { get; set; }
        public Lärare Lärare { get; set; }
        public List<Student> Studenter { get; set; }

       


    }
}
