using System;
using System.Text;

namespace Lab3 {
    class Person {
        private static int peopleNum = 0;
        private int age;
        private DateTime dateOfBirth;
        private bool sex;
        private bool marriage;
        private string homeAddress;
        private string name;
        private string surname;
        private string country;
        public Person() {
            age = 0;
            sex = false;
            marriage = false;
            homeAddress = null;
            name = null;
            surname = null;
            country = null;
            peopleNum++;
        }
        public Person(bool sex, bool marriage, string homeAddress, string name, string surname, string country, DateTime dateOfBirth) {
            this.sex = sex;
            this.marriage = marriage;
            this.homeAddress = homeAddress;
            this.name = name;
            this.surname = surname;
            this.country = country;
            peopleNum++;
            this.dateOfBirth = dateOfBirth;
            TimeSpan newObj = DateTime.Now - this.dateOfBirth;
            age = (int)((double)newObj.Days / 365.25);
        }
        public Person(int age, bool sex, bool marriage, string homeAddress, string name, string surname, string country, DateTime dateOfBirth) {
            this.age = age;
            this.sex = sex;
            this.marriage = marriage;
            this.homeAddress = homeAddress;
            this.name = name;
            this.surname = surname;
            this.country = country;
            peopleNum++;
            this.dateOfBirth = dateOfBirth;
        }
        public int Age {
            get {
                return age;
            }
            set {
                if (value > 0) {
                    age = value;
                }
            }
        }
        public DateTime DateOfBirth {
            get {
                return dateOfBirth;
            }
            set {
                dateOfBirth = value;
            }

        }
        public bool Sex {
            get {
                return sex;
            }
            set {
                sex = value;
            }
        }
        public bool Marriage {
            get {
                return marriage;
            }
            set {
                marriage = value;
            }
        }
        public string HomeAddress {
            get {
                return homeAddress;
            }
            set {
                if (value.Length > 0) {
                    homeAddress = value;
                }
            }
        }
        public string Name {
            get {
                return name;
            }
            set {
                if (value.Length > 0) {
                    name = value;
                }
            }
        }
        public string Surname {
            get {
                return surname;
            }
            set {
                if (value.Length > 0) {
                    surname = value;
                }
            }
        }
        public string Country {
            get {
                return country;
            }
            set {
                if (value.Length > 0) {
                    country = value;
                }
            }
        }
        public static int PeopleNum {
            get {
                return peopleNum;
            }
            set {
                if (value > 0) {
                    peopleNum = value;
                }
            }
        }
        public void GenFields() {
            Random rand = new Random();
            age = rand.Next(1, 100);
            string[] namesForGeneration = { "Alexandra", "Tanusha", "Veronika", "Anna", "Angelina", "Nial", "Alexey", "Alexandr", "Nikita", "Daniil" };
            int randomValue = rand.Next(namesForGeneration.Length);
            name = namesForGeneration[randomValue];
            sex = (randomValue < 5) ? true : false;
            string[] surnamesForGeneration = { "Wilson", "Smith", "Brown", "Thomson", "Stewart", "Anderson", "Taylor", "Ross" };
            surname = surnamesForGeneration[rand.Next(surnamesForGeneration.Length)];
            string[] countriesForGeneration = { "Belarus", "Russia", "USA", "UK", "Italy", "Spain", "Irland", "Zambia", "Qatar", "Peru", "Poland", "Philippines" };
            country = countriesForGeneration[rand.Next(countriesForGeneration.Length)];
            if (age >= 16) {
                marriage = (rand.Next(2) == 1) ? true : false;
            } else {
                marriage = false;
            }
            StringBuilder strBuilder = new StringBuilder(rand.Next(5, 10));
            for (int i = 0; i < strBuilder.Capacity; i++) {
                if (i == 0) {
                    strBuilder.Append((char)rand.Next('A', 'Z' + 1));
                } else {
                    strBuilder.Append((char)rand.Next('a', 'z' + 1));
                }
            }
            strBuilder = strBuilder.Insert(0, "st.");
            strBuilder.Append(" " + Convert.ToString(rand.Next(1, 274)));
            strBuilder.Append(" - ");
            strBuilder.Append(Convert.ToString(rand.Next(1, 100)));
            homeAddress = strBuilder.ToString();
            dateOfBirth = DateTime.Now;
            dateOfBirth = dateOfBirth.AddYears(-age);
            dateOfBirth = dateOfBirth.AddMonths(rand.Next(12));
            dateOfBirth = dateOfBirth.AddDays(rand.Next(30));
        }
        public void ShowInfo() {
            Console.WriteLine($"{name} {surname} from {country}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"HomeAddress: {homeAddress}");
            Console.WriteLine($"Sex: {((sex == true) ? "women" : "men")}");
            Console.WriteLine($"Status: {((marriage == true) ? "married" : "single")}");
            Console.WriteLine($"Date of birth: {dateOfBirth.ToString("dd.MM.yyyy")}");
        }
        public static void GetPeopleNum() {
            Console.WriteLine($"Number of people: {peopleNum}");
        }
        public override string ToString() {
            string gender = (sex == true) ? "women" : "men";
            string isMarried = (marriage == true) ? "married" : "single";
            return $"{name} {surname} from {country} \nAge: {age} \nHome address: {homeAddress} \nSex: {gender} \nStatus: {isMarried} \nDate of birth: {dateOfBirth.ToString("dd.MM.yyyy")}";
        }
    }

    class Program {
        static void Main(string[] args) {
            Person.GetPeopleNum();

            Person person1 = new Person();
            person1.Name = "Tanusha";
            person1.Surname = "Shurko";
            person1.Age = 18;
            person1.Sex = true;
            person1.HomeAddress = "st. Nemanskaya 9-78";
            person1.Marriage = false;
            person1.Country = "Belarus";
            person1.DateOfBirth = DateTime.Parse("28.07.2002");
            person1.ShowInfo();

            Console.WriteLine();

            Person[] people = new Person[10];
            for (int i = 0; i < people.Length; i++) {
                people[i] = new Person();
                people[i].GenFields();
                people[i].ShowInfo();
            }

            Person person2 = new Person(false, false, "st.Adremak 6 - 89", "Pavel", "Grentrey", "Greece", DateTime.Parse("19.03.2018"));
            Console.WriteLine(person2);

            Person person3 = new Person(20, true, false, "st.Kolj 13 - 87", "Ariana", "Themy", "France", DateTime.Parse("13.07.2000"));
            Console.WriteLine(person3);

            Person.GetPeopleNum();
        }
    }
}
