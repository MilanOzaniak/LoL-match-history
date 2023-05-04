
using System.Collections;

bool isRunning = true;
int length = 0;
int a = 0;
Hashtable matches = new Hashtable();
GetUser user = new GetUser();
getMatchHistory getMatchHistory = new getMatchHistory();


Console.WriteLine("[User Name]");
string? input = Console.ReadLine();


if (input != null)
{
    Summoner summoner = await user.getUser(input);
    Console.WriteLine("[User Name][Level]");
    Console.WriteLine($"{summoner.Name} ({summoner.SummonerLevel})");
    
    if(summoner.Puuid != null){

        List<string> matchHistory = await getMatchHistory.GetMatchId(summoner.Puuid);
        length = matchHistory.Count();
        foreach(var match in matchHistory){
            a += 1;
            matches.Add(a, match);
            Console.WriteLine($"[{a}] {match}");
        }
    }

    while (isRunning){
        Console.WriteLine($"Choose game [1 - {length}] (n --> to stop) :");
        string? inp = Console.ReadLine();

        if (inp == "n"){
            isRunning = false;
        }
        else{
            if(inp != null){
                    await getMatchHistory.GetMatchData((string)matches[Int32.Parse(inp)]);
            }

        }




    }
    
}
