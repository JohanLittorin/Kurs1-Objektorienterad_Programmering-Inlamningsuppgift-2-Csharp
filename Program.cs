using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basgrupp5_Fall2
{
    class Program
    {
        public static List<Person> People = new List<Person>();
        static void Menu() /*Våran initiala plan var att vi skulle kunna återvända till Menyn efter varje metod och skapade
                            därför en Menu-metod. I slutändan använde vi den bara på ett ställe, men behåller den ändå här*/
        {
            Console.WriteLine("___________________________________________ \n");
            Console.WriteLine("Var vänlig att ange en siffra för kommando: \n1 - Lägg till \n2 - Lista \n3 - Redigera \n4 - Radera \n5 - Sök");
        }
        static void Edit() /*Till att börja med hade vi tänkt återvända till Edit för att kunna redigera samma kontakt på flera 
                            sätt, vi skapade dock en loop vi inte kunde ta oss ur, så därför tog vi bort den*/
        {
            Console.WriteLine("___________________________________________ \n");
            Console.WriteLine("Vad vill du redigera? \na - Förnamn\nb - Efternamn\nc - Hemnummer\nd - Jobbnummer\ne - Adress\nf - Email\n");
        }

        static void Enter() /*Istället för meny-metoden ovan blev den här användbar som avslut i alla metoder för att få tillbaka
                             användaren till menyvalen*/
        {
            Console.WriteLine("Tryck enter för att återvända till Menyn.");
        }

        static void Search()//även denna metod hade vi planerat att använda mer
        {
            Console.WriteLine("___________________________________________ \n");
            Console.WriteLine("Vad vill du söka efter? \na - Förnamn\nb - Efternamn\nc - Hemnummer\nd - Jobbnummer\ne - Adress\nf - Email\n");
        }
        private static void AddPerson()
        {
            Person person = new Person();

            Console.Write("Skriv in förnamn: ");
            person.firstName = Console.ReadLine();

            Console.Write("Skriv in efternamn: ");
            person.lastName = Console.ReadLine();

            Console.Write("Skriv in telefonnummer hem: ");
            person.phoneNumber1 = Console.ReadLine();

            Console.WriteLine("Skriv in telefonnummer jobb: ");
            person.phoneNumber2 = Console.ReadLine();

            Console.Write("Skriv in adress: ");
            person.address = Console.ReadLine();

            Console.Write("Skriv in e-mail: ");
            person.emailAddress = Console.ReadLine();


            People.Add(person);
        }
        private static void PrintPerson(Person person)
        {

            Console.WriteLine("Förnamn: " + person.firstName);
            Console.WriteLine("Efternamn: " + person.lastName);
            Console.WriteLine("Telefonnummer Hem: " + person.phoneNumber1);
            Console.WriteLine("Telefonnummer Jobb: " + person.phoneNumber2);
            Console.WriteLine("Adress: " + person.address);
            Console.WriteLine("E-mail: " + person.emailAddress);
        }
        private static void ListPeople()
        {
            if (People.Count == 0)
            {
                Console.WriteLine("Din kontaktlista är tom.");
                Enter();
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Här är en lista över kontakterna i din kontaktlista:\n");
            foreach (var person in People)
            {
                PrintPerson(person);
                Console.WriteLine("\n");
            }
            Enter();
            Console.ReadKey();


        }
        private static void EditPerson()
        {
            Console.WriteLine("Skriv in förnamnet på personen du vill redigera.");
            string Name = Console.ReadLine();
            Person person = People.FirstOrDefault(x => x.firstName.ToLower() == Name.ToLower()); 
            /*vi använde ToLower för att  underlätta så det inte spelar roll om användaren skriver gemener eller versaler, 
             används genomgående i koden*/ 

            if (person == null)
            {
                Console.WriteLine("Personen du angav finns inte med i kontaktlistan.");
                Enter();
                Console.ReadKey();
                return;
            }
            PrintPerson(person);
            Edit();
            var command = "";
            while (command != "exit")
            {
                command = Console.ReadLine().ToLower();
                switch (command)
                {
                    case "a":
                        person.EditFirst();
                        Console.WriteLine("\n Redigera förnamn: ");
                        person.firstName = Console.ReadLine();
                        PrintPerson(person);
                        Enter();
                        Console.ReadKey();
                        break;
                    case "b":
                        person.EditFirst2();
                        Console.WriteLine("\n Redigera efternamn: ");
                        person.lastName = Console.ReadLine();
                        PrintPerson(person);
                        Enter();
                        Console.ReadKey();
                        break;
                    case "c":
                        person.EditFirst3();
                        Console.WriteLine("\n Redigera hemnummer: ");
                        person.phoneNumber1 = Console.ReadLine();
                        PrintPerson(person);
                        Enter();
                        Console.ReadKey();
                        break;
                    case "d":
                        person.EditFirst4();
                        Console.WriteLine("\n Redigera jobbnummer: ");
                        person.phoneNumber2 = Console.ReadLine();
                        PrintPerson(person);
                        Enter();
                        Console.ReadKey();
                        break;
                    case "e":
                        person.EditFirst5();
                        Console.WriteLine("\n Redigera adress: ");
                        person.address = Console.ReadLine();
                        PrintPerson(person);
                        Enter();
                        Console.ReadKey();
                        break;
                    case "f":
                        person.EditFirst6();
                        Console.WriteLine("\n Redigera email: ");
                        person.emailAddress = Console.ReadLine();
                        PrintPerson(person);
                        Enter();
                        Console.ReadKey();
                        break;
                    default: //Vi la in ett felmeddelande för de fall då användaren inte skriver in accepterade värden för metoden
                        Console.Clear();
                        Console.WriteLine("Felaktig inmatning, försök igen\n");
                        Enter();
                        Console.ReadKey();
                        break;

                }
                return;
            }

        }
        private static void RemovePerson()
        {
            Console.WriteLine("Skriv in förnamnet på personen du vill radera.");
            string Name = Console.ReadLine();
            Person person = People.FirstOrDefault(x => x.firstName.ToLower() == Name.ToLower());

            if (person == null)
            {
                Console.WriteLine("Personen du angav finns inte med i kontaktlistan.");
                Enter();
                Console.ReadKey();
                return;
            }

            PrintPerson(person);
            Console.WriteLine("Är du säker på att du vill radera den här kontakten från din kontaktlista? (J/N)");
            //vi ville ha en bekräftelse från användaren innan radering i fall av felinmatning


            if (Console.ReadKey().Key == ConsoleKey.J)
            {
                People.Remove(person);
                Console.WriteLine("\nKontakten har raderats.");
                Enter();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nKontakten har inte raderats.");
                Enter();
                Console.ReadKey();
            }
        }
        private static void SearchPerson()
        {
            string command = "";
            while (command != "exit")
            {
                

                Search();
                command = Console.ReadLine().ToLower();
                switch (command)
                {
                    case "a":
                        Console.WriteLine("Skriv in förnamnet på kontakten du vill hitta.");
                        string Name = Console.ReadLine();
                        Person person = People.FirstOrDefault(x => x.firstName.ToLower() == Name.ToLower());

                        if (person == null)
                        {
                            Console.WriteLine("Förnamnet du angav finns inte med i kontaktlistan.");
                            Enter();
                            Console.ReadKey();
                            return;
                        }

                        PrintPerson(person);                        
                        Enter();
                        Console.ReadKey();

                        break;
                    case "b":
                        Console.WriteLine("Skriv in efternamnet på kontakten du vill hitta.");
                        string lastName = Console.ReadLine();
                        Person person2 = People.FirstOrDefault(x => x.lastName.ToLower() == lastName.ToLower());

                        if (person2 == null)
                        {
                            Console.WriteLine("Efternamnet du angav finns inte med i kontaktlistan.");
                            Enter();
                            Console.ReadKey();
                            return;
                        }

                        PrintPerson(person2);                        
                        Enter();
                        Console.ReadKey();


                        break;
                    case "c":
                        Console.WriteLine("Skriv in Telefonnumret (Hem) tillhörande kontakten du vill hitta.");
                        string phoneNumber1 = Console.ReadLine();
                        Person person4 = People.FirstOrDefault(x => x.phoneNumber1.ToLower() == phoneNumber1.ToLower());

                        if (person4 == null)
                        {
                            Console.WriteLine("Telefonnumret du angav finns inte med i kontaktlistan.");
                            Enter();
                            Console.ReadKey();
                            return;
                        }

                        PrintPerson(person4);                        
                        Enter();
                        Console.ReadKey();


                        break;
                    case "d":
                        Console.WriteLine("Skriv in Telefonnumret (Jobb) tillhörande kontakten du vill hitta.");
                        string phoneNumber2 = Console.ReadLine();
                        Person person5 = People.FirstOrDefault(x => x.phoneNumber2.ToLower() == phoneNumber2.ToLower());

                        if (person5 == null)
                        {
                            Console.WriteLine("Telefonnumret du angav finns inte med i kontaktlistan.");
                            Enter();
                            Console.ReadKey();
                            return;
                        }

                        PrintPerson(person5);                        
                        Enter();
                        Console.ReadKey();


                        break;
                    case "e":
                        Console.WriteLine("Skriv in adressen tillhörande kontakten du vill hitta.");
                        string Address = Console.ReadLine();
                        Person person3 = People.FirstOrDefault(x => x.address.ToLower() == Address.ToLower());

                        if (person3 == null)
                        {
                            Console.WriteLine("Adressen du angav finns inte med i kontaktlistan.");
                            Enter();
                            Console.ReadKey();
                            return;
                        }

                        PrintPerson(person3);                        
                        Enter();
                        Console.ReadKey();


                        break;
                    case "f":
                        Console.WriteLine("Skriv in E-mail-adressen tillhörande kontakten du vill hitta.");
                        string email = Console.ReadLine();
                        Person person6 = People.FirstOrDefault(x => x.emailAddress.ToLower() == email.ToLower());

                        if (person6 == null)
                        {
                            Console.WriteLine("E-mail-adressen du angav finns inte med i kontaktlistan.");
                            Enter();
                            Console.ReadKey();
                            return;
                        }

                        PrintPerson(person6);                        
                        Enter();
                        Console.ReadKey();

                        break;
                    default: //återigen ett felmeddelande ifall användaren skriver in ett val som inte finns
                        Console.Clear();
                        Console.WriteLine("Felaktig inmatning, försök igen\n");
                        Enter();
                        Console.ReadKey();
                        break;
                }
                return;
            }

        }
        static void Main(string[] args)
        {
            string command = "";
            while (command != "exit")
            {
                Console.Clear(); /*medan vi vill hålla mycket information i konsolfönstret kändes det rörigt att inte tömma ut det 
                                  när vi återvände till menyn*/
                Menu();
                command = Console.ReadLine().ToLower();
                switch (command)
                {
                    case "1":
                        AddPerson();
                        break;
                    case "2":
                        ListPeople();
                        break;
                    case "3":
                        EditPerson();
                        break;
                    case "4":
                        RemovePerson();
                        break;
                    case "5":
                        SearchPerson();
                        break;
                    default: //även här har vi feedback när användaren fyller i ej godkända värden.
                        Console.Clear();
                        Console.WriteLine("Felaktig inmatning, försök igen\n");
                        Enter();
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}