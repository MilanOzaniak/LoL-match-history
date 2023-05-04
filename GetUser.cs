
using System.Net.Http.Headers;
using Newtonsoft.Json;

public class GetUser{
    public async Task<Summoner> getUser(string name){
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("X-Riot-Token","RGAPI-77c2c7d8-0c11-45f0-9b77-dc5459ce5c34");
        client.BaseAddress = new Uri("https://eun1.api.riotgames.com");
        var response = await client.GetAsync($"/lol/summoner/v4/summoners/by-name/{name}");
        return await response.Content.ReadAsAsync<Summoner>();
    }
    
    
}

public class Summoner
{
    public string? Puuid { get; set; }
    public string? Name { get; set; }
    public long? SummonerLevel { get; set; }
}