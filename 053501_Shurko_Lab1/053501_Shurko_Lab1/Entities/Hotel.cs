using System;
using System.Collections.Generic;
using System.Text;

namespace _053501_Shurko_Lab1.Entities {
    class Hotel {
        private Collections.MyCustomCollection<Room> hotel;
        public delegate void DataChangingHandler(string arg1,string arg2);
        public event DataChangingHandler DataChanged;
        public Hotel(int rooms) {
            hotel = new Collections.MyCustomCollection<Room>();
            for (int i = 0; i < rooms; i++) {
                hotel.Add(new Room());
            }
        }
        public void EmptyRooms() {
            for(int i = 0; i < hotel.Count; i++) {
                if (hotel[i].ClientLiving == null) {
                    Console.Write((hotel[i]).RoomNumber + " ");
                }
            }
        }
        private bool isRoomEmpty(int roomNum) {
            return hotel[roomNum].ClientLiving == null;
        }
        private int RoomsIndex(int roomNum) {
            for (int i = 0; i < hotel.Count; i++) {
                if ((hotel[i]).RoomNumber == roomNum) {
                    return i;
                }
            }
            return -1;
        }
        public void ShowRoomsInfo() {
            for (int i = 0; i < hotel.Count; i++) {
                if (hotel[i].ClientLiving == null) {
                    Console.WriteLine("Room number " + (hotel[i]).RoomNumber + " is free.");
                    Console.WriteLine("Room's cost is " + (hotel[i]).Cost + ".");
                } else {
                    Console.WriteLine("Room number " + (hotel[i]).RoomNumber + " is taken.");
                    Console.WriteLine("Room's cost is " + (hotel[i]).Cost + ".");
                }
            }
        }
        public void ChangeListNumbers() {
            hotel.Add(new Room());
            DataChanged?.Invoke(this.GetType().ToString(),"ChangeListNumbers");
        }
        public void ChangeClientsNumber() {
            this.BookApartment();
            DataChanged?.Invoke(this.GetType().ToString(), "ChangeClientNumber");
        }
        public void Booking() {
            BookApartment();
            DataChanged?.Invoke(this.GetType().ToString(), "Booked apartment");
        } 
        private bool BookApartment() {
            Console.WriteLine("Enter room's number: ");
            try {
                int roomNum = Int32.Parse(Console.ReadLine());
                Console.WriteLine("You choose " + roomNum + " apartment.");
                if (this.isRoomEmpty(roomNum)) {
                    Console.WriteLine("Apartment is free, you can booked it.");
                    Client newClient = new Client();
                    newClient.AddClient();
                    this.hotel[RoomsIndex(roomNum)].BookRoom(newClient);
                    Console.WriteLine("You successfully booked it!");
                    return true;
                } else {
                    Console.WriteLine("Apartment is busy, you can't booked it. Please choose another apartment.");
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message.ToString());
                return false;
            }           
            return false;
        }
        public void CalculateCostForLiving(String surname) {
            for (int i = 0; i < hotel.Count; i++) {
                if (hotel[i].ClientLiving != null && hotel[i].ClientLiving.Surname == surname) {
                    Console.WriteLine("You need to pay "+(hotel[i]).Cost + " per day");
                    break;
                }
            }
        }
        public void CalculateCostForLivingDuringPeriod(String surname,int daysNum) {
            for (int i = 0; i < hotel.Count; i++) {
                if (hotel[i].ClientLiving != null && hotel[i].ClientLiving.Surname == surname) {
                    Console.WriteLine("The whole cost is " + (hotel[i]).Cost*daysNum);
                    break;
                }
            }
        }
    }
}
