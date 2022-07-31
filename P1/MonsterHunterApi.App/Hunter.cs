using System.Globalization;

namespace MonsterHunterApi.App
{
    public class Hunter{
        
        Random rand = new Random();

        List<MonsterDTO> monster;
        TextInfo Ti = new CultureInfo("en-US",false).TextInfo;

        List<string> monstertype = new List<string>(){
            "Amphibian","Bird Wyvern","Brute Wyvern","Carapaceon","Elder Dragon","Fanged Beast","Fanged Wyvern","Flying Wyvern","Leviathan","Piscine Wyvern","Temnoceon"
        };
        
        public Hunter(List<MonsterDTO> monster){
            this.monster = monster;
        }


        // methods

        public void Menu(){
            Console.WriteLine("Welcome to Monster Hunter");
            bool test = true;
            List<string> mon = makemonsterList(monster);
            while(test){
                Console.WriteLine("\nWhat would you like to do.\n(Insert the number of the option.)");
                Console.WriteLine("1: Hunt a certain monster");
                Console.WriteLine("2: Hunt a random monster");
                Console.WriteLine("3: Search up all monsters of a certain type");
                Console.WriteLine("4: Check the number of times you all monsters you hunted");
                Console.WriteLine("0: Close the application\n");
                string input = Console.ReadLine();
                string input1 ="";
                MonsterDTO mons = new MonsterDTO();
                switch(input){
                    case "1":
                        while(!mon.Contains(input)){
                            Console.WriteLine("Which monster do you want to hunt");
                            input = Console.ReadLine();
                            input = Ti.ToTitleCase(input);
                            if(mon.Contains(input)){
                                foreach(var item in monster){
                                    if(item.name == input){
                                        mons = item;
                                    }
                                }  
                            }
                            else{
                                Console.WriteLine("\nYou may have spelled it incorrectly. Try again.");
                            }  
                        }
                        Hunt(mons);
                        while(input != "y" && input != "n"){
                            Console.WriteLine("Do you want to go back to menu? [y/n]");
                            input = Console.ReadLine();
                            if(input == "y" || input == "n"){
                                switch(input){
                                    case "y":
                                        break;
                                    case "n":
                                        test = false;
                                        Console.WriteLine("Thank You for hunting!");
                                        break;
                                }
                            }
                            else{
                                Console.WriteLine("\nIncorrect input. Try Again.");
                                continue;
                            }
                        }
                        break;
                    case "2":
                        RandomHunt();
                        while(input != "y" && input != "n"){
                            Console.WriteLine("Do you want to go back to menu? [y/n]");
                            input = Console.ReadLine();
                            if(input == "y" || input == "n"){
                                switch(input){
                                    case "y":
                                        break;
                                    case "n":
                                        test = false;
                                        Console.WriteLine("Thank You for hunting!");
                                        break;
                                }
                            }
                            else{
                                Console.WriteLine("\nIncorrect input. Try Again.");
                                continue;
                            }
                        }
                        break;
                    case "3":
                        
                        while(!monstertype.Contains(input1)){
                            Console.WriteLine("Which type do you want to search? \nAmphibian, Bird Wyvern, Brute Wyvern, Carapaceon, Elder Dragon,\nFanged Beast, Fanged Wyvern, Flying Wyvern, Leviathan, Piscine Wyvern, Temnoceon\n");
                            input1 = Console.ReadLine();
                            Console.WriteLine("\n");
                            if(monstertype.Contains(input1)){
                                SearchMonsterType(input1);
                            }
                            else{
                                Console.WriteLine("\nYou may have spelled it incorrectly. Try again.");
                            }
                        }
                        while(input != "y" && input != "n"){
                            Console.WriteLine("Do you want to go back to menu? [y/n]");
                            input = Console.ReadLine();
                            if(input == "y" || input == "n"){
                                switch(input){
                                    case "y":
                                    break;
                                    case "n":
                                        test = false;
                                        Console.WriteLine("Thank You for hunting!");
                                        break;
                                }
                            }
                            else{
                                Console.WriteLine("\nIncorrect input. Try Again.");
                                continue;
                            }
                            
                        }
                        break;
                    case "4":
                        foreach(var item in monster){
                            Console.WriteLine("{0}:{1}",item.name,item.timeshunted);
                        }
                        Console.WriteLine("");
                        while(input != "y" && input != "n"){
                            Console.WriteLine("Do you want to go back to menu? [y/n]");
                            input = Console.ReadLine();
                            if(input == "y" || input == "n"){
                                switch(input){
                                    case "y":
                                        break;
                                    case "n":
                                        test = false;
                                        Console.WriteLine("Thank You for hunting!");
                                        break;
                                }
                            }
                            else{
                                Console.WriteLine("\nIncorrect input. Try Again.");
                                continue;
                            }
                        }
                        break;
                    case "0":
                        test=false;
                        Console.WriteLine("Thank You for hunting!");
                        break;
                    default:
                        Console.WriteLine("You put in an incorrect input. Try again.");
                        break;

                }
            }

        }
        public void RandomHunt(){
            int next = rand.Next(0,this.monster.Count);
            Console.WriteLine("\nYou will be hunting {0}.",this.monster[next].name);
            Hunt(this.monster[next]);

        }

        public void Hunt(MonsterDTO monstie){
            monstie.timeshunted += 1;
            List<int> weakness = new List<int>();
            weakness.Add(monstie.fire); 
            weakness.Add(monstie.water);
            weakness.Add(monstie.thunder);
            weakness.Add(monstie.ice);
            weakness.Add(monstie.dragon);
            int highest = weakness.Max();
            if(monstie.fire == highest && monstie.water == highest && monstie.thunder == highest && monstie.ice == highest){
                Console.WriteLine("When hunting a {0}, use any elemental weapon except for a dragon weapon.\n",monstie.name);
            }
            else if(monstie.fire == highest){
                Console.WriteLine("When hunting a {0}, use a fire elemental weapon. \n",monstie.name);
            }
            else if(monstie.water == highest){
                Console.WriteLine("When hunting a {0}, use a water elemental weapon.\n",monstie.name);
            }
            else if(monstie.thunder == highest){
                Console.WriteLine("When hunting a {0}, use a thunder elemental weapon.\n",monstie.name);
            }
            else if(monstie.ice == highest){
                Console.WriteLine("When hunting a {0}, use a ice elemental weapon.\n",monstie.name);
            }
            else if(monstie.dragon == highest){
                Console.WriteLine("When hunting a {0}, use a dragon elemental weapon.\n",monstie.name);
            }
        }
        
        public void SearchMonsterType(string monstietype){
            
            foreach(var item in monster){
                if(item.monsterType == monstietype){
                    Console.WriteLine(item.name);
                }
            }
            
        }
        public List<string> makemonsterList(List<MonsterDTO> monstie){
            List<string> mon = new List<string>();
            foreach(var item in monstie){
                mon.Add(item.name);
            }
            return mon;
        }
    }
}