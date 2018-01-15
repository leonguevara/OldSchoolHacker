using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
    //  Variables and constants that will help us play our game.
    //  menuHint will tell the user that they can type menu whenever they want
    //  to return to the main menu.
    const string menuHint = "You can type menu at any time.";

    //  These arrays hold the passwords to be used in our game
    string[] level1Passwords = { "tomato", "towel", "cheese", "shirt", "milk", "shampoo" };
    string[] level2Passwords = { "tuition", "assignment", "schedule", "professor", "essay" };
    string[] level3Passwords = { "espionage", "dossier", "international", "terrorism" };

    //  Game state variables
    int level;                                      //  Will hold the level number we are cracking
    enum GameState { MainMenu, Password, Win };     //  Possible screen states
    GameState currentScreen = GameState.MainMenu;   //  Will hold the current screen state
    string password;                                //  Will wold the password to be cracked;

	//  Use this for initialization
    //  We call the ShowMainMenu() method to initialize the game
	void Start () {
        ShowMainMenu(); //  We show the main menu to the user
	}
	
	//  Update is called once per frame
    //  This method can safely be removed from our code, because we are not using it at all.
    //  All the changes to the game state are controlled by the OnUserInput(input) listener.
	void Update () {
		
	}

    //  This method will show the user the game's main menu
    void ShowMainMenu()
    {
        //  We clear the screen
        Terminal.ClearScreen();

        //  We show the menu
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the local supermarket");
        Terminal.WriteLine("Press 2 for the university");
        Terminal.WriteLine("Press 3 for the NSA");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection:");

        //  We set our current screen state as the main menu
        currentScreen = GameState.MainMenu;
    }

    //  The OnUserInput method is special.  It is called everytime the user
    //  hits enter on their keyboard.  This method will let us evaluate the
    //  input data and act accordingly.
    void OnUserInput(string input)
    {
        //  If user inputs the "menu" keyword, then we call the
        //  ShowMainMenu() method once more
        if (input == "menu")
        {
            ShowMainMenu();
        }
        //  However, if the user types quit, close, exit, then we try to close
        //  our game.  If the game is played on a Web browser, then we ask the
        //  user to close the browser's tab
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("Please, close the browser's tab");
            Application.Quit();
        }
        //  If the user inputs anything that is not menu, quit, close or exit,
        //  then we are going to handle that input depending on the game state.
        //  If the game state is still MainMenu, then we call the RunMainMenu()
        //  method.
        else if (currentScreen == GameState.MainMenu)
        {
            RunMainMenu(input);
        }
        //  But if the current game state is Password, then we call the
        //  CheckPassword() method.
        else if (currentScreen == GameState.Password)
        {
            CheckPassword(input);
        }
    }

    private void CheckPassword(string input)
    {
        if (input == password)
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
        Terminal.ClearScreen();

        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    private void ShowLevelReward()
    {
        //  Depending on the level, this method shows a different reward.
        //  If by any chance level is not among the valid level numbers, then
        //  we log an error.
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Grab a lime!");
                Terminal.WriteLine(@"
     /
  __|__
 /     \
|       )
 \_____/
                ");
                break;
            case 2:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    _______
   /      //
  /      //
 /______//
(______(/
                ");
                break;
            case 3:
                Terminal.WriteLine("Greetings...");
                Terminal.WriteLine(@"
 _ __   ___  __ _
| '_ \ / __|/ _` |
| | | |\__ \ (_| |
|_| |_||___)\__,_|
                ");
                Terminal.WriteLine("Welcome to the NSA server");
                break;
            default:
                Debug.LogError("Invalid level reached.");
                break;
        }
    }

    void RunMainMenu(string input)
    {
        //  We first check that the input is a valid input
        bool isValidInput = (input == "1") || (input == "2") || (input == "3");

        //  If the user inputs a valid level, we convert that input to an int
        //  value and then we call the AskForPassword() method.
        if (isValidInput)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        //  However, if the user did not enter a valid input, then we validate
        //  for our Easter egg.  If the user enters "007", we greet them as
        //  Mr. Bond (with utmost respect!)
        else if (input == "007")
        {
            Terminal.WriteLine("Please enter a valid level, Mr. Bond");
        }
        //  If not, then we just ask them to enter a valid level.
        else
        {
            Terminal.WriteLine("Enter a valid level");
        }
    }

    private void AskForPassword()
    {
        //  We set our current game state as Password
        currentScreen = GameState.Password;

        //  We clear our terminal screen
        Terminal.ClearScreen();

        //  We call the SetRandomPassword() method
        SetRandomPassword();

        Terminal.WriteLine("Enter your password. Hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    private void SetRandomPassword()
    {
        //  Depending on the selected level, we choose a random password to crack
        switch(level)
        {
            case 1:
                password = level1Passwords[UnityEngine.Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[UnityEngine.Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[UnityEngine.Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level.  How did you manage that?");
                break;
        }
    }
}
