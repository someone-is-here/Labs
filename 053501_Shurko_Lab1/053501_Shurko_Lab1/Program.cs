using System;

namespace _053501_Shurko_Lab1 {
    class Program {
        static void Main(string[] args) {
            Entities.Hotel hotel = new Entities.Hotel(5);
            hotel.EmptyRooms();
            Console.WriteLine();
            hotel.ShowRoomsInfo();
            Console.WriteLine();
            hotel.Booking();
            Console.WriteLine("Enter surname to calculate cost for living: ");
            hotel.CalculateCostForLiving(Console.ReadLine());
            Console.WriteLine("Enter surname to calculate cost for living for 15 days: ");
            hotel.CalculateCostForLivingDuringPeriod(Console.ReadLine(), 15);

            Entities.Journal journal = new Entities.Journal();
            journal.ShowAllJournal();
            hotel.DataChanged += journal.AddEventForChangingData;
            hotel.ChangeClientsNumber();
            hotel.ChangeListNumbers();
            journal.ShowAllJournal();
            hotel.DataChanged -= journal.AddEventForChangingData;
            hotel.DataChanged += (string arg1, string arg2) => Console.WriteLine("Entity name " + arg1 + "\nEntity message " + arg2);
            hotel.Booking();
            journal.ShowAllJournal();
        }
    }
}
