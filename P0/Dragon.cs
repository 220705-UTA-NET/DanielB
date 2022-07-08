using System;


namespace ProjectZero{
    class Dragon{
        Random rand = new Random();
        public int health = 100;
        
        public int attack(){
            //gets a random number to see if the dragon attack misses, hits, or crits 
            int randomattack = rand.Next(0,100);
            if(randomattack<25){
                Console.WriteLine("The dragon swipes and just misses you");
                return 0;
            }
            else if(randomattack>=25 && randomattack <75){
                int dmg = rand.Next(8,11);
                Console.WriteLine("The dragon swipes at you and hits you for " + dmg + " damage");
                return dmg;
            }
            else{
                int dmg = rand.Next(16, 21);
                Console.WriteLine("The dragon breathes fire on you for " + dmg + " damage");
                return dmg;
            }
        }

        

    }
}
