using System;

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
                data.Length > 2 ? int.Parse(data[2]) : 0,
                data.Length > 2 && bool.Parse(data[3])
            );
        }

        public DateTime Date { get; }
        public string WarriorName { get; }
        public int WarriorPower { get; }
        public bool GoodWin { get; }
        public bool IsDraw { get { return WarriorName == null; } }

        Result(DateTime date, string warriorName, 
            int warriorPower, bool goodWin)
        {
            Date = date;
            WarriorName = warriorName;
            WarriorPower = warriorPower;
            GoodWin = goodWin;
        }
    }
}
