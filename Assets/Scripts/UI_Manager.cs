using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Manager : MonoBehaviour
{
    #region UI_Description
    //TODO: 
    // Timer_Text CountDown Before Start
    // 1) Start_Screen-> 3) Win/Lose Condition
    // if Win -> WinPanel(Winning_Panel, Replay_button , Home_button->Level_Select)
    // if Lose -> LosePanel(High_Score_Panel , Home , Replay_button)

    //TODO: Day 2
    // 1) 10 levels total with 2 Sublevels for Each
    // 2)Level_Select_Screen
    // So Number of Levels Crossed Will be the Score of the play
    // 3)Level Should Increase Its Size something like Growing Effect
    // 4)implementing Double_jump , single jump
    //TODO: Day3
    // 1) Bugfixs and Andriod build
    //TODO: Day4
    // 1) Level Bugs , Small Sound Effects for the game
    // 2)Unity Ads 
    //TODO: Day 5
    //1)jump bug happends rarely
    //2)level progression bug
    //TODO: Day 6
    //1)worked on polishing the jump system for the game
    //2)minor bug fixes
    //3)level designing changes
    //4)fixed jump system bugs in the game
    //TODO: Day 7
    //1)fixing minor bugs
    //TODO: Day 8
    //1)Importing Assets in the game
    //2)UI_Look and Feel,bugfixes
    //3)added replay,home and next button functionality
    //4)rework on Look and feel
    //TODO: Day 9
    //1)Level panel bugfix
    //2)countdown jump bugfix
    //3)passengers after collecting passengers then level complete after reaching the destination point
    //4)coins
    //5)moving obstrucals 
    //TODO: Day 10 
    //1)minor bug fixes
    //
    //TODO: Day 11&12
    //1)Level bugfixes
    //2)passenger bugfixes
    //TODO: Day 16
    //1)UI bugfixes
    //2)implementing Game Assets
    #endregion
    //working on a Prototype Game
    [SerializeField] GameObject High_Score_Animated,High_obj;
    [SerializeField] GameObject Game_Over_Panel, Winning_Panel, Winning_Text, Losing_Text;
    public static UI_Manager UI_Instance;
    public int Score, Add_Score, HighScore;
    [SerializeField] Text Score_Display, HighScore_Display;
    [SerializeField] bool Delete_Save_date;
    public GameObject Replay_Button, Next_button;
    public GameObject level_panel_off; // bug fix
    public int Pcount_UI;
    [SerializeField] Text Display_UI;
    //public GameObject[] sub_levels;
    private void Awake()
    {
        if(UI_Instance == null)
        {
            UI_Instance = this;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

        HighScore = PlayerPrefs.GetInt("HighScore");
        Play_Method(false);
        
    }
    private void Start()
    {  
     //Making Sure All the States are false during start of the game
        GameOver_panel(false);
        Winning_panel(false);
        //Game_Over Condition
        Replay_Button.SetActive(true);
        Next_button.SetActive(false);
    }
    private void Update()
    {
        Display_UI.text = "" + Pcount_UI;
     //This Update is used for Updating Scores for UI Text; 
        Score_Display.text = ""+Score;
        HighScore_Display.text = "" + HighScore;
        Resetting_Saved_data(Delete_Save_date);
    }
    public void GameOver_panel(bool istrue_Check)
    {
        Game_Over_Panel.SetActive(istrue_Check);
        Winning_Text.SetActive(!istrue_Check);
        Losing_Text.SetActive(istrue_Check);
        High_obj.SetActive(istrue_Check);
     //disableing the controls  
     //Pausing the Game
        if (istrue_Check == true)
        {
            Time.timeScale = 0;
            Player._Instance.Starting_Phase = false;
        }
        if(istrue_Check == false)
        {
            Time.timeScale = 1;
        }
    }
    //this method gives Winning Condition to the game
    public void Winning_panel(bool istrue)
    {
        Winning_Panel.SetActive(istrue);
        Next_button.SetActive(istrue);
        Replay_Button.SetActive(!istrue);
        Winning_Text.SetActive(istrue);
        Losing_Text.SetActive(!istrue);
        High_obj.SetActive(!istrue);
        
        if (istrue== true)
        {
            Time.timeScale = 0;
            Player._Instance.Starting_Phase = false;
            Player._Instance.disable_movement_start = false;
        }
        if (istrue == false)
        {
            Time.timeScale = 1;
        }

    }
    //this method is called at the start of the game scene
    public void Play_Method(bool _isplaying)
    {
        if (_isplaying)
        {
            Time.timeScale = 1;
            Player._Instance.gameObject.SetActive(true);
            
        }
        else if (!_isplaying)
        {
            Time.timeScale = 0;
            Player._Instance.gameObject.SetActive(false);
        }
    }
    //this method displays the highscore
    public void Hight_Score_TextDisplay()
    {       
        StartCoroutine(Waitforthe_AnimationToComplete());
        if(Score > HighScore)
        {
           HighScore = Score;
           PlayerPrefs.SetInt("HighScore", HighScore);
             
        }
    }
    #region unused_method
    // This is Used for Displaying the High_Score When Reached Then Goes Away
    private IEnumerator Waitforthe_AnimationToComplete()
    {
        High_Score_Animated.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        High_Score_Animated.SetActive(false);
    }
    #endregion
    // this is used for Resetting the Saved Data
    private void Resetting_Saved_data(bool delete_Save_date)
    {
        if (delete_Save_date)
        {
            PlayerPrefs.DeleteAll();
             
        }
    }
}
