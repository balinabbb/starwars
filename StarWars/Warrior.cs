namespace StarWars
{
    class Warrior
    {
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
    }
}
