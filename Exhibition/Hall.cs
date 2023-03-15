using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exhibition
{
    class Hall 
    {
        public int number;
        public int square;
        public string caretaker;
        public int floor;
        public bool status;
        public string name;


      
        

        public static Comparison<Hall> Name = delegate (Hall object1, Hall object2)
        {
            return object1.name.CompareTo(object2.name);
        };
        public static Comparison<Hall> Number = delegate (Hall object1, Hall object2)
        {
            return object1.number.CompareTo(object2.number);
        };
        public static Comparison<Hall> Floor = delegate (Hall object1, Hall object2)
        {
            return object1.floor.CompareTo(object2.floor);
        };
        public static Comparison<Hall> Square = delegate (Hall object1, Hall object2)
        {
            return object1.square.CompareTo(object2.square);
        };
        public static Comparison<Hall> Caretaker = delegate (Hall object1, Hall object2)
        {
            return object1.caretaker.CompareTo(object2.caretaker);
        };
        public static Comparison<Hall> Status = delegate (Hall object1, Hall object2)
        {
            return object1.status.CompareTo(object2.status);
        };




    }
}
