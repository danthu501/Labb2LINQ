using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb2LINQ.Model
{
    public class Ämne
    {
        [Key]
        public int ÄmneId { get; set; }
        public string ÄmneNamn { get; set; }
        public List<Student> Students { get; set; }
        //public List<Lärare> Lärarna { get; set; }

    }
}
