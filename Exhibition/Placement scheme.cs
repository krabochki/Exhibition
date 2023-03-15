using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exhibition
{
    internal class Placement_scheme
    {
        public Hall hall { get; set; }
        public Exhibit exhibit { get; set; }
        public DateTime date_of_end;
        public DateTime date_of_beggining;


        public static Comparison<Placement_scheme> HallNumber = delegate (Placement_scheme object1, Placement_scheme object2)
        {
            return object1.hall.number.CompareTo(object2.hall.number);
        };
        public static Comparison<Placement_scheme> ExhibitCode = delegate (Placement_scheme object1, Placement_scheme object2)
        {
            return object1.exhibit.code.CompareTo(object2.exhibit.code);
        };
        public static Comparison<Placement_scheme> BeginningDate = delegate (Placement_scheme object1, Placement_scheme object2)
        {
            return object1.date_of_beggining.CompareTo(object2.date_of_beggining);
        };
        public static Comparison<Placement_scheme> EndDate = delegate (Placement_scheme object1, Placement_scheme object2)
        {
            return object1.date_of_end.CompareTo(object2.date_of_end);
        };
    }

}
