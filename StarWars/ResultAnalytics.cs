using System;

namespace StarWars
{
    class ResultAnalytics
    {
        readonly Result[] _results;
        public ResultAnalytics(Result[] results)
        {
            _results = results;
        }

        public void AllAnalytics()
        {
            
        }

        string MostPowerReamining(bool isGood)
        {
            int power = 0;
            string name = "";
            foreach (var r in _results)
            {
                if (!r.IsDraw && r.WarriorPower > power && r.GoodWin == isGood)
                {
                    power = r.WarriorPower;
                    name = r.WarriorName;
                }
            }
            return name;
        }

        //string MostPowerRemaingin(bool isGood)
        //{
        //    int maxIndex = 0;
        //    for (int i = 1; i < _results.Length; i++)
        //    {
        //        if (!_results[i].IsDraw &&
        //            _results[i].GoodWin == isGood &&
        //            _results[maxIndex].WarriorPower < _results[i].WarriorPower)
        //        {
        //            maxIndex = i;
        //        }
        //    }
        //    if (maxIndex != 0 || (_results[maxIndex].GoodWin == isGood && !_results[maxIndex].IsDraw))
        //        return _results[maxIndex].WarriorName;

        //    return null;
        //    //return maxIndex != 0 || (_results[maxIndex].GoodWin == isGood && !_results[maxIndex].IsDraw) ? 
        //    //    _results[maxIndex].WarriorName : null);
        //}

        string MostWinWarriorName(bool isGood)
        {
            return null;
        }

        int SumRemainingPower(bool isGood)
        {
            var sum = 0;
            foreach (var result in _results)
                if (!result.IsDraw && 
                    result.GoodWin == isGood)
                    sum += result.WarriorPower;
            return sum;
        }

        string MoreWins()
        {
            var goodWin = CountOfWinOfSide(true);
            var darkWin = CountOfWinOfSide(false);
            
            return goodWin > darkWin ? 
                "Jók" : 
                (goodWin < darkWin ? 
                "Rosszak" : "Döntetlen");
            //if (goodWin > darkWin)
            //    return "Jók";
            //else if (goodWin < darkWin)
            //    return "Rosszak";
            //return "Döntetlen";           
        }

        int CountOfWinOfSide(bool isGood)
        {
            return CountOfWinOfSide(
                DateTime.MinValue, 
                DateTime.MaxValue, 
                isGood);
        }

        int CountOfWinOfSide(DateTime start, DateTime end, bool isGood)
        {
            var count = 0;
            foreach (var result in _results)
            {
                if (result.Date > start && 
                    result.Date < end &&
                    !result.IsDraw && 
                    result.GoodWin == isGood)

                    count++;
            }
            return count;
        }
    }
}
