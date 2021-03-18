using System;
using System.Text;

namespace Lab3 {
    class Person {
        private static int _peopleNum = 0;
        private int _age;
        private DateTime _dateOfBirth;
        private bool _sex;
        private bool _marriage;
        private string _homeAddress;
        private string _name;
        private string _surname;
        private string _country;
        public Person() {
            _age = 0;
            _sex = false;
            _marriage = false;
            _homeAddress = null;
            _name = null;
            _surname = null;
            _country = null;
            _peopleNum++;
        }
        public Person(bool sex, bool marriage, string homeAddress, string name, string surname, string country, DateTime dateOfBirth) {
            _sex = sex;
            _marriage = marriage;
            _homeAddress = homeAddress;
            _name = name;
            _surname = surname;
            _country = country;
            _peopleNum++;
            _dateOfBirth = dateOfBirth;
            TimeSpan newObj = DateTime.Now - _dateOfBirth;
            _age = (int)((double)newObj.Days / 365.25);
        }
        public Person(int age, bool sex, bool marriage, string homeAddress, string name, string surname, string country, DateTime dateOfBirth) {
            _age = age;
            _sex = sex;
            _marriage = marriage;
            _homeAddress = homeAddress;
            _name = name;
            _surname = surname;
            _country = country;
            _peopleNum++;
            _dateOfBirth = dateOfBirth;
        }
        public int Age {
            get {
                return _age;
            }
            set {
                if (value > 0) {
                    _age = value;
                }
            }
        }
        public DateTime DateOfBirth {
            get {
                return _dateOfBirth;
            }
            set {
                _dateOfBirth = value;
            }
        
        }
        public bool Sex {
            get {
                return _sex;
            }
            set {
                _sex = value;
            }
        }
        public bool Marriage {
            get {
                return _marriage;
            }
            set {
                _marriage = value;
            }
        }
        public string HomeAddress {
            get {
                return _homeAddress;
            }
            set {
                if (value.Length > 0) {
                    _homeAddress = value;
                }
            }
        }
        public string Name {
            get {
                return _name;
            }
            set {
                if (value.Length > 0) {
                    _name = value;
                }
            }
        }
        public string Surname {
            get {
                return _surname;
            }
            set {
                if (value.Length > 0) {
                    _surname = value;
                }
            }
        }
        public string Country {
            get {
                return _country;
            }
            set {
                if (value.Length > 0) {
                    _country = value;
                }
            }
        }
        public static int PeopleNum {
            get {
                return _peopleNum;
            }
            set {
                if (value > 0) {
                    _peopleNum = value;
                }
            }
        }
        public void GenFields() {
            Random rand = new Random();
            _age = rand.Next(1, 100);
            string[] namesForGeneration = { "Alexandra", "Tanusha", "Veronika", "Anna", "Angelina", "Nial","Alexey","Alexandr","Nikita","Daniil" };
            int randomValue = rand.Next(namesForGeneration.Length);
            _name = namesForGeneration[randomValue];
            _sex = (randomValue < 5) ? true : false;
            string[] surnamesForGeneration = { "Wilson", "Smith", "Brown", "Thomson", "Stewart", "Anderson", "Taylor", "Ross" };
            _surname = surnamesForGeneration[rand.Next(surnamesForGeneration.Length)];
            string[] countriesForGeneration = { "Belarus", "Russia", "USA", "UK", "Italy", "Spain", "Irland", "Zambia", "Qatar", "Peru", "Poland", "Philippines" };
            _country = countriesForGeneration[rand.Next(countriesForGeneration.Length)];
            if (_age >= 16) {
                _marriage = (rand.Next(2) == 1) ? true : false;
            } else {
                _marriage = false;
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
            _homeAddress = strBuilder.ToString();
            _dateOfBirth = DateTime.Now;
            _dateOfBirth = _dateOfBirth.AddYears(-_age);
            _dateOfBirth = _dateOfBirth.AddMonths(rand.Next(12));
            _dateOfBirth = _dateOfBirth.AddDays(rand.Next(30));
        }
        public void ShowInfo() {
            Console.WriteLine($"{_name} {_surname} from {_country}");
            Console.WriteLine($"Age: {_age}");
            Console.WriteLine($"HomeAddress: {_homeAddress}");
            Console.WriteLine($"Sex: {((_sex == true) ? "women" : "men")}");
            Console.WriteLine($"Status: {((_marriage == true) ? "married" : "single")}");
            Console.WriteLine($"Date of birth: {_dateOfBirth.ToString("dd.MM.yyyy")}");
        }
        public static void GetPeopleNum() {
            Console.WriteLine($"Number of people: {_peopleNum}");
        }
        public override string ToString() {
            string gender = (_sex == true) ? "women" : "men";
            string isMarried = (_marriage == true) ? "married" : "single";
            return $"{_name} {_surname} from {_country} \nAge: {_age} \nHome address: {_homeAddress} \nSex: {gender} \nStatus: {isMarried} \nDate of birth: {_dateOfBirth.ToString("dd.MM.yyyy")}";
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
