using System;
using System.Collections.Generic;

namespace ProjectZero{

    class Warrior : Player{
        Random rand = new Random();
        public int health = 50;
        public int maxhealth =50;
        public int sp = 15;
        private int dmglow = 10;
        private int dmghigh = 12;
        // private int skilldmglow;
        // private int skilldmghigh;

        IDictionary<string, ((int,int),int)> skillList = new Dictionary<string, ((int,int),int)>();       
        public void createSkillList(){
            skillList.Add("Slash", ((15,20), 5));
            skillList.Add("Lightning Cleave",((30,40),10));
        }
        public int attack(){
            //  return the dmg number for the basic attack based on the class
            int dmg = rand.Next(dmglow,dmghigh +1);              
            Console.WriteLine("\nYou swipe at the dragon with your axe for " + dmg + " damage");
            return dmg;    
        }
        // public int skillattack(){
        //     // checks to see if you have enough sp to return the dmg number for the skill based on the class
        //     displaySkillList();

            
        //         sp -= 5;
        //         int dmg = rand.Next(skilldmglow,skilldmghigh +1);
        //         // switch(classname){
        //         // case 2:                
        //         Console.WriteLine("\nYou cast your arcane energy at the dragon for " + dmg + " damage.");
        //         return dmg;
                
            
        //     Console.WriteLine("\nYou try to use your skill but you are too tired to manage it.");
            
        // }
    }
}