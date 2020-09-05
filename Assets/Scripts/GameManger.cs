using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Level_Manager))]
public class GameManger : MonoBehaviour
{
    #region description
    //This is used for Game_Over Logic,UI Manager is 
    //Called in this Script
    //Game_state and UI is controlled from this script
    #endregion
    public static GameManger Instance;
    [SerializeField] Level_Manager instance_for_home_and_replay_buttons;
    [SerializeField]
    private int count_sublevels;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

        //count_sublevels = PlayerPrefs.GetInt("subslevel");
    }
    private void Start()
    {
        
        //UI_Manager.UI_Instance.sub_levels[0].SetActive(false);
        //UI_Manager.UI_Instance.sub_levels[1].SetActive(false);
        
    }
    //this state calls GameOver UI_panels
    public void Game_Over_State()
    {
        UI_Manager.UI_Instance.GameOver_panel(true);
        //UI_Manager.UI_Instance.Winning_panel(false);
        UI_Manager.UI_Instance.Hight_Score_TextDisplay(); 
        
    }
    //this state calls Winning UI_panels
    public void Winning_State()
    {
        UI_Manager.UI_Instance.Winning_panel(true);
        //Completing_Sub_levels(0);
    }
    #region UnUsedMethod
    public void Add_Score(int Score_Amount)
    {
        UI_Manager.UI_Instance.Add_Score = Score_Amount;
        UI_Manager.UI_Instance.Score += UI_Manager.UI_Instance.Add_Score;
    }
    #endregion
    //this will be Called by button in the Canvas of the UI
    public void Control_Scene(int i)
    {
        SceneManager.LoadSceneAsync(i);
    }
    //this is called starting of the game
    public void Start_Game()
    {
        UI_Manager.UI_Instance.Play_Method(true);
    }
    public void Home_button()
    {
        instance_for_home_and_replay_buttons.Refresh_new_level(0);        
    }
    public void Replay_button()
    {
        instance_for_home_and_replay_buttons.Select_levels = PlayerPrefs.GetInt("savelvl");
        instance_for_home_and_replay_buttons.Refresh_new_level(instance_for_home_and_replay_buttons.Select_levels);
    }
     
    //unused for now
    public void Completing_Sub_levels(int i)
    {         
        if (i > 2)
        {
            i = 0;
            //UI_Manager.UI_Instance.sub_levels[0].SetActive(false);
            //UI_Manager.UI_Instance.sub_levels[1].SetActive(false);
            Winning_State(); // this should be called after two sub_levels
        }
        count_sublevels = i;
        PlayerPrefs.SetInt("subslevel", count_sublevels);
        //UI_Manager.UI_Instance.sub_levels[count_sublevels].SetActive(true);
    }
    //
     
}
