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
            Lärare T2 = new Lärare { Förnamn = "Tobias", Efternamn = "Andersson" };
            Lärare T3 = new Lärare { Förnamn = "Anas", Efternamn = "Qlok" };
            Lärare T4 = new Lärare { Förnamn = "Tomas", Efternamn = "Viktorsson" };

            Kurs C1 = new Kurs { KursNamn = "AK47", Lärare = T1 };
            Kurs C2 = new Kurs { KursNamn = "SUT21", Lärare = T3 };


            Student Stud1 = new Student { Förnamn = "Nils", Efternamn = "Eriksson", Kursen = C1 };
            Student Stud2 = new Student { Förnamn = "Martin", Efternamn = "Carlsson", Kursen = C1 };
            Student Stud3 = new Student { Förnamn = "Tommy", Efternamn = "Andersson", Kursen = C1 };
            Student Stud4 = new Student { Förnamn = "Greger", Efternamn = "Esbjörnsson", Kursen = C1 };
            Student Stud5 = new Student { Förnamn = "Olof", Efternamn = "Ulriksson", Kursen = C2 };
            Student Stud6 = new Student { Förnamn = "Anders", Efternamn = "Pettersson", Kursen = C2 };
            Student Stud7 = new Student { Förnamn = "Adam", Efternamn = "Dahlström", Kursen = C2 };

            Ämne S1 = new Ämne { ÄmneNamn = "Python", Students = C1.Studenter, Lärarna = new List<Lärare>() { T1, T2, T3 } };
            Ämne S2 = new Ämne { ÄmneNamn = "Matematik", Students = C2.Studenter, Lärarna = new List<Lärare>() { T3, T4 } };
            Ämne S3 = new Ämne { ÄmneNamn = "Programmering 1", Students = C2.Studenter, Lärarna = new List<Lärare>() { T3, T4 } };
            Ämne S4 = new Ämne { ÄmneNamn = "Programmering 2", Students = C1.Studenter, Lärarna = new List<Lärare>() { T3, T4 } };
            C1.Studenter = S1.Students;
            C2.Studenter = S2.Students;

            Context.AddRange(T1, T2, T3, T4);

            Context.AddRange(S1, S2, S3, S4);
            Context.AddRange(C1, C2);
            Stud1.Ämnen = S1;
            Stud2.Ämnen = S1;
            Stud3.Ämnen = S1;
            Stud4.Ämnen = S1;
            Stud5.Ämnen = S2;
            Stud6.Ämnen = S2;
            Stud7.Ämnen = S2;

            Context.AddRange(Stud1, Stud2, Stud3, Stud4, Stud5, Stud6, Stud7);
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
                                                  where Ämne.ÄmneNamn == TheacherSubject
                                                  select new {Lärare = Ämne.Lärarna });

                        Console.WriteLine("Lärare i ämnet " + TheacherSubject);

                        foreach (var item in SubjectWithTeacher)
                        {
                            foreach (var L in item.Lärare)
                            {
                                Console.WriteLine(L.Förnamn+"\t"+L.Efternamn);
                            }
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        var GetStudents = from Student in Context.Studenter
                                          select new { Student = Student.Förnamn + " " + Student.Efternamn, Student.Kursen.KursNamn, Lärare = Student.Kursen.Lärare.Förnamn+"\t"+Student.Kursen.Lärare.Efternamn };

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
                                Console.WriteLine("Namnet har ändrats Från Anas till Reidar");
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
