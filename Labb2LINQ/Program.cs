using System;
using System.Collections.Generic;
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


            Lärare T1 = new Lärare { Förnamn = "Fredrik", Efternamn = "Bengtsson" };
            Kurs C1 = new Kurs { KursNamn = "AK47", Lärare = T1 };
            Student Stud1 = new Student { Förnamn = "Nils", Efternamn = "Eriksson", Kursen = C1 };
            Ämne S1 = new Ämne { ÄmneNamn = "Python", Students = C1.Studenter };
            ÄmneLärare ÄL = new ÄmneLärare { LärarId = T1.LärareID, ÄmneId = S1.ÄmneId };
            C1.Studenter = S1.Students;
            


            Context.Add(T1);
            Context.Add(S1);
            Context.Add(C1);
            Context.Add(Stud1);
            Context.SaveChanges();


            bool Meny = true;
           
            while (Meny)
            {
                Console.WriteLine("----Meny----");
                Console.WriteLine("[1] Hämta alla lärare som undervisar i Matematik");
                Console.WriteLine("[2] Hämta alla elver med sin lärare");
                Console.WriteLine("[3] Kolla om tabellen ämne innehåller Programmering 1");
                Console.WriteLine("[4] Editera ämne Programmering 2 till OOP");
                Console.WriteLine("[5] Uppdatera en student record med lärare Anas till Reidar");
                Console.WriteLine("[6] Stäng av programmet");
                Int32.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case 1:
                        string TheacherSubject = "Matematik";
                        var SubjectWithTeacher = (from Ämne in Context.Ämnen
                                                  join ÄmneLärare in Context.ÄmneLärares on Ämne.ÄmneId equals ÄmneLärare.ÄmneId
                                                  join Lärare in Context.Lärare on ÄmneLärare.LärarId equals Lärare.LärareID
                                                  where Ämne.ÄmneNamn == TheacherSubject
                                                  select new { Ämne = Ämne.ÄmneNamn, Lärare = Lärare.Förnamn + "\t" + Lärare.Efternamn });

                        Console.WriteLine("Lärare i ämnet " + TheacherSubject);

                        foreach (var item in SubjectWithTeacher)
                        {
                            Console.WriteLine(item.Lärare);
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        var GetStudents = from Student in Context.Studenter
                                          select new { Student = Student.Förnamn + " " + Student.Efternamn, Student.Kursen.KursNamn, Lärare = Student.Kursen.Lärare.Förnamn };

                        foreach (var item in GetStudents)
                        {
                            Console.WriteLine(item.Student + "\t " + item.KursNamn + "\t " + item.Lärare);
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        string ContainsSubject = "Programmering 1";
                        var Contains = (from Ä in Context.Ämnen select Ä.ÄmneNamn).Contains(ContainsSubject);
                        if (Contains == true)
                        {
                            Console.WriteLine("{0} finns i tabellen", ContainsSubject);
                        }
                        else
                        {
                            Console.WriteLine("{0} finns inte i tabellen", ContainsSubject);
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        string ChangeSubject = "Programmering 2";
                        var Subject = (from Ämne in Context.Ämnen
                                       where Ämne.ÄmneNamn == ChangeSubject
                                       select Ämne);
                        string SubjectChangedTo = "OOP";
                        foreach (var item in Subject)
                        {
                            if (Subject != null)
                            {
                                item.ÄmneNamn = SubjectChangedTo;
                                Console.WriteLine("{0} har ändras till {1}", ChangeSubject, SubjectChangedTo);
                            }

                        }
                        Context.SaveChanges();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:

                        var EditStudent = (from Stud in Context.Studenter
                                           where Stud.Kursen.Lärare.Förnamn == "Anas"
                                           select Stud);

                        foreach (var item in EditStudent)
                        {
                            if (EditStudent != null)
                            {
                                item.Kursen.Lärare.Förnamn = "Reidar";
                            }

                        }

                        Context.SaveChanges();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6:
                        Meny = false;
                        break;
                    default:
                        Console.WriteLine("Var god att ange en siffra mellan 1 och 5");
                        break;



                }
            }



    







































        }
    }
}
