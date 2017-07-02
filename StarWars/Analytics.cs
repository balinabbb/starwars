using System;

namespace StarWars
{
    class Analytics
    {
        readonly Warrior[] _goods;
        readonly Warrior[] _evils;

        public Analytics(Warrior[] warriors)
        {
            _goods = new Warrior[CountOfGood(warriors)];
            _evils = new Warrior[warriors.Length - _goods.Length];
            int goodIndex = 0, evilIndex = 0;
            foreach(var warrior in warriors)
            {
                if (warrior.IsGood)
                    _goods[goodIndex++] = warrior;
                else
                    _evils[evilIndex++] = warrior;
            }
        }

        public void WriteAllData()
        {
            Console.WriteLine("Jók:");
            foreach (var w in _goods)
                Console.WriteLine(w.Info);
            Console.WriteLine("\nRosszak:");
            foreach (var w in _evils)
                Console.WriteLine(w.Info);
        }

        public void AllAnalytics()
        {
            Console.WriteLine("Jók:");
            Console.WriteLine($"Legerősebb harcos neve: {StrongestWarrirorName(_goods)}");
            Console.WriteLine($"Leggyengébb harcos ereje: {WeakestWarriorPower(_goods)}");
            Console.WriteLine($"Összes harci erő: {SumBattlePower(_goods)}");
            Console.WriteLine($"Erőhasználók száma: {CountOfForceUser(_goods)}");
            Console.WriteLine($"Nem erőhasználók harci erejének összege: {NonForceUserSumPower(_goods)}");
            Console.WriteLine("\nRosszak:");
            Console.WriteLine($"Legerősebb harcos neve: {StrongestWarrirorName(_evils)}");
            Console.WriteLine($"Leggyengébb harcos ereje: {WeakestWarriorPower(_evils)}");
            Console.WriteLine($"Összes harci erő: {SumBattlePower(_evils)}");
            Console.WriteLine($"Erőhasználók száma: {CountOfForceUser(_evils)}");
            Console.WriteLine($"Nem erőhasználók harci erejének összege: {NonForceUserSumPower(_evils)}");
        }

        public void GuessResult()
        {
            var goodBattleIndex = BattleIndex(_goods);
            var evilBattleIndex = BattleIndex(_evils);
            if(goodBattleIndex > evilBattleIndex)
                Console.WriteLine("Várhatóan a jók győznek");
            else if(goodBattleIndex < evilBattleIndex)
                Console.WriteLine("Várhatóan a rosszak győznek");
            else
                Console.WriteLine("Várhatóan döntetlen lesz");
        }

        public int CountOfGood(Warrior[] allWarriors)
        {
            var count = 0;
            foreach (var w in allWarriors)
                if (w.IsGood)
                    count++;
            return count;
        }

        public int BattleIndex(Warrior[] warriors)
        {
            return SumBattlePower(warriors) / warriors.Length * CountOfForceUser(warriors);
        }

        public string StrongestWarrirorName(Warrior[] warriors)
        {
            var maxIndex = 0;
            for (var i = 1; i < warriors.Length; i++)
            {
                if (warriors[i].Power > warriors[maxIndex].Power)
                    maxIndex = i;
            }
            return warriors[maxIndex].Name;
        }

        public int WeakestWarriorPower(Warrior[] warriors)
        {
            var minIndex = 0;
            for (var i = 0; i < warriors.Length; i++)
            {
                if (warriors[i].Power < warriors[minIndex].Power)
                    minIndex = i;
            }
            return warriors[minIndex].Power;
        }

        public int SumBattlePower(Warrior[] warriors)
        {
            var sum = 0;
            foreach (var w in warriors)
                sum += w.Power;
            return sum;
        }

        public int CountOfForceUser(Warrior[] warriors)
        {
            var count = 0;
            foreach (var w in warriors)
                if (w.IsForceUser)
                    count++;
            return count;
        }

        public int NonForceUserSumPower(Warrior[] warriors)
        {
            var sum = 0;
            foreach (var w in warriors)
                if (!w.IsForceUser)
                    sum += w.Power;
            return sum;
        }
    }
}
