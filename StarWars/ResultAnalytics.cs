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

        string MoreWins()
        {
            var goodWin = CountOfWinOfSide(true);
            var darkWin = CountOfWinOfSide(false);
            
            if (goodWin > darkWin)
                return "Jók";
            else if (goodWin < darkWin)
                return "Rosszak";
            return "Döntetlen";
            //return goodWin > badWin ? 
            //    "Jók" : 
            //    (goodWin < badWin ? 
            //        "Rosszak" : "Döntetlen");            
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
                    result.WarriorName != null && 
                    result.GoodWin == isGood)

                    count++;
            }
            return count;
        }
    }
}
