using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Hacker : MonoBehaviour
{
    // Game state
    private Level _level;
    private Screen _currentScreen;
    private String _password;

    private const String MenuHint = "You can type \"menu\" at any time.";

    // Game configuration date
    private readonly List<String> _firstLevelPass = new List<string>
        {"dog", "cat", "pet", "pig", "tiger"};

    private readonly List<String> _secondLevelPass = new List<string>
        {"spring", "hibernate", "orm", "garbage", "object"};

    private readonly List<String> _thirdLevelPass = new List<string>
        {"anchor", "cloud", "google", "unity", "vuforia"};

    private const String FirstLevelReward = @"
       (_    ,_,    _) 
       / `'--) (--'` \
      /  _,-'\_/'-,_  \
     /.-'              \
";

    private const String SecondLevelReward = @"
      #                      
      #   ##   #    #   ##   
      #  #  #  #    #  #  #  
      # #    # #    # #    # 
#     # ###### #    # ###### 
#     # #    #  #  #  #    # 
 #####  #    #   ##   #    # 
";

    private const String ThirdLevelReward = @"
   #    ######  
  # #   #     # 
 #   #  #     # 
#     # ######  
####### #   #   
#     # #    #  
#     # #     # 
";

    private const String DefaultReward = @"
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
        Third,
        Secret
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
        _currentScreen = Screen.MainMenu;
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
        else if ("exit".Equals(message) || "close" == message || "quit" == message)
        {
            Terminal.WriteLine("It on the Web close the tab");
            Application.Quit();
        }
        else if (Screen.MainMenu == _currentScreen)
        {
            RunMainMenu(message);
        }
        else if (Screen.WaitingForPassword == _currentScreen)
        {
            CheckPassword(message);
        }
        else if (Screen.Win == _currentScreen)
        {
            ShowMainMenu();
        }
    }

    private void CheckPassword(string message)
    {
        if (_password == message)
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
        _currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    private void ShowLevelReward()
    {
        switch (_level)
        {
            case Level.First:
                ShowLevelReward(FirstLevelReward);
                break;
            case Level.Second:
                ShowLevelReward(SecondLevelReward);
                break;
            case Level.Third:
                ShowLevelReward(ThirdLevelReward);
                break;
            default:
                ShowLevelReward(DefaultReward);
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
        switch (_level)
        {
            case Level.First:
                randIdx = Random.Range(0, _firstLevelPass.Count);
                _password = _firstLevelPass[randIdx];
                break;
            case Level.Second:
                randIdx = Random.Range(0, _secondLevelPass.Count);
                _password = _secondLevelPass[randIdx];
                break;
            case Level.Third:
                randIdx = Random.Range(0, _thirdLevelPass.Count);
                _password = _thirdLevelPass[randIdx];
                break;
            default:
                _password = "random";
                break;
        }
    }

    private void RunMainMenu(string message)
    {
        switch (message)
        {
            case "1":
                _level = Level.First;
                AskForPassword();
                break;
            case "2":
                _level = Level.Second;
                AskForPassword();
                break;
            case "3":
                _level = Level.Third;
                AskForPassword();
                break;
            default:
                Terminal.WriteLine("Hello cheater. You chose secret level " + message);
                _level = Level.Secret;
                AskForPassword();
                break;
        }
    }

    void AskForPassword()
    {
        _currentScreen = Screen.WaitingForPassword;
        Terminal.ClearScreen();
        PreparePasswordForCheck();
        Terminal.WriteLine("Enter your password, hint: " + _password.Anagram());
        Terminal.WriteLine(MenuHint);
    }
}