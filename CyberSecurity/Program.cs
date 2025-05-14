using System;
using System.IO; // For file path checks
using NAudio.Wave;
using System.Threading; // Required for sleep delays
using System.Collections.Generic;

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
        static string rememberedTopic = "";
        static string userMood = "";
        private static object input;

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

            ShowRememberedInfo();
            BasicResponseSystem();

            // Keep the console open for further interaction
            while (true)
            {
                Console.WriteLine("\nType your question about cybersecurity, or type a number for a predefined question, or 'exit' to quit.");
                string input = Console.ReadLine();

                // Check for exit command
                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Thank you for using the Cybersecurity Awareness Bot! Stay safe online.");
                    break;
                }

                // Attempt to parse input as an integer
                if (int.TryParse(input, out int choice))
                {
                    string response = "";
                    switch (choice)
                    {
                        case 1:
                            response = "I'm just a program, but I’m here to help you!";
                            break;
                        case 2:
                            response = "My purpose is to assist you with cybersecurity awareness and provide tips!";
                            break;
                        case 3:
                            response = "Here are some tips on password safety: Use strong, unique passwords for every account, avoid using birthdays or names in your passwords, and enable two-factor authentication.";
                            break;
                        case 4:
                            response = "A phishing attack is when someone tries to trick you into revealing sensitive information via fake emails or websites.";
                            break;
                        case 5:
                            response = "To browse safely, ensure your software is up to date, avoid clicking on suspicious links, and use secure connections.";
                            break;
                        case 6:
                            response = "You can ask me about password safety, scams, phishing, privacy, and how to stay secure online.";
                            break;
                        default:
                            response = "Please select a valid option number.";
                            break;
                    }
                    DisplayColoredText(response);
                }
                else
                {
                    // Process as a question
                    if (!string.IsNullOrWhiteSpace(userMood))
                    {
                        Console.WriteLine($"I can tell you're feeling {userMood}. Let’s make sure you get the help you need.");
                    }

                    string response = GetResponse(input);
                    DisplayColoredText(response);
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
            static void ShowRememberedInfo()
            {
                if (!string.IsNullOrWhiteSpace(rememberedTopic))
                {
                    Console.WriteLine($"Remember, you're interested in {rememberedTopic}. Ask me more about that anytime!");
                }
            }

            static string GetResponse(string input)
            {
                input = input.ToLower();

                // Sentiment detection
                if (input.Contains("worried") || input.Contains("nervous") || input.Contains("anxious"))
                {
                    userMood = "worried";
                    return "It's completely understandable to feel that way. Cyber threats can be scary, but I'm here to help you stay safe.";
                }
                if (input.Contains("curious") || input.Contains("interested"))
                {
                    userMood = "curious";
                    return "Curiosity is a great start to learning about cybersecurity! Ask me anything.";
                }
                if (input.Contains("frustrated"))
                {
                    userMood = "frustrated";
                    return "I'm sorry you're feeling frustrated. Let's try to work through your concerns together.";
                }


                // Memory recall
                if (input.Contains("i'm interested in"))
                {
                    int index = input.IndexOf("i'm interested in") + 17;
                    rememberedTopic = input.Substring(index).Trim();
                    return $"Great! I'll remember that you're interested in {rememberedTopic}. It's a crucial part of staying safe online.";
                }
                if (rememberedTopic != "" && input.Contains("remind me"))
                {
                    return $"As someone interested in {rememberedTopic}, you might want to explore your account privacy settings and limit data sharing.";
                }

                // Keyword-based responses
                var keywordResponses = new Dictionary<string, List<string>>()
    {
        { "password", new List<string> {
            "Use strong, unique passwords for every account.",
            "Avoid using birthdays or names in your passwords.",
            "Enable two-factor authentication wherever possible."
        }},
        { "scam", new List<string> {
            "Never click on suspicious links or attachments.",
            "Verify the identity of senders before giving out information.",
            "If something feels too good to be true, it probably is."
        }},
        { "privacy", new List<string> {
            "Check your social media privacy settings regularly.",
            "Avoid sharing personal details on public platforms.",
            "Use secure, encrypted communication channels when possible."
        }},
        { "phishing", new List<string> {
            "Be cautious of emails requesting personal information.",
            "Phishers often impersonate trusted organizations—always verify!",
            "Hover over links to check their real destination before clicking."
        }},
    };

                foreach (var keyword in keywordResponses.Keys)
                {
                    if (input.Contains(keyword))
                    {
                        var responses = keywordResponses[keyword];
                        Random rand = new Random();
                        return responses[rand.Next(responses.Count)];
                    }
                }

                // Handling confusion
                if (input.Contains("more details") || input.Contains("not sure"))
                {
                    return rememberedTopic != ""
                        ? $"Here's more on {rememberedTopic}: Ensure your software is updated and use antivirus tools to stay secure."
                        : "Sure, can you tell me which topic you'd like more details on?";
                }

                // Known general inputs
                if (input.Contains("1."))
                    return "I’m just a program, but I’m here to help you!";
                if (input.Contains("2."))
                    return "My purpose is to assist you with cybersecurity awareness and provide tips!";
                if (input.Contains("6."))
                    return "You can ask me about password safety, scams, phishing, privacy, and how to stay secure online.";

                return "I’m not sure I understand. Can you try rephrasing or ask about something cybersecurity-related?";
            }

            static void BasicResponseSystem()
            {
                Console.WriteLine("You can ask me general questions by typing or choosing a number:");

                Console.WriteLine("1. How are you?");
                Console.WriteLine("2. What’s your purpose?");
                Console.WriteLine("3. Can you tell me about password safety?");
                Console.WriteLine("4. What is phishing?");
                Console.WriteLine("5. How to browse safely?");
                Console.WriteLine("6. What can I ask you about?");
            }

            static string GenerateRandomName()
            {
                string[] names = { "User1", "User2", "Guest", "Friend" };
                Random rand = new Random();
                return names[rand.Next(names.Length)];
            }

        }
    }
}
