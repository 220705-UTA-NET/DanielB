using System.Text.Json;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace MonsterHunterApi.App
{
    class Program{
        //fields
        public static HttpClient client = new HttpClient();
        private static string uri = "https://localhost:7033/api/Monsters";
        public static Random rand = new Random();
        public static List<MonsterDTO> monsters = new List<MonsterDTO>();
        public static TextInfo Ti = new CultureInfo("en-US",false).TextInfo;
        public static List<string> monstertype = new List<string>(){
            "Amphibian","Bird Wyvern","Brute Wyvern","Carapaceon","Elder Dragon","Fanged Beast","Fanged Wyvern","Flying Wyvern","Leviathan","Piscine Wyvern","Temnoceon"
        };
        
        //methods
        static async Task Main(){
            string response = await client.GetStringAsync(uri);
            List<MonsterDTO> monsters = JsonSerializer.Deserialize<List<MonsterDTO>>(response);
            Menu(monsters);
        }
         

        public static async Task Menu(List<MonsterDTO> monsters){
            bool test = true;
            List<string> mon = makemonsterList(monsters);
            while(test){
                Console.Clear();
                Console.WriteLine("Welcome to Monster Hunter");
                Console.WriteLine("\nWhat would you like to do.\n(Insert the number of the option.)");
                Console.WriteLine("1: Hunt a certain monster");
                Console.WriteLine("2: Hunt a random monster");
                Console.WriteLine("3: Search up all monsters of a certain type");
                Console.WriteLine("4: Check the number of times you slayed a monster you hunted");
                Console.WriteLine("5: Check the number of times you slayed all monsters");
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
                                foreach(var item in monsters){
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
                        Thread.Sleep(1000);
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
                        RandomHunt(monsters);
                        Thread.Sleep(1000);
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
                            input1 = Ti.ToTitleCase(input1);
                            Console.WriteLine("\n");
                            if(monstertype.Contains(input1)){
                                SearchMonsterType(input1,monsters);
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
                        while(!mon.Contains(input)){
                            Console.WriteLine("Which monster do you want to see");
                            input = Console.ReadLine();
                            input = Ti.ToTitleCase(input);
                            if(mon.Contains(input)){
                                foreach(var item in monsters){
                                    if(item.name == input){
                                        mons = item; 
                                    }
                                }  
                            }
                            else{
                                Console.WriteLine("\nYou may have spelled it incorrectly. Try again.");
                            }  
                            Console.WriteLine("\n{0}:{1}",mons.name,mons.timeshunted);
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
                    case "5":
                        foreach(var item in monsters){
                            Console.WriteLine("\n{0}:{1}",item.name,item.timeshunted);
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
        public static void RandomHunt(List<MonsterDTO> monsters){
            int next = rand.Next(0,monsters.Count());
            Console.WriteLine("\nYou will be hunting {0}.",monsters[next].name);
            Hunt(monsters[next]);

        }

        public static async Task Hunt(MonsterDTO monstie){
            monstie.timeshunted += 1; 
            var content = new StringContent(JsonSerializer.Serialize(monstie));
            string newuri = uri+$"?id={monstie.id}&timesh={monstie.timeshunted}"; //

            await client.PutAsync(newuri.ToString(), content);

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
        
        public static void SearchMonsterType(string monstietype,List<MonsterDTO> monstie){
            
            foreach(var item in monstie){
                if(item.monsterType == monstietype){
                    Console.WriteLine(item.name);
                }
            }
            
        }
        public static List<string> makemonsterList(List<MonsterDTO> monstie){
            List<string> mon = new List<string>();
            foreach(var item in monstie){
                mon.Add(item.name);
            }
            return mon;
        }
    }
}