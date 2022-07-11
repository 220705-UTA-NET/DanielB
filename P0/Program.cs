using System;


namespace ProjectZero{

    class Game{
        

        static void Main(string[] args){
            Dragon dragon  = new Dragon();
            bool test;
            int classId;
            Console.WriteLine("\nWelcome to Dragon Battle");
            do{
                Console.WriteLine(" \nChoose your Class by typing the number next to the class \n1.Warrior      HP:50 SP:15\n2.Mage         HP:36 SP:25\n3.Gunslinger   HP:43 SP:20\n");
                string input = Console.ReadLine();
                test = int.TryParse(input, out classId) && (input == "1" || input == "2" || input == "3"); 
            }while(!test);
            Player player  = new Player(classId);      
            string action;
            string skills = player.skill;
            skills = skills.ToLower();
            while(dragon.health >0 && player.health > 0){
                do{
                    Console.WriteLine("\nDragon Health:"+dragon.displayHealth());
                    Console.WriteLine("\n"+ player.className +"\nHP:" + player.health + "/"+player.maxhealth+"   SP:" + player.sp + "   Health Potions:" + player.healthpot +  "\n \nActions: \nAttack   " + player.skill +  "(Uses 5 SP)      Heal(Heals 15)");
                    action = Console.ReadLine();
                    action = action.ToLower();
                    action = action.TrimEnd();
                    test = (action=="attack" || action == skills || action == "heal");
                }while(!test);

                
                if(action == "attack"){
                    dragon.health -= player.attack();
                 }
                else if(action == skills){
                    dragon.health -= player.skillattack();
                }
                else if(action == "heal"){
                    player.heal();
                }
                player.health -= dragon.attack();
            }
            bool trueending = (dragon.health <=0 && player.health>0);
            bool badending = (dragon.health >0 && player.health<=0);
            if(trueending){
                Console.WriteLine("\nYou stand on top of the defeated dragon's body with all the gold knowing the town is safe. \nYOU WIN!");
            }
            else if(badending){
                Console.WriteLine("\nThe dragon consumes you and burns the town to ashes. \nYOU DIED");
            }
            else{
                Console.WriteLine("\nAs you and the dragon collide in one final blow, the town is saved but at the cost of your own life. \nYou Win?");
            }   
        }
    }
}
