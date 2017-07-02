using System;

namespace StarWars
{
    class BattleSimulator
    {
        readonly static Random _rand = new Random();

        readonly Warrior[] _warriors;
        readonly Warrior[] _goods;
        readonly Warrior[] _evils;


        public BattleSimulator(Warrior[] warriors)
        {
            _warriors = warriors;
            _goods = new Warrior[new Analytics(warriors).CountOfGood()];
            _evils = new Warrior[_warriors.Length - _goods.Length];
            int goodIndex = 0, evilIndex = 0;
            foreach (var warrior in _warriors)
            {
                if (warrior.IsGood)
                    _goods[goodIndex++] = warrior;
                else
                    _evils[evilIndex++] = warrior;
            }
        }

        public Warrior RunSimulation()
        {
            Warrior currentGood = null, currentEvil = null;
            while ((currentGood != null || (currentGood = GetRandomWarrior(_goods)) != null) && (currentEvil != null || (currentEvil = GetRandomWarrior(_evils)) != null))
            {
                if (Compare(currentGood, currentEvil))
                {
                    currentGood.Power -= currentEvil.Power;
                    if (currentGood.Power <= 0)
                        currentGood = null;
                    currentEvil = null;
                }
                else if (Compare(currentEvil, currentGood))
                {
                    currentEvil.Power -= currentGood.Power;
                    if (currentEvil.Power <= 0)
                        currentEvil = null;
                    currentGood = null;
                }
                else
                {
                    currentGood = null;
                    currentEvil = null;
                }
            }

            return currentGood ?? currentEvil;
        }

        bool Compare(Warrior a, Warrior b)
        {
            return (a.Power + (a.IsForceUser && !b.IsForceUser ? 2 : 0)) > (b.Power + (b.IsForceUser && !a.IsForceUser ? 2 : 0));
        }

        Warrior GetRandomWarrior(Warrior[] warriors)
        {
            var i = 0;
            while (i < warriors.Length && warriors[i] == null)
                i++;
            if (i == warriors.Length)
                return null;

            i = _rand.Next(0, warriors.Length);
            while (warriors[i] == null)
                i = _rand.Next(0, warriors.Length);
            var result = warriors[i];
            warriors[i] = null;
            return result;
        }
    }
}
