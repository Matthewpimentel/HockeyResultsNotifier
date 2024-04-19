using HockeyResultsNotifier;
using HtmlAgilityPack;
using SportsResultsNotifier;
using SportsResultsNotifier.SportsScrappers;
using System.Threading.Tasks.Sources;

UserProperties userProperties = new UserProperties();

userProperties.GetUserEmail();
userProperties.GetUserSportsProperties();

HockeyRefrenceScrapper scrapper = new HockeyRefrenceScrapper();


if (File.Exists("email.txt"))
{
    Email email = new Email();
    string emailText = File.ReadAllText("email.txt");
    Console.WriteLine(emailText);
    email.SendEmail(scrapper.Scrape(), emailText);
}



