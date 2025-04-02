using System;
using System.IO; // For file path checks
using NAudio.Wave;
using System.Threading; // Required for sleep delays

namespace CybersecurityAwarenessBot
{
    // Class representing user data
    public class User
    {
        public string Name { get; set; }
        public string FavoriteColor { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Play the welcome voice greeting
            PlayGreeting();

            // Display ASCII Art Logo
            DisplayAsciiArt();

            // Create a new user
            User user = new User();

            // Get user name
            Console.Write("Please enter your name: ");
            user.Name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(user.Name))
            {
                Console.WriteLine("You didn't enter a name. Let's call you " + GenerateRandomName() + "!");
                user.Name = GenerateRandomName();
            }

            // Get user favorite color
            Console.Write("What is your favorite color? ");
            user.FavoriteColor = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(user.FavoriteColor))
            {
                Console.WriteLine("You didn't enter a favorite color. Let's use 'Blue' as default.");
                user.FavoriteColor = "Blue";
            }

            // Create a personalized greeting
            string greeting = $"Hello, {user.Name}! Your favorite color is {user.FavoriteColor.ToUpper()}.";
            DisplayColoredText(greeting);

            // String manipulation challenge
            Console.WriteLine("Let's have a little fun with your favorite color!");

            // Reverse the favorite color
            char[] colorArray = user.FavoriteColor.ToCharArray();
            Array.Reverse(colorArray);
            string reversedColor = new string(colorArray);

            // Display the reversed color
            Console.WriteLine($"Did you know that your favorite color reversed is: {reversedColor}?");

            // Basic response system
            BasicResponseSystem();

            // Keep the console open for further interaction
            while (true)
            {
                Console.WriteLine("\nType your question about cybersecurity, or type 'exit' to quit.");
                string input = Console.ReadLine();

                // Input validation
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid input! Please ask a question or type 'exit' to quit.");
                    continue;
                }

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Thank you for using the Cybersecurity Awareness Bot! Stay safe online.");
                    break;
                }
                else
                {
                    string response = GetResponse(input);
                    DisplayColoredText(response);
                }
            }
        }

        static void PlayGreeting()
        {
            // Define the music directory path for WAV file
            string musicDirectoryPath = @"C:\Users\Zahrah Safudien\source\repos\CyberSecurity\CyberSecurity";
            string audioFileName = "Greeting.wav.wav"; // Use a WAV file
            string audioFilePath = Path.Combine(musicDirectoryPath, audioFileName);

            Console.WriteLine("   Welcome to the Cybersecurity Awareness Bot!");
            try
            {
                // Check if the file exists
                if (File.Exists(audioFilePath))
                {
                    using (var audioFile = new AudioFileReader(audioFilePath))
                    using (var outputDevice = new WaveOutEvent())
                    {
                        outputDevice.Init(audioFile);
                        outputDevice.Play();
                        // Wait until playback completes
                        while (outputDevice.PlaybackState == PlaybackState.Playing)
                        {
                            Thread.Sleep(100); // Allow the audio to play
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Audio file not found.");
                }
            }
            catch (Exception ex)
            {
                // Catch and display any errors
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void DisplayAsciiArt()
        {
            string asciiArt = @"
     ,--.
    ( oo|
    _  `-'
   | |
  //| | 
 || | |
 || | |
-| | | |
|  \_/ |
 |     |
  `---' ";
            // Display the ASCII art header
            Console.WriteLine(asciiArt);
            
        }

        static void DisplayColoredText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        static string GetResponse(string input)
        {
            input = input.ToLower();

            if (input.Contains("how are you"))
            {
                return "I’m just a program, but I’m here to help you!";
            }
            else if (input.Contains("purpose"))
            {
                return "My purpose is to assist you with cybersecurity awareness and provide tips!";
            }
            else if (input.Contains("password safety"))
            {
                return "Always use strong, unique passwords for all your accounts and consider a password manager.";
            }
            else if (input.Contains("phishing"))
            {
                return "Be cautious of emails or messages requesting your personal information. Always verify the source.";
            }
            else if (input.Contains("safe browsing"))
            {
                return "Ensure websites are secure (look for HTTPS) and avoid clicking on suspicious links.";
            }
            else if (input.Contains("what can i ask you"))
            {
                return "You can ask me about password safety, phishing, safe browsing, and many other cybersecurity topics!";
            }
            else
            {
                return "I didn’t quite understand that. Could you rephrase?";
            }
        }

        static void BasicResponseSystem()
        {
            Console.WriteLine("You can ask me general questions. Here are a few examples:");
            Console.WriteLine("- How are you?");
            Console.WriteLine("- What’s your purpose?");
            Console.WriteLine("- Can you tell me about password safety?");
            Console.WriteLine("- What is phishing?");
            Console.WriteLine("- How to browse safely?");
            Console.WriteLine("- What can I ask you about?");
        }

        static string GenerateRandomName()
        {
            string[] names = { "User1", "User2", "Guest", "Friend" };
            Random rand = new Random();
            return names[rand.Next(names.Length)];
        }
    }
}