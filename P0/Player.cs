using System;

namespace ProjectZero{
    class Player{
        Random rand = new Random();
        public int health;
        public int maxhealth;
        public int sp;
        public int dmglow;
        public int dmghigh;
        public string skill;
        public int skilldmglow;
        public int skilldmghigh;

        public int healthpot = 3;
        


        public void setClass(int i){
            // initializes all the previously made variables to the class that the player chose on the console
            switch(i){
                case 1:
                    health = 50;
                    maxhealth = 50;
                    sp = 15;
                    skill = "Slash";
                    dmglow = 10;
                    dmghigh = 12;
                    skilldmglow = 15;
                    skilldmghigh = 20;
                    break;
                case 2:
                    health = 36;
                    maxhealth = 36;
                    sp = 35;
                    skill = "Magic Missile";
                    dmglow = 4;
                    dmghigh = 6;
                    skilldmglow = 21;
                    skilldmghigh = 30;
                    break;
                case 3:
                    health = 43;
                    maxhealth = 43;
                    sp = 25;
                    skill = "Snipe shot";
                    dmglow = 7;
                    dmghigh = 9;
                    skilldmglow = 11;
                    skilldmghigh = 14;
                    break;
            }
            
            
            

        }
        public int attack(){
            //  return the dmg number for the basic attack based on the class
            int dmg = rand.Next(dmglow,dmghigh +1);
            if(maxhealth == 50){
                Console.WriteLine("\nYou swipe at the dragon with your axe for " + dmg + " damage.");
            }
            else if(maxhealth == 36){
                Console.WriteLine("\nYou swipe your dagger at the dragon for " + dmg + " damage.");
            }
            else{
                Console.WriteLine("\nYou shoot your pistols at the dragon for " + dmg + " damage.");
            }
            return dmg;
        }

        public int skillattack(){
            // checks to see if you have enough sp to return the dmg number for the skill based on the class
            if(sp!= 0){
                sp -= 5;
                int dmg = rand.Next(skilldmglow,skilldmghigh +1);
                if(maxhealth == 50){
                    Console.WriteLine("\nYou slash at the dragon's neck with your axe for " + dmg + " damage.");
                }
                else if(maxhealth == 36){
                    Console.WriteLine("\nYou cast your arcane energy at the dragon for " + dmg + " damage.");
                }
                else{
                    Console.WriteLine("\nYou aim your musket between the dragon's eyes for " + dmg + " damage.");
                }
                return dmg;
            }
            Console.WriteLine("\nYou try to use your skill but you are too tired to magange it.");
            return 0;
        }

        public void heal(){
            if(healthpot > 0){
            healthpot -=1; 
            if(health + 15 > maxhealth){
                health = maxhealth;
            }
            else{
                health +=15;
            }
            }
            else{
                Console.WriteLine("\nYou wasted your turn trying to drink an empty bottle");
            }
        }    
    }
}