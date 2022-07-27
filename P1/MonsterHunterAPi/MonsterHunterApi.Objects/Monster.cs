namespace MonsterHunterApi.Objects
{
    public class Monster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MonsterType { get; set; }

        // Constructor

        public Monster() { }

        public Monster(int id, string name, string monstertype)
        {
            Id = id;
            Name = name;
            MonsterType = monstertype;
        }

    }
}