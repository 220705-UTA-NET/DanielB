using System;

namespace ProjectZero{

    class Gunslinger : Player{
        Random rand = new Random();
        private int dmglow = 7;
        private int dmghigh = 9;

        override public void initializeClass(){
            this.setHealth(43);
            this.setSp(20);
            this.setMaxHealth(43);;
        }

        Dictionary<string, int> skillList = new Dictionary<string, int>();       
        override public Dictionary<string, int> createSkillList(){
            skillList.Add("1:Snipe Shot", 5); 
            skillList.Add("2:Trick Shot",15); 
            return skillList;
        }
        override public int attack(){
            //  return the dmg number for the basic attack based on the class
            int dmg = rand.Next(dmglow,dmghigh +1);              
            Console.WriteLine("\nYou shoot your pistols at the dragon for " + dmg + " damage.");
            return dmg;    
        }
        override public int skillattack(Dictionary<string, int> skilllist){
            // checks to see if you have enough sp to return the dmg number for the skill based on the class
            bool test;
            string action;
            int name;
            string keyskill;
            do{
                Console.WriteLine("\nSP:"+this.getSP()+ "\nType the number next the action you want to do");
                displaySkillList(skilllist);
                action = Console.ReadLine();
                action = action.ToLower();
                action = action.TrimEnd();
                Console.Clear();
                test = int.TryParse(action, out name) && (action == "1" || action == "2");
                if (name == 1){
                    keyskill = "1:Snipe Shot";
                }
                else if (name == 2){
                    keyskill = "2:Trick Shot";
                }
                else{
                    keyskill = "";
                }
            }while(!test);
            if(this.getSP() >= skilllist[keyskill]){
                switch(name){
                    case 1:
                        int dmg = rand.Next(11,26);
                        this.setSp(this.getSP() - skilllist[keyskill]);
                        Console.WriteLine("\nYou aim your musket between the dragon's eyes for " + dmg + " damage.");
                        return dmg;
                    case 2:
                        dmg = rand.Next(45,51);
                        this.setSp(this.getSP() - skilllist[keyskill]);
                        Console.WriteLine("\nYou ricochet the bullet off of the cave wall to hit the dragon in the eye for " + dmg + " damage.");
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