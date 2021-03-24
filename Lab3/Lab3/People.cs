using System;
using System.Text;

namespace Lab3 {
    class People {
        private Person[] people;
        public int PeopleNum { get; set; }
        public People() {
            PeopleNum = 0;
        }
        public People(int peopleNum) {
            this.PeopleNum = peopleNum;
            people = new Person[peopleNum];
            for (int i = 0; i < peopleNum; i++) {
                people[i] = new Person();
                people[i].GenFields();
            }
        }
        public Person this[int index] {
            get {
                try {
                    return people[index];
                } catch (IndexOutOfRangeException) {
                    Console.WriteLine("Wrong index");
                    return null;
                }
            }
            set {
                try {
                    people[index] = value;
                } catch (IndexOutOfRangeException){
                    Console.WriteLine("Wrong index");
                }
            }
        }
        public Person findYoungest() {
            int minAge = people[0].Age, index = 0;
            for (int i = 1; i < PeopleNum; i++) {
                if (people[i].Age < minAge) {
                    minAge = people[i].Age;
                    index = i;
                }
            }
            return people[index];
        }
        public override string ToString() {
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < PeopleNum; i++) {
                strBuilder.Append(people[i] + "\n\n");
            }
            return strBuilder.ToString();
        }
    }
}
