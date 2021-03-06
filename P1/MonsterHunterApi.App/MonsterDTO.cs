namespace MonsterHunterApi.App
{
    public class MonsterDTO
    {
        // Fields
        public int id { get; set; }
        public string name { get; set; }
        public string monsterType { get; set; }
        public int fire { get; set; }
        public int water { get; set; }
        public int thunder { get; set; }
        public int ice { get; set; }
        public int dragon { get; set; }
        public int timeshunted { get; set;}

        // Constructor
        public MonsterDTO()
        {
        }

        public MonsterDTO(int id, string name, string monstertype, int fire,int water,int thunder,int ice,int dragon, int timeshunted)
        {
            this.id = id;
            this.name = name;
            this.monsterType = monstertype;
            this.fire = fire;
            this.water = water;
            this.thunder = thunder;
            this.ice = ice;
            this.dragon = dragon;
            this.timeshunted = timeshunted;
        }

        // Methods
        public override string ToString()
        {
            return $"{id} {name} {monsterType} {fire} {water} {thunder} {ice} {dragon} {timeshunted}";
        }

    }
}