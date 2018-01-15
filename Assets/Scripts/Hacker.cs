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
    enum gameState { MainMenu, Password, Win };     //  Possible screen states
    gameState currentScreen = gameState.MainMenu;   //  Will hold the current screen state
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
        currentScreen = gameState.MainMenu;
    }

    //  The OnUserInput method is special.  It is called everytime the user
    //  hits enter on their keyboard.  This method will let us evaluate the
    //  input data and act accordingly.
    void OnUserInput(string input)
    {
        
    }

}
