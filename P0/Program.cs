using System;


namespace ProjectZero{

    class Game{
        

        static void Main(string[] args){
            Mage player = new Mage();
            player.createSkillList();
            
            player.displaySkillList();
            Console.WriteLine("Done");
            // Dragon dragon  = new Dragon();
            // bool test;
            // int classname;
            // do{
                
            //     Console.WriteLine("\nWelcome to Dragon Battle \nChoose your Class by typing the number next to the class \n1.Warrior      HP:50 SP:15\n2.Mage         HP:36 SP:25\n3.Gunslinger   HP:43 SP:20\n");
            //     string input = Console.ReadLine();
            //     test = int.TryParse(input, out classname) && (input == "1" || input == "2" || input == "3"); 
            // }while(!test);
            // switch(classname){
            //     case 1:
            //         Mage player = new Mage();
            //         break;
            // }
            // // Player player  = new Player();      
            // string action;
            // // string skills = player.skill;
            // // skills = skills.ToLower();
            // while(dragon.health >0 && player.health > 0){
            //     do{
            //         Console.WriteLine("\nDragon Health:"+dragon.displayHealth()+"\n \nHP:" + player.health + "/"+player.maxhealth+"   SP:" + player.sp + "   Health Potions:" + player.healthpot +  "\n \nActions: \nAttack   " + player.skill +  "(Uses 5 SP)      Heal(Heals 15)");
            //         action = Console.ReadLine();
            //         action = action.ToLower();
            //         action = action.TrimEnd();
            //         test = (action=="attack" || action == skills || action == "heal");
            //     }while(!test);

                
            //     if(action == "attack"){
            //         dragon.health -= player.attack();
            //      }
            //     else if(action == skills){
            //         dragon.health -= player.skillattack();
            //     }
            //     else if(action == "heal"){
            //         player.heal();
            //     }
            //     player.health -= dragon.attack();
            // }
            // // bool trueending = (dragon.health <=0 && player.health>0);
            // // bool badending = (dragon.health >0 && player.health<=0);
            // // bool herosending =(dragon.health <=0 && player.health<=0);
            // if(dragon.health<=0){
            //     Console.WriteLine("\nThe dragon is defeated and the town is safe. \nYOU WIN!");
            // }
            // else if(player.health<=0){
            //     Console.WriteLine("\nThe dragon eats you and the town is burned \nYOU DIED");
            // }
            
        }

        
    }
}
