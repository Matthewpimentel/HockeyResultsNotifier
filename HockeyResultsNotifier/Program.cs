using HockeyResultsNotifier;
using HtmlAgilityPack;
using System.Threading.Tasks.Sources;

List<GameResult> results = new List<GameResult>();

HtmlWeb web = new HtmlWeb();

List<int> scoresToKeep = new List<int>();

HtmlDocument document = web.Load("https://www.hockey-reference.com/boxscores/");

GetUserEmail();


var teamNames = document.DocumentNode.SelectNodes("//div[@id=\"wrap\"]//div[@class=\"game_summaries\"]//div/table/tbody/tr/td[not(contains(@class, \"gamelink\"))]/a");
var scores = document.DocumentNode.SelectNodes("//div[@id=\"wrap\"]//div[@class=\"game_summaries\"]//div/table/tbody/tr/td[@class=\"right\"]");


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

void GetUserEmail()
{

    string filePath = "email.txt";
    if (!File.Exists(filePath)) {
        Console.WriteLine("Please enter your email to receieve updates to!\n");
        string email = Console.ReadLine();

        try
        {
            File.WriteAllText(filePath, email);
            Console.WriteLine($"Email '{email}' has been saved to '{filePath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving the email: {ex.Message}");
        }
    }
}


if (File.Exists("email.txt"))
{
    Email email = new Email();
    string emailText = File.ReadAllText("email.txt");
    Console.WriteLine(emailText);
    email.SendEmail(results, emailText);
}



