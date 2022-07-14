using System;


namespace ProjectZero{

    class Game{
        
        // Player player = new Player();
        Dictionary<string, int> h = new Dictionary<string, int>();
        static void Main(string[] args){
            bool test;
            int classId;
            Dictionary<string, int> h = new Dictionary<string, int>();
            do{
                Console.WriteLine("\nWelcome to Dragon Battle \nChoose your Class by typing the number next to the class \n1.Warrior      HP:50 SP:15\n2.Mage         HP:36 SP:25\n3.Gunslinger   HP:43 SP:20\n");
                string input = Console.ReadLine();
                test = int.TryParse(input, out classId) && (input == "1" || input == "2" || input == "3"); 
            }while(!test);
            Player player = createClass(classId);
            h = player.createSkillList();
            Dragon dragon  = new Dragon();     
            playGame(dragon, player, h);
            
        }

        static Player createClass(int classname){
            if(classname == 1){
                    Warrior player = new Warrior();
                    player.initializeClass();
                    return player;
            }
            else if(classname == 2){
                    Mage player = new Mage();
                    player.initializeClass();
                    return player;
            }

            else if(classname == 3){
                    Gunslinger player = new Gunslinger();
                    player.initializeClass();
                    return player;
            }
            return null;
        } 
        
        static void playGame(Dragon dragon, Player player, Dictionary<string, int> h){
            bool test;
            string action;
            while(dragon.health >0 && player.getHealth() > 0){
                do{
                    Console.WriteLine("\nDragon Health:"+dragon.displayHealth()+"\n \nHP:" + player.getHealth() + "/"+player.maxhealth+"   SP:" + player.sp + "   Health Potions:" + player.healthpot +  "\n \nActions: \nAttack   Skills      Heal(Heals 15)");
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
                player.setHealth(player.getHealth()- dragon.attack()) ;
            }
            bool trueending = (dragon.health <=0 && player.getHealth()>0);
            bool badending = (dragon.health >0 && player.getHealth()<=0);
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
