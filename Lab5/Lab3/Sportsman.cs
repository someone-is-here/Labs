using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3 {
    abstract class Sportsman : Person {
        public enum TypesOfSports {
            Archery,
            Gymnastics,
            Swimming,
            Athletics,
            Badminton,
            Baseball,
            Softball,
            Basketball,
            Tennis,
            Shooting,
            Boxing,
            Handball,
            Hockey,
            Karate,
            Volleyball
        }
        protected int howLongInSport;
        protected int numOfGoldMedals;
        public TypesOfSports SportType { get; set; }
        protected bool IsOlympicChampion { get; set; }
        public bool IsMaster { get; set; }
        public int HowLongInSport {
            get {
                return howLongInSport;
            }
            set {
                if (value >= 0) {
                    howLongInSport = value;
                }
            }
        }
        public int NumOfGoldMedals {
            get {
                return numOfGoldMedals;
            }
            set {
                if (value >= 0) {
                    numOfGoldMedals = value;
                }
            }
        }
        public Sportsman() : base() {
            howLongInSport = 0;
            numOfGoldMedals = 0;
            IsMaster = false;
            IsOlympicChampion = false;
            SportType = TypesOfSports.Archery;
        }
        public Sportsman(TypesOfSports sport, int howLongInSport, int numOfGoldMedals, bool isMaster, bool isOlympicChampion) : base() {
            this.SportType = sport;
            this.HowLongInSport = howLongInSport;
            this.NumOfGoldMedals = numOfGoldMedals;
            this.IsMaster = isMaster;
            this.IsOlympicChampion = isOlympicChampion;
        }
        public Sportsman(bool sex, bool marriage, string homeAddress, string name, string surname, string country, DateTime dateOfBirth, TypesOfSports sport, int howLongInSport, int numOfGoldMedals, bool isMaster, bool isOlympicChampion):base(sex, marriage, homeAddress, name, surname, country, dateOfBirth) {
            this.SportType = sport;
            this.HowLongInSport = howLongInSport;
            this.NumOfGoldMedals = numOfGoldMedals;
            this.IsMaster = isMaster;
            this.IsOlympicChampion = isOlympicChampion;
        }
        public abstract void Attack();
        public virtual void ShowStatus() {
            string isMasterInSport = (IsMaster == true) ? "master" : "not yet";
            string isOlympicChamp = (IsOlympicChampion == true) ? "Olympic champion" : "not yet";
            Console.WriteLine($"Sport: {SportType}");
            Console.WriteLine($"Is Sport master: {isMasterInSport}");
            Console.WriteLine($"Is Olympic champion: {isOlympicChamp}");
        }
        public void GenSportsmenFields() {
            Random rand = new Random();
            GenFields();
            SportType = TypesOfSports.Archery;
            SportType += rand.Next(13);
            IsMaster = (rand.Next(2) == 1) ? true : false;
            NumOfGoldMedals = rand.Next(20);
            if (NumOfGoldMedals > 0 && Age >= 16) {
                IsOlympicChampion = (rand.Next(2) == 1) ? true : false;
                HowLongInSport = rand.Next(10, Age);
            } else {
                IsOlympicChampion = false;
                HowLongInSport = rand.Next(Age - 5);
            }
        }
        public virtual void ShowAchievements() {
            string isMasterInSport = (IsMaster == true) ? "master" : "not yet";
            string isOlympicChamp = (IsOlympicChampion == true) ? "Olympic champion" : "not yet";
            Console.WriteLine($"Is Sport master: {isMasterInSport}");
            Console.WriteLine($"Is Olympic champion: {isOlympicChamp}");
        }
        public override string ToString() { 
            string isMasterInSport = (IsMaster == true) ? "master" : "not yet";
            string isOlympicChamp = (IsOlympicChampion == true) ? "Olympic champion" : "not yet";
            string gender = (sex == true) ? "women" : "men";
            string isMarried = (marriage == true) ? "married" : "single";
            return $"{Name} {Surname} from {Country} \nAge: {Age} \nHome address: {HomeAddress} \nSex: {gender} \nStatus: {isMarried} \nDate of birth: {DateOfBirth.ToString("dd.MM.yyyy")}\n" +
                $"Type of sport: {SportType}\nHow long you in sport: {HowLongInSport}\nIs sport master: {isMasterInSport}\nNumber of gold medals: {NumOfGoldMedals}\nOlympic champion status: {isOlympicChamp}\n";
        }

    }
}
