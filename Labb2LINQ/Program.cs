using System;
using System.Linq;
using Labb2LINQ.Data;
using Labb2LINQ.Model;



namespace Labb2LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            using DBContextLabb2LINQ Context = new DBContextLabb2LINQ();


            //Lärare T1 = new Lärare { Förnamn = "Martin", Efternamn = "Larsson" };
            //Kurs C1 = new Kurs { KursNamn = "AtK22", Lärare = T1 };
            //Student Stud1 = new Student { Förnamn = "Max", Efternamn = "Nilsson", Kursen = C1};
            //Ämne S1 = new Ämne { ÄmneNamn = "JavaScript", Students = C1.Studenter };
            //Context.Add(T1);
            //Context.Add(S1);
            //Context.Add(C1);
            //Context.Add(Stud1);
            //Context.SaveChanges();




            string TheacherSubject = "Matematik";
            var SubjectWithTeacher = (from Ämne in Context.Ämnen
                                      join ÄmneLärare in Context.ÄmneLärares on Ämne.ÄmneId equals ÄmneLärare.ÄmneId
                                      join Lärare in Context.Lärare on ÄmneLärare.LärarId equals Lärare.LärareID
                                      where Ämne.ÄmneNamn == TheacherSubject
                                      select new { Ämne = Ämne.ÄmneNamn, Lärare = Lärare.Förnamn+Lärare.Efternamn });

            Console.WriteLine("Lärare i ämnet "+ TheacherSubject);

            foreach (var item in SubjectWithTeacher)
            {
                Console.WriteLine(item.Lärare);
            }

            Console.WriteLine("--------------------------");

            var GetStudents = from Student in Context.Studenter
                              select new { Student = Student.Förnamn + " " + Student.Efternamn, Student.Kursen.KursNamn, Lärare = Student.Kursen.Lärare.Förnamn };

            foreach (var item in GetStudents)
            {
                Console.WriteLine(item.Student + "\t " + item.KursNamn + "\t " + item.Lärare);
            }

            string ContainsSubject = "Programmering 1";
            var Contains = (from Ä in Context.Ämnen select Ä.ÄmneNamn).Contains(ContainsSubject);
            if (Contains==true)
            {
                Console.WriteLine("{0} finns i tabellen", ContainsSubject);
            }
            else
            {
                Console.WriteLine("{0} finns inte i tabellen", ContainsSubject);
            }


            var Subject = (from Ämne in Context.Ämnen
                       where Ämne.ÄmneNamn == "Programmering 2"
                       select Ämne);
            
            foreach (var item in Subject)
            {
                if (Subject != null)
                {
                    item.ÄmneNamn = "OOP";
                }
                
            }


            //var EditStudent = (from Stud in Context.Studenter
            //                   where Stud.Kursen.Lärare.Förnamn == "Anas"
            //                   select Stud);
            
            //foreach (var item in EditStudent)
            //{
            //    if (EditStudent != null)
            //    {
            //        item.Kursen.Lärare.Förnamn = "Reidar";
            //    }
               
            //}

            //Context.SaveChanges();






























        }
    }
}
