using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3 {
    abstract class Sportsman : Person, ICharacterTraitsForSportsman,IComparable<Sportsman> {
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
        protected int persistance;
        protected int motivation;
        protected int stability;
        public int Persistance {
            get {
                return persistance;
            }
            set {
                if (value > 0 && value <= 100) {
                    persistance = value;
                }
            }
        }
        public int Motivation {
            get {
                return motivation;
            }
            set {
                if (value > 0 && value <= 100) {
                    motivation = value;
                }
            }
        }
        public int Stability {
            get {
                return stability;
            }
            set {
                if (value > 0 && value <= 100) {
                    stability = value;
                }
            }
        }
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
       public void GenCharacterTraits() {
            Random rand = new Random();
            Persistance = rand.Next(1,101);
            Motivation = rand.Next(1, 101);
            Stability = rand.Next(1, 101);
        }
        public int CompareTo(Sportsman sportsman) {
            if (this.NumOfGoldMedals > sportsman.NumOfGoldMedals) {
                return 1;
            } else if (this.NumOfGoldMedals < sportsman.NumOfGoldMedals) {
                return -1;
            } else {
                return 0;
            }
        }
        public int this[string characterTrait] {
            get {
                switch (characterTrait) {
                    case "persistance":
                    case "Persistance":
                        return Persistance;
                    case "motivation":
                    case "Motivation":
                        return Motivation;
                    case "stability":
                    case "Stability":
                        return Stability;
                    default:
                        return -1;
                }
            }
            set {
                if (value > 0 && value <= 100) {
                    switch (characterTrait) {
                        case "persistance":
                        case "Persistance":
                            Persistance = value;
                            return;
                        case "motivation":
                        case "Motivation":
                            Motivation = value;
                            return;
                        case "stability":
                        case "Stability":
                            Stability = value;
                            return;
                        default:
                            throw new Exception("Wrong characterTrait!!!");
                    }
                } else {
                    throw new Exception("Wrong value!!! Must be from 1 to 100");
                }
            }
            
        }
        public void ShowCharacterTraits() {
            Console.WriteLine($"Persistance: {Persistance}%");
            Console.WriteLine($"Motivation: {Motivation}%");
            Console.WriteLine($"Stability: {Stability}%");
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
