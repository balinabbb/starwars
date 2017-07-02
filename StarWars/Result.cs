using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars
{
    class Result
    {
        public static Result FromString(string s)
        {
            var data = s.Split(';');
            return new Result(
                DateTime.Parse(data[0]), 
                data.Length > 2 ? data[1] : null, 
                data.Length > 2 ? int.Parse(data[2]) : 0
            );
        }
        public DateTime Date { get; }
        public string WarriorName { get; }
        public int WarriorPower { get; }

        Result(DateTime date, string warriorName, int warriorPower)
        {
            Date = date;
            WarriorName = warriorName;
            WarriorPower = warriorPower;
        }
    }
}
