using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookConsol
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneBook call = new PhoneBook();
            Console.WriteLine("Phone Book : )\n");

            bool loop = true;
            do
            {
                Console.WriteLine("Select operation::\n 1. Add contact.\n 2. Show contacts.\n 3. Search contact.\n 4. Delete contact.\n 5. Edit contact.\n 6. Erase phone book.\n 7. Exit.");
                int x = Convert.ToInt16(Console.ReadLine());

                switch (x)
                {
                    case 1:
                        call.addcontact();
                        break;
                    case 2:
                        call.showcontacts();
                        break;
                    case 3:
                        call.searchcontact();
                        break;
                    case 4:
                        call.deletecontact();
                        break;
                    case 5:
                        call.edit();
                        break;
                    case 6:
                        call.eraseBook();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid entry");
                        break;
                }
            } while (loop);
        }
    }

    class Person
    {
        enum contactType
        {
            mobile = 1, work = 2, fax = 3
        }
        public string name { get; set; }
        public string surname { get; set; }
        public string telephone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string dateOfBirth { get; set; }

        public override string ToString()
        {
            return " " + name + " " + surname + " " + telephone + " " + email + " " + address + " " + dateOfBirth;
        }
    }


    class PhoneBook 
    {
        List<Person> contacts = new List<Person>();

        public void addcontact()
        {
            Person person = new Person();

            Console.Write("Enter contact name ::\n ");
            person.name = Console.ReadLine();

            Console.Write("Enter contact surname ::\n ");
            person.surname = Console.ReadLine();

            Console.Write("Enter phone number ::\n ");
            person.telephone = Console.ReadLine();

            Console.Write("Enter email ::\n ");
            person.email = Console.ReadLine();

            Console.Write("Enter address ::\n ");
            person.address = Console.ReadLine();

            Console.Write("Enter date of birth ::\n ");
            person.dateOfBirth = Console.ReadLine();

            contacts.Add(person);
        }
        public void searchcontact()
        {
            Console.Write("Enter searched string ::\n");
            string findingValue = Console.ReadLine();

            foreach (Person item in contacts)
            {
                if (item.name.Contains(findingValue) ||  
                    item.surname.Contains(findingValue) ||
                    item.telephone.ToString().Contains(findingValue) ||
                    item.email.Contains(findingValue) ||
                    item.address.Contains(findingValue) ||
                    item.dateOfBirth.Contains(findingValue))
                {
                    Console.WriteLine("Person ::{0} {1} {2} {3} {4} {5}", item.name, item.surname, item.telephone, item.email, item.address, item.dateOfBirth);
                }
                else
                {
                    Console.WriteLine("Search piece not found !");
                }
            }
        }
        public void showcontacts()
        {
            foreach (Person rec in contacts)
                Console.WriteLine("Person :: {0} {1} {2} {3} {4} {5}", rec.name, rec.surname, rec.telephone, rec.email, rec.address, rec.dateOfBirth);
            Console.WriteLine("========= end of list ===========");
       
        }
        
        public void edit()
        {
            Console.Write("Enter contact name to be edited::\n");
            string e_name = Console.ReadLine();

            Console.Write("Enter telephone to be edited::\n");
            string e_telephone = Console.ReadLine();

            var result = from Person in contacts where Person.name == e_name && Person.telephone == e_telephone select Person;

            if (result != null)
            {
                result.First().telephone = "0995558844";
                foreach (Person rec in contacts)
                    Console.WriteLine("Person :: {0} {1} {2} {3} {4} {5}", rec.name, rec.surname, rec.telephone, rec.email, rec.address, rec.dateOfBirth);
            }
            else
            {
                Console.WriteLine("Contact name doesn't exist");
            }
        }
        public void eraseBook()
        {
            contacts.Clear();
        }

        public void deletecontact()
        {
            Console.Write("Enter contact name to be deleted::\n");
            string d_name = Console.ReadLine();

            Console.Write("Enter telephone to be edited::\n");
            string d_telephone = Console.ReadLine();
           
            var result = from Person in contacts where Person.name == d_name && Person.telephone == d_telephone select Person;

            if (result != null)
            {
                contacts.Remove(new Person() { name = d_name, telephone = d_telephone });
                foreach (Person rec in contacts)
                    Console.WriteLine("Person :: {0} {1} {2} {3} {4} {5}", rec.name, rec.surname, rec.telephone, rec.email, rec.address, rec.dateOfBirth);
            }
            else
            {
                Console.WriteLine("Contact name doesn't exist");
            }
        }
    }
}
