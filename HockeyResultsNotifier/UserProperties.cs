using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsResultsNotifier
{
    public class UserProperties
    {
        public string userEmail { get; set; }
        public Sports[] userSports { get; set; }

        public void GetUserEmail()
        {
            string filePath = "email.txt";
            if (!File.Exists(filePath))
            {
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

        public void GetUserSportsProperties()
        {
            string filePath = "userSportsProperties.txt";
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Please select the sports you would like emails for: 1:{Sports.Hockey}, 2:{Sports.Basketball}");
                Console.WriteLine("Enter the numbers of the sports you want (separated by spaces if selecting multiple):");
                string selection = Console.ReadLine();

                // Split the input by spaces to get individual selections
                string[] selectedSports = selection.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // Save the selected sports to the file
                SaveSelectedSportsToFile(filePath, selectedSports);

                Console.WriteLine("Selected sports saved successfully!");
            }
            else
            {
                Console.WriteLine("Sports preferences already set!");
            }
        }

        public static void SaveSelectedSportsToFile(string filePath, string[] selectedSports)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (string sport in selectedSports)
                {
                    writer.WriteLine(sport);
                }
            }
        }
    }
}
