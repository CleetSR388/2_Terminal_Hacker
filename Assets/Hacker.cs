using UnityEngine;

public class Hacker : MonoBehaviour
{

    // Game configuration data
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "burrow" }; // comment
    const string menuHint = "You may type menu at any time.";
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Passwords = { "starmap", "orbit", "universe", "moon", "solar", "nova" };

    // Game State
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Use this for initialization
    void Start()
    {
        print(level1Passwords[0]);
        print(level2Passwords[0]);
        print(level3Passwords[0]);
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for Nasa");
        Terminal.WriteLine("Enter your selection:");
    }



    void OnUserInput(string input)
    {
        if (input == "menu") // we can always go direct to main menu 
        {
            ShowMainMenu();
        }
        else if(input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("If on the web close the tab.");
            Application.Quit();
        }
        
       
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }
    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPasword();
        }
        else if (input == "007") // easter egg
        {
            Terminal.WriteLine("Please select a level Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("Invalid level");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPasword()
    {
        print(level1Passwords.Length);
        print(level2Passwords.Length);
        print(level3Passwords.Length);
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {

            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;

        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPasword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    ,_,
  / |~| \
 /  |=|  \
|   |=|   |
|  //A\\  |
|_//   \\_|
         
");
                break;
            case 2:
                Terminal.WriteLine("Have a badge...");
                Terminal.WriteLine("Play again for a greater challenge.");
                Terminal.WriteLine(@"
   ,   /\   ,
  / '-'  '-' \
  |  POLICE  |
  |  ( 19 )  |
   '--.  .--'
       \/
");
                
                break;
           case 3:
                Terminal.WriteLine(@"
         /\
        |==|
        |  |
       /____\
       |nasa|
      /| |  |\
     /_|_|__|_\
       /_\/_\
");
                Terminal.WriteLine("Wlcome to NASA's internal system");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
                        }
                }
 }