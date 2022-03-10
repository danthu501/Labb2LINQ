using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb2LINQ.Model
{
    class KursÄmne
    {
        [Key]
        public int Id { get; set; }
        //public int fÄmneId { get; set; }
        //public int fKurs { get; set; }

        public virtual Ämne fÄmne { get; set; }
        public virtual Kurs fKurser { get; set; }
    }
}
