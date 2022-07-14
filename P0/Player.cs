using System;

namespace ProjectZero{
    abstract class Player{
        //fields
        
        private int health;
        public int maxhealth;
        public int sp;

        public int getHealth(){
            return health;
        }
        public int getSP(){
            return sp;
        }
        public void setHealth(int x){
            health = x;
        }
        public void setSp(int x){
            sp = x;
        }
        public void setMaxHealth(int x){
            maxhealth = x;
        }

        Dictionary<string, int> skillList = new Dictionary<string, int>();
        // private int skilldmglow;
        // private int skilldmghigh;

        public int healthpot = 3;
        abstract public void initializeClass();
    
        //methods
        abstract public int attack();

        abstract public int skillattack(Dictionary<string, int> h);
            
        

        public void heal(){
            //adds health to the player and makes sure it does not go over the max health for a player
            if(healthpot > 0){
                healthpot -=1; 
                if(this.health + 15 > this.maxhealth){
                    this.health = this.maxhealth;
                }
                else{
                    this.health +=15;
                }
            Console.WriteLine("You drink your potion, revitalizing you");
            }
            else{
                Console.WriteLine("\nYou wasted your turn trying to drink an empty bottle");
            }
        }  
        

        public void displaySkillList(Dictionary<string, int> h){
            
            foreach(KeyValuePair<string, int> kvp in h){
                Console.WriteLine("{0}:  {1} sp", kvp.Key, kvp.Value);
            }
        }  
        abstract public Dictionary<string, int> createSkillList();
       
    }
}