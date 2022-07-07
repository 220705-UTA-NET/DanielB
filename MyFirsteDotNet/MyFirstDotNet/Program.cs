using System;


namespace Game{

    class Game{
        

        static void Main(string[] args){
            Console.WriteLine("Welcome to Dragon Battle \nChoose your Class \n1.Warrior\n2.Mage\n3.Gunslinger");
            int response = int.Parse(Console.ReadLine());
            Dragon dragon  = new Dragon();
            Player player  = new Player();
            player.setClass(response);
            while(dragon.health >0 && player.health > 0){
                Console.WriteLine("HP:" + player.health + "   SP:" + player.sp +  "\nAttack   " + player.skill + "    Defend");
                Console.ReadLine();
                dragon.health -=30;
                Console.WriteLine("player health" + player.health + " dragon health" + dragon.health);
                
            }
        }

        
    }
}
