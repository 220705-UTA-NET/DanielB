using System;

namespace ProjectZero{

    class Mage : Player{
        Random rand = new Random();
        private int dmglow = 4;
        private int dmghigh = 6;

        override public void initializeClass(){
            this.setHealth(36);
            this.setSp(25);
            this.setMaxHealth(36);
        }

        Dictionary<string, int> skillList = new Dictionary<string, int>();       
        override public Dictionary<string, int> createSkillList(){
            skillList.Add("1:Magic Missile", (5)); //(21,25),
            skillList.Add("2:Fireball",(15)); //(45,50),
            return skillList;

        }
        override public int attack(){
            //  return the dmg number for the basic attack based on the class
            int dmg = rand.Next(dmglow,dmghigh +1);              
            Console.WriteLine("\nYou swipe your dagger at the dragon for " + dmg + " damage.");
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
                    keyskill = "1:Magic Missile";
                }
                else if (name == 2){
                    keyskill = "2:Fireball";
                }
                else{
                    keyskill = "";
                }
            }while(!test);
            if(this.getSP() >= skilllist[keyskill]){
                switch(name){
                    case 1:
                        int dmg = rand.Next(21,26);
                        this.setSp(this.getSP() - skilllist[keyskill]);
                        Console.WriteLine("\nYou cast your arcane energy bolts at the dragon for " + dmg + " damage.");
                        return dmg;
                    case 2:
                        dmg = rand.Next(45,51);
                        this.setSp(this.getSP() - skilllist[keyskill]);
                        Console.WriteLine("\nYou summon a fiery ball of energy to char the dragon " + dmg + " damage.");
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


    