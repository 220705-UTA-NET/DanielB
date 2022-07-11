using System;
using System.Collections.Generic;

namespace ProjectZero{

    class Gunslinger : Player{
        Random rand = new Random();
        public int health = 43;
        public int maxhealth = 43;
        public int sp = 20;
        private int dmglow = 7;
        private int dmghigh = 9;
        // private int skilldmglow;
        // private int skilldmghigh;

        Dictionary<string, int> skillList = new Dictionary<string, int>();       
        public Dictionary<string, int> createSkillList(){
            skillList.Add("1:Snipe Shot", 5); //11,25),
            skillList.Add("2:Trick Shot",15); //(45,50),
            return skillList;
        }
        public int attack(){
            //  return the dmg number for the basic attack based on the class
            int dmg = rand.Next(dmglow,dmghigh +1);              
            Console.WriteLine("\nYou shoot your pistols at the dragon for " + dmg + " damage.");
            return dmg;    
        }
        public void skillattack(Dictionary<string, int> h){
            // checks to see if you have enough sp to return the dmg number for the skill based on the class
            Console.WriteLine("Type the number next the action you want to do");
            displaySkillList(h);
            string action = Console.ReadLine();

            
        //         sp -= 5;
        //         int dmg = rand.Next(skilldmglow,skilldmghigh +1);
        //         // switch(classname){
        //         // case 2:                
        //         Console.WriteLine("\nYou cast your arcane energy at the dragon for " + dmg + " damage.");
        //         return dmg;
                
            
        //     Console.WriteLine("\nYou try to use your skill but you are too tired to manage it.");
            
        }
    }
}