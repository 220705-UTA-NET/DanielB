using System;


namespace ProjectZero{

    class Game{
        static void Main(string[] args){
            bool test;
            int classId;
            Dictionary<string, int> skilllist = new Dictionary<string, int>();
            Console.WriteLine("\nWelcome to Dragon Battle\n(Press Enter to continue)");
            Console.ReadLine();
            do{
                Console.WriteLine("\nChoose your Class by typing the number next to the class \n1.Warrior      HP:50 SP:15\n2.Mage         HP:36 SP:25\n3.Gunslinger   HP:43 SP:20\n");
                string input = Console.ReadLine();
                test = int.TryParse(input, out classId) && (input == "1" || input == "2" || input == "3"); 
            }while(!test);
            Player player = createClass(classId);
            skilllist = player.createSkillList();
            Dragon dragon  = new Dragon();     
            playGame(dragon, player, skilllist);
            
            
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
        
        static void playGame(Dragon dragon, Player player, Dictionary<string, int> skilllist){
            bool test;
            string action;
            int count = 0;
            Console.Beep();
            Console.Clear();
            while(dragon.GetHealth() >0 && player.getHealth() > 0){
                do{
                    Console.WriteLine("\nDragon Health:");
                    dragon.displayHealth();
                    Console.WriteLine("\n \nHP:" + player.getHealth() + "/"+player.getMaxHealth()+"   SP:" + player.getSP() + "   Health Potions:" + player.healthpot +  "\n \nActions: \nAttack   Skills      Heal(Heals 15)");
                    action = Console.ReadLine();
                    action = action.ToLower();
                    action = action.TrimEnd();
                    test = (action=="attack" || action == "skills" || action == "heal");
                }while(!test);
                Console.Clear();
                if(action == "attack"){
                    dragon.SetHealth(dragon.GetHealth() - player.attack());
                }
                else if(action == "skills"){
                    Console.Clear();
                    dragon.SetHealth(dragon.GetHealth() - player.skillattack(skilllist));
                }
                else if(action == "heal"){
                    player.heal();
                }
                player.setHealth(player.getHealth()- dragon.attack()) ;
                count += 1;
                
            }
            Score score = new Score();
            score.calculateScore(dragon,player,count);
        }
    }
}
