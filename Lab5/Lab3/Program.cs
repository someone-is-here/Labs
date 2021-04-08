using System;
using System.Text;

namespace Lab3 {
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
            People obj = new People(13);
            Console.WriteLine(obj);

            Person someone = new Person();
            someone = obj.findYoungest();
            Console.WriteLine(someone);
            Console.WriteLine();

            Person iXPerson = obj[13];
            obj[-1] = someone;
            obj[0] = someone;
            Console.WriteLine(obj);

            VolleyballPlayer vp = new VolleyballPlayer();
            vp.GenVolleyballPlayer();
            Console.WriteLine(vp);
            vp.Attack();
            vp.ShowStatus();

            Console.WriteLine();
            Console.WriteLine();
            
            Sportsman volleyBallPlayer = new VolleyballPlayer(true, false, "st.Nemanskaya 6-13", "Tanusha", "Shurko", "Belarus", new DateTime(2002, 07, 28), Sportsman.TypesOfSports.Volleyball, 0, 0, false, false, VolleyballPlayer.Teams.Minchanka, VolleyballPlayer.Position.Libero, "Max Nevero", 10);
            Console.WriteLine(volleyBallPlayer);

            volleyBallPlayer.ShowStatus();
            volleyBallPlayer.Attack();

            Console.WriteLine();
            Console.WriteLine();

            TennisPlayer tp = new TennisPlayer();
            tp.GenTennisPlayer();
            Console.WriteLine(tp);
            tp.Attack();
            tp.ShowStatus();

            Console.WriteLine();

            HandballPlayer hp = new HandballPlayer();
            hp.GenPlayer();
            Console.WriteLine(hp);
            hp.ShowTeamMembers();
            int count = 0;
            while (count++ < 10) {
                hp.Attack();
            }
            hp.ShowStatus();

        }
    }
}
