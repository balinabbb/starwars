using System;
using System.IO;

namespace StarWars
{
    static class FileHandler
    {
        const string WarriorsFileName = "warriors.txt";
        const string ResultsFileName = "results.txt";

        public static Warrior[] ReadWarriors()
        {
            var data = File.ReadAllLines(WarriorsFileName);
            var warriors = new Warrior[data.Length];
            for (var i = 0; i < data.Length; i++)
                warriors[i] = Warrior.FromString(data[i]);
            return warriors;
        }

        public static void WriteResult(Warrior winner)
        {
            using (var sw = new StreamWriter(ResultsFileName, true))
            {
                if(winner != null)
                    sw.WriteLine($"{DateTime.Now};{winner.Name};{winner.Power}");
                else
                    sw.WriteLine($"{DateTime.Now};Döntetlen");
            }
        }

        public static Result[] ReadResults()
        {
            var data = File.ReadAllLines(ResultsFileName);
            var results = new Result[data.Length];
            for (var i = 0; i < data.Length; i++)
                results[i] = Result.FromString(data[i]);
            return results;
        }
    }
}
