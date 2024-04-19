﻿using HockeyResultsNotifier;
using HtmlAgilityPack;
using System.Threading.Tasks.Sources;

List<GameResult> results = new List<GameResult>();

HtmlWeb web = new HtmlWeb();

HtmlDocument document = web.Load("https://www.hockey-reference.com/boxscores/");

var teamNames = document.DocumentNode.SelectNodes("//div[@id=\"wrap\"]//div[@class=\"game_summaries\"]//div/table/tbody/tr/td[not(contains(@class, \"gamelink\"))]/a");
var scores = document.DocumentNode.SelectNodes("//div[@id=\"wrap\"]//div[@class=\"game_summaries\"]//div/table/tbody/tr/td[@class=\"right\"]");

List<int> scoresToKeep = new List<int>();

for (int x = 0; x < scores.Count; x++)
{
    if (x % 3 != 2) // Keep every score that is not at index 2, 5, 8, etc.
    {
        scoresToKeep.Add(x);
    }
}

List<HtmlNode> filteredScores = new List<HtmlNode>();
foreach (int index in scoresToKeep)
{
    filteredScores.Add(scores[index]);
}

for (int i = 0; i < teamNames.Count; i++)
{
    if(i % 2 == 1)
    {
        GameResult gameResult = new GameResult(teamNames[i-1].InnerHtml, teamNames[i].InnerHtml, filteredScores[i-1].InnerHtml , filteredScores[i].InnerHtml);
        results.Add(gameResult);
    }
}

foreach(GameResult gameResult in results)
{
   Console.WriteLine(gameResult.ToString());
}


