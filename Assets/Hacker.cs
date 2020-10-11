using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Hacker : MonoBehaviour
{
    // Game state
    private Level level;
    private Screen currentScreen;
    private String password;

    // Game configuration date
    private readonly List<String> firstLevelPass = new List<string>
        {"dog", "cat", "pet", "pig", "tiger"};

    private readonly List<String> secondLevelPass = new List<string>
        {"spring", "hibernate", "orm", "garbage", "object"};

    private readonly List<String> thirdLevelPass = new List<string>
        {"anchor", "cloud", "google", "unity", "vuforia"};

    private readonly String firstLevelReward = @"
       (_    ,_,    _) 
       / `'--) (--'` \
      /  _,-'\_/'-,_  \
     /.-'              \
";

    private readonly String secondLevelReward = @"
      #                      
      #   ##   #    #   ##   
      #  #  #  #    #  #  #  
      # #    # #    # #    # 
#     # ###### #    # ###### 
#     # #    #  #  #  #    # 
 #####  #    #   ##   #    # 
";

    private readonly String thirdLevelReward = @"
   #    ######  
  # #   #     # 
 #   #  #     # 
#     # ######  
####### #   #   
#     # #    #  
#     # #     # 
";

    private readonly String defaultReward = @"
               :                
               ;                
              :                 
              ;                 
             /                  
           o/                   
         ._/\___,                
             \                  
             /                   
             `     
";

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
        else if (Screen.Win == currentScreen)
        {
            ShowMainMenu();
        }
    }

    private void CheckPassword(string message)
    {
        if (password == message)
        {
            DisplayWinScreen();
        }
        else
        {
           AskForPassword();
        }
    }

    private void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    private void ShowLevelReward()
    {
        switch (level)
        {
            case Level.First:
                ShowLevelReward(firstLevelReward);
                break;
            case Level.Second:
                ShowLevelReward(secondLevelReward);
                break;
            case Level.Third:
                ShowLevelReward(thirdLevelReward);
                break;
            default:
                ShowLevelReward(defaultReward);
                break;
        }

        print("WELL DONE!");
    }

    private void ShowLevelReward(String reward)
    {
        Terminal.WriteLine("Great!");
        Terminal.WriteLine(reward);
    }

    private void PreparePasswordForCheck()
    {
        int randIdx = 0;
        switch (level)
        {
            case Level.First:
                randIdx = Random.Range(0, firstLevelPass.Count);
                password = firstLevelPass[randIdx];
                break;
            case Level.Second:
                randIdx = Random.Range(0, secondLevelPass.Count);
                password = secondLevelPass[randIdx];
                break;
            case Level.Third:
                randIdx = Random.Range(0, thirdLevelPass.Count);
                password = thirdLevelPass[randIdx];
                break;
            default:
                password = "random";
                break;
        }
    }

    private void RunMainMenu(string message)
    {
        switch (message)
        {
            case "1":
                level = Level.First;
                AskForPassword();
                break;
            case "2":
                level = Level.Second;
                AskForPassword();
                break;
            case "3":
                level = Level.Third;
                AskForPassword();
                break;
            default:
                Terminal.WriteLine("Hello cheater. You chose secret level " + message);
                break;
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.WaitingForPassword;
        Terminal.ClearScreen();
        PreparePasswordForCheck();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
    }
}