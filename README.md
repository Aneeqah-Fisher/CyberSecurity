# Cybersecurity Awareness Bot

## Overview

The Cybersecurity Awareness Bot is a console-based interactive program designed to promote cybersecurity awareness in a friendly and engaging manner. It greets users with an audio message, displays ASCII art, gathers user information, and responds to questions related to cybersecurity topics. The bot can recognize keywords, detect user sentiment, and offer predefined answers or personalized responses.

---

## Features

- **Audio Greeting:** Plays a WAV audio file upon startup.
- **ASCII Art Display:** Shows a stylized logo to welcome users.
- **User Interaction:** Collects user name and favorite color to personalize the experience.
- **String Manipulation Challenge:** Demonstrates basic string reversing.
- **Conversation System:** Responds to user questions with keyword-based, sentiment-aware, and memory recall responses.
- **Predefined Menu:** Offers numbered options for quick answers about cybersecurity topics.
- **Continuous Interaction:** Runs in a loop until the user exits.

---

## Prerequisites

- **.NET Framework or .NET Core/SDK:** To compile and run the C# program.
- **NAudio Library:** Used for audio playback.

  **How to install NAudio:**
  - Using NuGet Package Manager:
    ```
    Install-Package NAudio
    ```
  - Or via the command line:
    ```
    dotnet add package NAudio
    ```

- **Audio File:** A WAV file named `Greeting.wav.wav` must exist in the specified directory:
  ```
  C:\Users\Zahrah Safudien\source\repos\CyberSecurity\CyberSecurity
  ```
  or update the path in the code accordingly.

---

## Setup Instructions

1. **Download/Clone the code:**

   Save the provided C# code into a file named `Program.cs`.

2. **Install Dependencies:**

   Using the command line in your project directory:
   ```
   dotnet add package NAudio
   ```

3. **Place the Audio File:**

   Ensure the greeting audio file is in the correct directory or update the path in the `PlayGreeting()` method.

4. **Build and Run:**

   - Using IDE like Visual Studio:
     - Open the project.
     - Restore NuGet packages.
     - Build and run.

   - Using command line:
     ```
     dotnet build
     dotnet run
     ```

---

## Usage

- The program will automatically play the greeting audio and display ASCII art.
- Follow prompts to enter your name and favorite color.
- Engage with the bot by typing questions or selecting options from the menu.
- Type `exit` to end the session.

---

## Notes

- Ensure the audio file path and filename are correct, or modify the code to point to your audio file.
- The program uses basic keyword detection and sentiment analysis for responses.
- Responses are randomized within categories for variety.
- The conversation loop continues until the user types `exit`.

---

## Troubleshooting

- **Audio not playing:** Verify the file path and filename; ensure the audio file exists.
- **Missing dependencies:** Run `dotnet restore` or use your IDE's package restore feature.
- **Compilation errors:** Ensure your environment supports C# and that all dependencies are installed.

---

## Contact & Feedback

For issues or suggestions, please contact the developer or submit feedback via your preferred platform.

---

## License

This project is for educational and awareness purposes. Feel free to modify and enhance it.

---

**Happy learning about cybersecurity!**
