using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2LINQ.Model
{
    public class Kurs
    {
        public Kurs()
        {
            Studenter = new List<Student>();
        }

        public int KursId { get; set; }
        public string KursNamn { get; set; }
        public List<Student> Studenter { get; set; }
        

       


    }
}
