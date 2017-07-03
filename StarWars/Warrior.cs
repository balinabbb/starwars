namespace StarWars
{
    class Warrior
    {
        // test
        public static Warrior FromString(string s)
        {
            var data = s.Substring(1).Split('#', '/', '!');
            return new Warrior(
                data[0].Replace('_', ' '),
                int.Parse(data[1]),
                char.IsLetter(char.Parse(data[2])),
                data.Length == 4 && bool.Parse(data[3])
            );
        }

        public string Name { get; }
        public int Power { get; set; }
        public bool IsGood { get; }
        public bool IsForceUser { get; }

        public string Info
        {
            get
            {
                return $"Név: {Name}, Harci erő: {Power}, {(IsGood ? "Jó" : "Rossz")}, {(!IsForceUser ? "Nem erő használó" : (IsGood ? "Jedi" : "Sith"))}";
            }
        }

        Warrior(string name, int power, bool isGood, bool isForceUser)
        {
            Name = name;
            Power = power;
            IsGood = isGood;
            IsForceUser = isForceUser;
        }

        public bool IsStrongerThan(Warrior other)
        {
            return (Power + (IsForceUser && !other.IsForceUser ? 2 : 0)) > (other.Power + (other.IsForceUser && !IsForceUser ? 2 : 0));
        }
    }
}
