using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exhibition
{
    internal class Exhibit
    {
        public int code;
        public decimal cost;
        public string owner;
        public string name;

        public static Comparison<Exhibit> Name = delegate (Exhibit object1,  Exhibit object2)
        {
            return object1.name.CompareTo(object2.name);
        };
        public static Comparison<Exhibit> Cost = delegate (Exhibit object1, Exhibit object2)
        {
            return object1.cost.CompareTo(object2.cost);
        };
        public static Comparison<Exhibit> Code = delegate (Exhibit object1, Exhibit object2)
        {
            return object1.code.CompareTo(object2.code);
        };
        public static Comparison<Exhibit> Owner = delegate (Exhibit object1, Exhibit object2)
        {
            return object1.owner.CompareTo(object2.owner);
        };
    }
}
