using System.Text.Json;

namespace MonsterHunterApi.App
{
    class Program{
        
        public static readonly HttpClient client = new HttpClient();
        private static string uri = "https://localhost:7033/api/Monsters";
        static async Task Main(){
            string response = await client.GetStringAsync(uri);
            
            List<MonsterDTO> monsters = JsonSerializer.Deserialize<List<MonsterDTO>>(response);
            Hunter hunter = new Hunter(monsters);
            hunter.Menu();
        }
    }
}