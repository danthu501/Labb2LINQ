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
            Context.AddRange(T1, T2, T3, T4);

            Ämne S1 = new Ämne { ÄmneNamn = "Python"};
            Ämne S2 = new Ämne { ÄmneNamn = "Matematik"};
            Ämne S3 = new Ämne { ÄmneNamn = "Programmering 1"};
            Ämne S4 = new Ämne { ÄmneNamn = "Programmering 2"};
            Context.AddRange(S1, S2, S3, S4);

            LärareÄmne Lä1 = new LärareÄmne { Lärare = T1, Ämne = S1 };
            LärareÄmne Lä2 = new LärareÄmne { Lärare = T2, Ämne = S1 };
            LärareÄmne Lä3 = new LärareÄmne { Lärare = T3, Ämne = S2 };
            LärareÄmne LÄ4 = new LärareÄmne { Lärare = T4, Ämne = S2 };
            LärareÄmne LÄ5 = new LärareÄmne { Lärare = T3, Ämne = S4 };
            Context.AddRange(Lä1, Lä2, Lä3, LÄ4, LÄ5);
            Kurs C1 = new Kurs { KursNamn = "AK47" };
            Kurs C2 = new Kurs { KursNamn = "SUT21" };
            Context.AddRange(C1, C2);
            KursÄmne kursÄmne1 = new KursÄmne() { fKurser=C1, fÄmne=S1 };
            KursÄmne kursÄmne2 = new KursÄmne() { fKurser = C1, fÄmne = S1 };
            KursÄmne kursÄmne3 = new KursÄmne() { fKurser = C2, fÄmne = S2 };
            KursÄmne kursÄmne4 = new KursÄmne() { fKurser = C2, fÄmne = S3 };
            Context.AddRange(kursÄmne1, kursÄmne2, kursÄmne3, kursÄmne4);

            Student Stud1 = new Student { Förnamn = "Nils", Efternamn = "Eriksson"};
            Student Stud2 = new Student { Förnamn = "Martin", Efternamn = "Carlsson"};
            Student Stud3 = new Student { Förnamn = "Tommy", Efternamn = "Andersson" };
            Student Stud4 = new Student { Förnamn = "Greger", Efternamn = "Esbjörnsson"};
            Student Stud5 = new Student { Förnamn = "Olof", Efternamn = "Ulriksson" };
            Student Stud6 = new Student { Förnamn = "Anders", Efternamn = "Pettersson"};
            Student Stud7 = new Student { Förnamn = "Adam", Efternamn = "Dahlström"};
          
            Stud1.Ämnen = S1;
            Stud2.Ämnen = S1;
            Stud3.Ämnen = S1;
            Stud4.Ämnen = S1;
            Stud5.Ämnen = S2;
            Stud6.Ämnen = S2;
            Stud7.Ämnen = S2;

            C1.Studenter.Add(Stud1);
            C1.Studenter.Add(Stud2);
            C1.Studenter.Add(Stud3);
            C1.Studenter.Add(Stud4);
            C2.Studenter.Add(Stud5);
            C2.Studenter.Add(Stud6);
            C2.Studenter.Add(Stud7);

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
                        var SubjectWithTeacher = from Ämne in Context.Ämnen
                                                 join LärareÄmne in Context.LärareÄmnen on Ämne.ÄmneId equals LärareÄmne.Ämne.ÄmneId
                                                 join Lärare in Context.Lärare on LärareÄmne.Lärare.LärareID equals Lärare.LärareID

                                                 where Ämne.ÄmneNamn == TheacherSubject
                                                 select new { Lärare =Lärare.Förnamn + "\t" + Lärare.Efternamn };

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
                                          join Ämne in Context.Ämnen on Student.Ämnen.ÄmneId equals Ämne.ÄmneId
                                          join LärareÄmne in Context.LärareÄmnen on Ämne.ÄmneId equals LärareÄmne.Ämne.ÄmneId
                                          join Lärare in Context.Lärare on LärareÄmne.Lärare.LärareID equals Lärare.LärareID
                                                                                  
                                          select new { Student = Student.Förnamn + "\t" + Student.Efternamn, Lärare = Lärare.Förnamn + "\t" + Lärare.Efternamn };

                        foreach (var item in GetStudents)
                        {
                            Console.WriteLine(item.Student + "\t " + "\t " + item.Lärare);

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
                            else
                            {
                                Console.WriteLine("Ändringen misslyckades");
                            }

                        }
                        Context.SaveChanges();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:

                        var EditStudent = (from Stud in Context.Studenter
                                           join Ämne in Context.Ämnen on Stud.Ämnen.ÄmneId equals Ämne.ÄmneId
                                           join LärareÄmne in Context.LärareÄmnen on Ämne.ÄmneId equals LärareÄmne.Ämne.ÄmneId
                                           join Lärare in Context.Lärare on LärareÄmne.Lärare.LärareID equals Lärare.LärareID
                                           join KursÄmne in Context.KursÄmne on Ämne.ÄmneId equals KursÄmne.fÄmne.ÄmneId
                                           join Kurs in Context.Kurser on KursÄmne.fKurser.KursId equals Kurs.KursId
                                           where Lärare.Förnamn == "Anas"
                                           select LärareÄmne.Lärare.Förnamn).FirstOrDefault();



                        if (EditStudent != null)
                        {
                            EditStudent = "Reidar";
                            Console.WriteLine("Namnet har ändrats Från Anas till Reidar");


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
