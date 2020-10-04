using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    private int level; // Game state

    private enum Screen
    {
        MainMenu,
        WaitingForPassword,
        Win
    }

    private Screen currentScreen = Screen.MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        var greeting = "Hello Sergey";
        Terminal.WriteLine(greeting);
        ShowMainMenu();
    }

    private void ShowMainMenu()
    {
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
    }

    private void RunMainMenu(string message)
    {
        switch (message)
        {
            case "1":
                level = 1;
                StartGame();
                break;
            case "2":
                level = 2;
                StartGame();
                break;
            case "3":
                level = 3;
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