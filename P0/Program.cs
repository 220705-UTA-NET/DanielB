using System;


namespace Game{

    class Game{
        

        static void Main(string[] args){
            Dragon dragon  = new Dragon();
            Player player  = new Player();
            bool test;
            int classname;
            do{
                
                Console.WriteLine("Welcome to Dragon Battle \nChoose your Class by selecting the number next to the class \n1.Warrior\n2.Mage\n3.Gunslinger");
                string input = Console.ReadLine();
                test = int.TryParse(input, out classname) && (input == "1" || input == "2" || input == "3"); 
            }while(!test);
            
            player.setClass(classname);          
            
            while(dragon.health >0 && player.health > 0){
                Console.WriteLine("HP:" + player.health + "   SP:" + player.sp +  "\nAttack   " + player.skill +  "      Heal");
                string action = Console.ReadLine();
                string skill = player.skill;
                if(action == "Attack"){
                    dragon.health -= player.attack();
                 }
                else if(action == skill){
                    dragon.health -= player.skillattack();
                }
                else if(action == "Heal"){
                    player.heal();
                }
                Console.WriteLine("player health" + player.health + " dragon health" + dragon.health);
                
            }
        }

        
    }
}
