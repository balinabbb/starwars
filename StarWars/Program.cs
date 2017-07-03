using System;
using System.Threading;

namespace StarWars
{
    class Program
    {
        static void Main(string[] args)
        {
            StartMenu();
        }

        static void StartMenu()
        {
            string cmd = null;
            var warriors = FileHandler.ReadWarriors();
            do
            {
                Console.Clear();
                Console.WriteLine("---Awesome starwars simulation---");
                Console.Write("1: Analitikák\n2:Szimuláció\n3:Eredmények\n4:Kilépés a programból\nParancs: ");
                cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "1":
                        Console.Clear();
                        var analytics = new Analytics(warriors);
                        analytics.WriteAllData();
                        Console.WriteLine();
                        analytics.AllAnalytics();
                        Console.WriteLine("\nVárható eredmény:");
                        analytics.GuessResult();
                        Console.WriteLine("\n\n\nÜss le egy billentyűt a kilépéshez...");
                        Console.ReadKey();
                        break;
                    case "2":
                        warriors = FileHandler.ReadWarriors();
                        var simulator = new BattleSimulator(warriors);
                        var winner = simulator.RunSimulation();
                        FileHandler.WriteResult(winner);
                        Console.WriteLine("Csata eredménye:");
                        if(winner == null)
                            Console.WriteLine("Döntetlen");
                        else
                            Console.WriteLine($"A {(winner.IsGood ? "jók" : "rosszak")} nyertek, utolsó harcos: {winner.Name}, megmaradt ereje: {winner.Power}");
                        Console.WriteLine("\n\n\nÜss le egy billentyűt a kilépéshez...");
                        Console.ReadKey();
                        break;
                    case "3":
                        var results = FileHandler.ReadResults();
                        var resultAnalytics = new ResultAnalytics(results);
                        resultAnalytics.AllAnalytics();
                        Console.WriteLine("\n\n\nÜss le egy billentyűt a kilépéshez...");
                        Console.ReadKey();
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Hibás parancs...");
                        Thread.Sleep(500);
                        break;
                }

            } while (cmd != "4");
        }
    }
}
