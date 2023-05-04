using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class getMatchHistory{
    public async Task<List<string>> GetMatchId(string Puuid){
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://europe.api.riotgames.com");
            client.DefaultRequestHeaders.Add("X-Riot-Token","RGAPI-77c2c7d8-0c11-45f0-9b77-dc5459ce5c34");
            var response = await client.GetAsync($"/lol/match/v5/matches/by-puuid/{Puuid}/ids");
            return await response.Content.ReadAsAsync<List<string>>();
    }

    public async Task GetMatchData(string gameId){
        using var client = new HttpClient();
        client.BaseAddress = new Uri("https://europe.api.riotgames.com");
        client.DefaultRequestHeaders.Add("X-Riot-Token","RGAPI-77c2c7d8-0c11-45f0-9b77-dc5459ce5c34");
        var response = await client.GetAsync($"/lol/match/v5/matches/{gameId}");

        var responseContent = await response.Content.ReadAsStringAsync();
        var participant = JObject.Parse(responseContent)["info"]["participants"];
        Console.WriteLine("                     Team1                                      Team2");
        Console.Write($" [TOP]    {participant[0]["championName"]}, K: {participant[0]["kills"]}, D: {participant[0]["deaths"]}, A: {participant[0]["assists"]}, CS: {participant[0]["totalMinionsKilled"]}");
        Console.Write("|");
        Console.WriteLine($" CS: {participant[5]["totalMinionsKilled"]}, A: {participant[5]["assists"]}, D: {participant[5]["deaths"]}, K: {participant[5]["kills"]}, {participant[5]["championName"]}");
        Console.Write($"[JUNGLE]  {participant[1]["championName"]}, K: {participant[1]["kills"]}, D: {participant[1]["deaths"]}, A: {participant[1]["assists"]}, CS: {participant[1]["totalMinionsKilled"]}");
        Console.Write("|");
        Console.WriteLine($" CS: {participant[6]["totalMinionsKilled"]}, A: {participant[6]["assists"]}, D: {participant[6]["deaths"]}, K: {participant[6]["kills"]}, {participant[6]["championName"]}");
        Console.Write($" [MID]    {participant[2]["championName"]}, K: {participant[2]["kills"]}, D: {participant[2]["deaths"]}, A: {participant[2]["assists"]}, CS: {participant[2]["totalMinionsKilled"]}");
        Console.Write("|");
        Console.WriteLine($" CS: {participant[7]["totalMinionsKilled"]}, A: {participant[7]["assists"]}, D: {participant[7]["deaths"]}, K: {participant[7]["kills"]}, {participant[7]["championName"]}");
        Console.Write($" [ADC]    {participant[3]["championName"]}, K: {participant[3]["kills"]}, D: {participant[3]["deaths"]}, A: {participant[3]["assists"]}, CS: {participant[3]["totalMinionsKilled"]}");
        Console.Write("|");
        Console.WriteLine($" CS: {participant[8]["totalMinionsKilled"]}, A: {participant[8]["assists"]}, D: {participant[8]["deaths"]}, K: {participant[8]["kills"]}, {participant[8]["championName"]}");
        Console.Write($"[SUPPORT] {participant[4]["championName"]}, K: {participant[4]["kills"]}, D: {participant[4]["deaths"]}, A: {participant[4]["assists"]}, CS: {participant[4]["totalMinionsKilled"]}");
        Console.Write("|");
        Console.WriteLine($" CS: {participant[9]["totalMinionsKilled"]}, A: {participant[9]["assists"]}, D: {participant[9]["deaths"]}, K: {participant[9]["kills"]}, {participant[9]["championName"]}");
    }
}

