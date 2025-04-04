using System;
using System.Media;
using System.Threading;
using System.Text;

class Program
{
    private static string userName = "";
    private static readonly Random random = new Random();

    static void Main(string[] args)
    {
        Console.Title = "Cybersecurity Awareness Chatbot";
        Console.Clear();
        DisplayAsciiArt();
        PlayWelcomeGreeting();
        GetUserName();
        RunChatLoop();
    }

    static void PlayWelcomeGreeting()
    {
        try
        {
            SoundPlayer player = new SoundPlayer("welcome.wav");
            player.Play();
        }
        catch
        {
            TypeWriteEffect("Audio greeting unavailable. Welcome to the Cybersecurity Awareness Bot!", ConsoleColor.Yellow);
        }
    }

    static void DisplayAsciiArt()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
   _____      _                _____           _   
  / ____|    | |              |  __ \         | |  
 | (___   ___| |__   ___ _ __ | |__) |___  ___| |_ 
  \___ \ / __| '_ \ / _ \ '__||  _  // _ \/ __| __|
  ____) | (__| | | |  __/ |   | | \ \  __/\__ \ |_ 
 |_____/ \___|_| |_|\___|_|   |_|  \_\___||___/\__|
        ___         _   _   _           _   _              
       / __| __ _ _| |_| |_| |___ _ _  | |_| |_  ___ _ __  
       \__ \/ _` |_   _| '_ / -_) '_| |  _| ' \/ -_) '  \ 
       |___/\__,_| |_| |_,_\___|_|    \__|_||_\___|_|_|_|
");
        Console.ResetColor();

        DrawSectionHeader("CYBER BOT CHAT ASSISTANT", ConsoleColor.DarkYellow);
        Thread.Sleep(800);
    }

    static void GetUserName()
    {
        TypeWriteEffect("\nBefore we begin, what should I call you? ", ConsoleColor.White);
        userName = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(userName))
        {
            TypeWriteEffect("I didn't catch your name. Could you please tell me again? ", ConsoleColor.Red);
            userName = Console.ReadLine();
        }

        DrawSectionHeader($"WELCOME, {userName.ToUpper()}!", ConsoleColor.Green);
        TypeWriteEffect("I'm your Cybersecurity Awareness Assistant.\n", ConsoleColor.Cyan);
        TypeWriteEffect("I can help you with topics like:\n", ConsoleColor.White);
        TypeWriteEffect("• Password safety\n• Phishing detection\n• Safe browsing\n• General cybersecurity", ConsoleColor.Magenta);
        Console.WriteLine();
    }

    static void RunChatLoop()
    {
        string[] helpOptions = {
            "» How to create strong passwords",
            "» How to recognize phishing emails",
            "» Safe browsing practices",
            "» What's your purpose?",
            "» How are you?",
            "» Type 'exit' to end our chat"
        };

        DrawSectionHeader("HOW CAN I HELP YOU?", ConsoleColor.Blue);
        Console.ForegroundColor = ConsoleColor.Yellow;
        TypeWriteEffect("Here are some things you can ask me about:\n", 20);
        foreach (var option in helpOptions)
        {
            TypeWriteEffect(option + "\n", 30);
            Thread.Sleep(100);
        }
        Console.ResetColor();
        DrawDivider('═', ConsoleColor.DarkCyan);

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"\n[{userName}] ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("» ");
            Console.ResetColor();

            string input = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                TypeWriteEffect("I didn't hear anything. Could you repeat that?\n", 20);
                Console.ResetColor();
                continue;
            }

            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                DrawSectionHeader($"GOODBYE, {userName.ToUpper()}!", ConsoleColor.Blue);
                TypeWriteEffect("Remember to stay safe online!\n", ConsoleColor.Green);
                Thread.Sleep(1000);
                Environment.Exit(0);
            }

          
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("[Bot] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("» ");
            Console.ResetColor();
        }
    }

   

    #region UI Enhancement Methods
    static void TypeWriteEffect(string text, int delay = 30)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(random.Next(delay / 2, delay + 10));
        }
    }

    static void TypeWriteEffect(string text, ConsoleColor color, int delay = 30)
    {
        Console.ForegroundColor = color;
        TypeWriteEffect(text, delay);
        Console.ResetColor();
    }

    static void DrawSectionHeader(string text, ConsoleColor color)
    {
        Console.WriteLine();
        Console.ForegroundColor = color;
        Console.WriteLine($"╔{new string('═', text.Length + 2)}╗");
        Console.WriteLine($"║ {text} ║");
        Console.WriteLine($"╚{new string('═', text.Length + 2)}╝");
        Console.ResetColor();
        Thread.Sleep(300);
    }

    static void DrawDivider(char symbol, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(new string(symbol, Console.WindowWidth - 1));
        Console.ResetColor();
    }
    #endregion
}