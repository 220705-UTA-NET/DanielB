using System;


namespace ProjectZero{

    class Game{
        

        static void Main(string[] args){
            Dragon dragon  = new Dragon();
            Player player  = new Player();
            bool test;
            int classname;
            do{
                
                Console.WriteLine("Welcome to Dragon Battle \nChoose your Class by typing the number next to the class \n1.Warrior      HP:50 SP:15\n2.Mage         HP:36 SP:35\n3.Gunslinger   HP:43 SP:25");
                string input = Console.ReadLine();
                test = int.TryParse(input, out classname) && (input == "1" || input == "2" || input == "3"); 
            }while(!test);
            
            player.setClass(classname);          
            string action;
            string skills = player.skill;
            while(dragon.health >0 && player.health > 0){
                do{
                    Console.WriteLine("\nDragon Health:"+dragon.health+"\n \nHP:" + player.health + "/"+player.maxhealth+"   SP:" + player.sp + "   Health Potions:" + player.healthpot +  "\n \nActions: \nAttack   " + player.skill +  "(Uses 5 SP)      Heal(Heals 15)");
                    skills = skills.ToLower();
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
            if(dragon.health<=0){
                Console.WriteLine("The dragon is defeated and the town is safe. \nYOU WIN!");
            }
            else if(player.health<=0){
                Console.WriteLine("The dragon eats you and the town is burned \nYOU DIED");
            }
            
        }

        
    }
}
