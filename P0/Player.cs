using System;

namespace ProjectZero{
    class Player{
        //fields
        Random rand = new Random();
        public int health;
        public int maxhealth;
        public int sp;
        private int dmglow;
        private int dmghigh;
        public string skill;
        private int skilldmglow;
        private int skilldmghigh;

        public int healthpot = 3;

        int classname;
        
        public Player(int classname){
            switch(classname){
                case 1:
                    health = 50;
                    maxhealth = 50;
                    sp = 15;
                    skill = "Slash";
                    dmglow = 10;
                    dmghigh = 12;
                    skilldmglow = 15;
                    skilldmghigh = 20;
                    this.classname = classname;
                    break;
                case 2:
                    health = 36;
                    maxhealth = 36;
                    sp = 25;
                    skill = "Magic Missile";
                    dmglow = 4;
                    dmghigh = 6;
                    skilldmglow = 21;
                    skilldmghigh = 25;
                    this.classname = classname;
                    break;
                case 3:
                    health = 43;
                    maxhealth = 43;
                    sp = 20;
                    skill = "Snipe shot";
                    dmglow = 7;
                    dmghigh = 9;
                    skilldmglow = 11;
                    skilldmghigh = 25;
                    this.classname = classname;
                    break;
            }
        }
        //methods
        public int attack(){
            //  return the dmg number for the basic attack based on the class
            int dmg = rand.Next(dmglow,dmghigh +1);
            switch(classname){
                case 1:
                    Console.WriteLine("\nYou swipe at the dragon with your axe for " + dmg + " damage.");
                    return dmg;
                case 2:                
                    Console.WriteLine("\nYou swipe your dagger at the dragon for " + dmg + " damage.");
                    return dmg;
                case 3:
                    Console.WriteLine("\nYou shoot your pistols at the dragon for " + dmg + " damage.");
                    return dmg;
            }
            return 0;    
        }

        public int skillattack(){
            // checks to see if you have enough sp to return the dmg number for the skill based on the class
            if(sp!= 0){
                sp -= 5;
                int dmg = rand.Next(skilldmglow,skilldmghigh +1);
                switch(classname){
                case 1:
                    Console.WriteLine("\nYou slash at the dragon's neck with your axe for " + dmg + " damage.");
                    return dmg;
                case 2:                
                    Console.WriteLine("\nYou cast your arcane energy at the dragon for " + dmg + " damage.");
                    return dmg;
                case 3:
                    Console.WriteLine("\nYou aim your musket between the dragon's eyes for " + dmg + " damage.");
                    return dmg;
                }
            }
            Console.WriteLine("\nYou try to use your skill but you are too tired to manage it.");
            return 0;
        }

        public void heal(){
            //adds health to the player and makes sure it does not go over the max health for a player
            if(healthpot > 0){
                healthpot -=1; 
                if(health + 15 > maxhealth){
                    health = maxhealth;
                }
                else{
                    health +=15;
                }
            Console.WriteLine("You drink your potion, revitalizing you");
            }
            else{
                Console.WriteLine("\nYou wasted your turn trying to drink an empty bottle");
            }
        }    
    }
}