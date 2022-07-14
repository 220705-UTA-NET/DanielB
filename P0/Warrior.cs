using System;
using System.Collections.Generic;

namespace ProjectZero{

    class Warrior : Player{
        Random rand = new Random();
        public int health;
        public int maxhealth;
        public int sp;
        private int dmglow = 10;
        private int dmghigh = 15;
        

        override public void initializeClass(){
            this.setHealth(50);
            this.setSp(15);
            this.setMaxHealth(50);
        }
        Dictionary<string, int> skillList = new Dictionary<string, int>();       
        override public Dictionary<string, int> createSkillList(){
            skillList.Add("1:Slash", (5)); //(15,20),
            skillList.Add("2:Lightning Cleave",15); //(30,40),
            return skillList;
        }
        override public int attack(){
            //  return the dmg number for the basic attack based on the class
            int dmg = rand.Next(dmglow,dmghigh +1);              
            Console.WriteLine("\nYou swipe at the dragon with your axe for " + dmg + " damage");
            return dmg;    
        }
        override public int skillattack(Dictionary<string, int> h){
            // checks to see if you have enough sp to return the dmg number for the skill based on the class
            
            bool test;
            string action;
            int name;
            string keyskill;
            do{
                Console.WriteLine("\nSP:"+this.getSP() + "\nType the number next the action you want to do");
                displaySkillList(h);
                action = Console.ReadLine();
                action = action.ToLower();
                action = action.TrimEnd();
                test = int.TryParse(action, out name) && (action == "1" || action == "2");
                if (name == 1){
                    keyskill = "1:Slash";
                }
                else if (name == 2){
                    keyskill = "2:Lightning Cleave";
                }
                else{
                    keyskill = "";
                }
            }while(!test);
            if(this.getSP() >= h[keyskill]){
                switch(name){
                    case 1:
                        int dmg = rand.Next(15,21);
                        this.setSp(this.getSP() - h[keyskill]);
                        Console.WriteLine("\nYou slash at the dragon's neck with your axe for " + dmg + " damage.");
                        return dmg;
                    case 2:
                        dmg = rand.Next(30,61);
                        this.setSp(this.getSP() - h[keyskill]);
                        Console.WriteLine("\nYou summon lightning on to your axe to cleave at the dragon's head for " + dmg + " damage.");
                        return dmg;
                    default:
                        return 0;
                }
            }
            else{
                Console.WriteLine("You do not have enough SP to use that skill");
                return 0;
            }
        }
    }
}