using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2LINQ.Model
{
    public class LärareÄmne
    {
        public int Id { get; set; }
        //public int fLärare { get; set; }
        //public int fÄmne { get; set; }

        public Lärare Lärare { get; set; }
        public Ämne Ämne { get; set; }
    }
}
