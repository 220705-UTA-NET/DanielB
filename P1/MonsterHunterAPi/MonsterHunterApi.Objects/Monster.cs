namespace MonsterHunterApi.Objects
{
    public class Monster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MonsterType { get; set; }
        public int Fire { get; set; }
        public int Water { get; set; }
        public int Thunder { get; set; }
        public int Ice { get; set; }
        public int Dragon { get; set; }

        // Constructor

        public Monster() { }

        public Monster(int id, string name, string monstertype, int fire, int water, int thunder, int ice, int dragon)
        {
            Id = id;
            Name = name;
            MonsterType = monstertype;
            Fire = fire;
            Water = water;
            Thunder = thunder;
            Ice = ice;
            Dragon = dragon;

        }

    }
}