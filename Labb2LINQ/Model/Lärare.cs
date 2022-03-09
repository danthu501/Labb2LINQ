using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb2LINQ.Model
{
    public class Lärare
    {
        [Key]
        public int LärareID { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
       



    }
}
