using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    private Level level; // Game state

    private readonly List<String> firstLevelPass = new List<string>
        {"dog", "cat", "pet", "pig", "tiger"};

    private readonly List<String> secondLevelPass = new List<string>
        {"spring", "hibernate", "orm", "garbage", "object"};

    private readonly List<String> thirdLevelPass = new List<string>
        {"anchor", "cloud", "google", "unity", "vuforia"};

    private enum Screen
    {
        MainMenu,
        WaitingForPassword,
        Win
    }

    private enum Level
    {
        First,
        Second,
        Third
    }

    private Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        var greeting = "Hello Sergey";
        Terminal.WriteLine(greeting);
        ShowMainMenu();
    }

    private void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the \"Animal\" theme.");
        Terminal.WriteLine("Press 2 for the \"Java\" theme.");
        Terminal.WriteLine("Press 3 for the \"AR\" theme.");
        Terminal.WriteLine("Press \"menu\" for clear screen.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection:");
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnUserInput(String message)
    {
        if ("menu".Equals(message))
        {
            ShowMainMenu();
        }
        else if (Screen.MainMenu == currentScreen)
        {
            RunMainMenu(message);
        }
        else if (Screen.WaitingForPassword == currentScreen)
        {
            CheckPassword(message);
        }
    }

    private void CheckPassword(string message)
    {
        switch (level)
        {
            case Level.First when firstLevelPass.Contains(message):
                Terminal.WriteLine("Success");
                Terminal.WriteLine("Success");
                ShowMainMenu();
                break;
            case Level.Second when secondLevelPass.Contains(message):
                Terminal.WriteLine("Success");
                Terminal.WriteLine("Success");
                ShowMainMenu();
                break;
            case Level.Third when thirdLevelPass.Contains(message):
                Terminal.WriteLine("Success");
                ShowMainMenu();
                break;
            default:
                Terminal.WriteLine("Try again");
                break;
        }
    }

    private void RunMainMenu(string message)
    {
        switch (message)
        {
            case "1":
                level = Level.First;
                StartGame();
                break;
            case "2":
                level = Level.Second;
                StartGame();
                break;
            case "3":
                level = Level.Third;
                StartGame();
                break;
            default:
                Terminal.WriteLine("Hello cheater. You chose secret level " + message);
                break;
        }
    }

    void StartGame()
    {
        currentScreen = Screen.WaitingForPassword;
        Terminal.WriteLine("Hello. You chose lvl " + level);
        Terminal.WriteLine("Please enter your password.");
    }
}