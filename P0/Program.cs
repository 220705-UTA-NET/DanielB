using System;


namespace ProjectZero{

    class Game{
        

        static void Main(string[] args){
            bool test;
            int classname;
            Dictionary<string, int> h = new Dictionary<string, int>();
            do{
                
                Console.WriteLine("\nWelcome to Dragon Battle \nChoose your Class by typing the number next to the class \n1.Warrior      HP:50 SP:15\n2.Mage         HP:36 SP:25\n3.Gunslinger   HP:43 SP:20\n");
                string input = Console.ReadLine();
                test = int.TryParse(input, out classname) && (input == "1" || input == "2" || input == "3"); 
            }while(!test);
            Player player = createClass(classname);
            // h = player.createSkillList();
            Dragon dragon  = new Dragon();
            Console.WriteLine(player.health);

            // Player player  = new Player();      
            string action;
            while(dragon.health >0 && player.health > 0){
                do{
                    Console.WriteLine("Test");
                    Console.WriteLine("\nDragon Health:"+dragon.displayHealth()+"\n \nHP:" + player.health + "/"+player.maxhealth+"   SP:" + player.sp + "   Health Potions:" + player.healthpot +  "\n \nActions: \nAttack   Skills      Heal(Heals 15)");
                    action = Console.ReadLine();
                    action = action.ToLower();
                    action = action.TrimEnd();
                    test = (action=="attack" || action == "skills" || action == "heal");
                }while(!test);
                
                
                if(action == "attack"){
                    dragon.health -= player.attack();
                }
                else if(action == "skills"){
                    dragon.health -= player.skillattack(h);
                }
                else if(action == "heal"){
                    player.heal();
                }
                player.health -= dragon.attack();
            }
            // bool trueending = (dragon.health <=0 && player.health>0);
            // bool badending = (dragon.health >0 && player.health<=0);
            // bool herosending =(dragon.health <=0 && player.health<=0);
            if(dragon.health<=0){
                Console.WriteLine("\nThe dragon is defeated and the town is safe. \nYOU WIN!");
            }
            else if(player.health<=0){
                Console.WriteLine("\nThe dragon eats you and the town is burned \nYOU DIED");
            }
            
        }

        static Player createClass(int classname){
            if(classname == 1){
                    Warrior player = new Warrior();
                    return player;
            }
            else if(classname == 2){
                    Mage player = new Mage();
                    return player;

            }
            else if(classname == 2){
                    Gunslinger player = new Gunslinger();
                    return player;
            }
            return null;
        } 
        
    }
}
