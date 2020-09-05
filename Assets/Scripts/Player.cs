using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Level_Manager))]
public class Player : MonoBehaviour
{
    #region Task_Achieved
    //TODO: now need to work on the Single_jump and Double_jump then Spawn point of the game
    //Day 1: 1)Implemented prototype of the game with UI_Functionality
    //       2)Implemented GameOver and Winning Conditions of the Game
    //       3)Implemented Random Generated Levels for the game (this will be Turned to HandCrafted Levels)
    //Bugs: Floating Ball bug 
    //Jump_point is Used for Clamped Points in the game, Reset_point is used for origin position of player , Start_position is used for Spawn_point of the Player
    //use Saparate Jump_value for double_jump
    //Current Jump 1)Tap_Hold--> double jump
    //             2)Tap -> Single jump
    // single jump more accurate --> bugfixed
    //tap delay for single jump in the game bug-->bugfixed
    //jump down lag in part of the circle

    //long jump down faster-->fixed
    //Size and Speed of the ball-->fixed
    //long jump tap-->fixed
    //controls bugs-->fixed
    //increase short jump by 20%
    //decrease long jump height
    //onMouseDownBug

    #endregion
    [SerializeField] Transform Jump_point, Reset_point, Start_position;
    public float Speed_Control, Rotate_Count;
    [SerializeField] GameObject Player_jump, Count_Disable;
    [SerializeField]
    [Range(0, 1)] float lerp_value, Display_Count;
    //this is used for Displaying the Score In-game-Text
    [SerializeField] Text Score, Count_Down;
    //this is used for Score System for the game
    public int Score_Test, Count;
    //this bool is used for CoundownTime for the game
    public bool Starting_Phase;
    //this is used for Manipulating the Height of the game
    [SerializeField] int select_height;
    //this is used for fixing the Floating Ball Bug in the game and Improvise Jump Mechnics of the game
    [SerializeField] float Jump_Time;
    [SerializeField] int Tap_count;
    //this is used for making double jump system for the game
    [SerializeField] bool Disable_Jump;
    public static Player _Instance;
    [SerializeField] GameObject ray_start_obj;
    [Range(0,30)]
    [SerializeField] float distance;
    [SerializeField] bool isGround_Check;
    public Level_Manager reference_next_level;
    //only for testing
    [SerializeField] Text Jump_count;
    [SerializeField] float reset_Count,Air_Time;
    //
    [SerializeField]
    private bool Acces_inputs;
    //controlling the coliider
    [SerializeField]float jump_time_collider = 0;
    public bool disable_movement_start = false;
    public bool isCompleted_Ride = false;
    [SerializeField]float turning_speed;
    [SerializeField]
    float bring_valuetozero = 0;
    private void Awake()
    {
        if(_Instance == null)
        {
            _Instance = this;
        }else
        {
            DontDestroyOnLoad(this.gameObject);
        }
        if (Reset_point.GetComponent<BoxCollider>().enabled == true)
        {
            Reset_point.GetComponent<BoxCollider>().enabled = false;
        }
    }
    //36.27 speed value
    private void Start()
    {
        Acces_inputs = true;
        jump_time_collider = 0;
        Score_Test = PlayerPrefs.GetInt("Score");
    //this is Private Variable CountDown Timer 
        Count = 3;
    //this is for displaying on Screens Countdown Timer
        Display_Count = 3;
        StartCoroutine(Start_Time());
        Jump_Time = 0;
        Player_jump.transform.position = Start_position.position;
        Reset_point.GetComponent<BoxCollider>().enabled = true;
        reset_Count = 0;
        Air_Time = 0;
        isCompleted_Ride = false;
        turning_speed = 0;
       

    }
    private void Update()
    {
        Debug.Log("checkingout_SL"+reference_next_level.Select_levels);
        if (UI_Manager.UI_Instance.Pcount_UI == 0)
        {
            isCompleted_Ride = true;
        }
        if (lerp_value <= 0.09f || isGround_Check == true )
        {
           Starting_Phase = true;
        }  
        #region unused_code


        //else if (lerp_value < 0.15f)
        //{
        //    Switch_Collider(0);
        //}

        //testing out touch controls for the game
        //        
        //


        //trying out to fix dead tap bug


        //if (!Starting_Phase) // no inputs
        //{
        //        //Starting_Phase = true;



        //}


        //if (!Starting_Phase)
        //{


        //}

 
        //    //dead tap bug
        //    if (lerp_value <= 0.09f || isGround_Check == true)
        //    {
        //        Starting_Phase = true;
        //    }
        //    //



        //}


        //if (Input.GetMouseButtonDown(0))
        //{
        //   // if (!Starting_Phase)
        //    //{
        //        //dead tap bug
        //        if (lerp_value <= 0.09f || isGround_Check == true)
        //        {
        //            Starting_Phase = true;
        //        }
        //        //

        //        if (Reset_point.GetComponent<BoxCollider>().enabled == true && Jump_Time == 0.0f)
        //        {
        //            Starting_Phase = true;
        //            Reset_point.GetComponent<BoxCollider>().enabled = false;
        //            print("isin");
        //        }

        //    //}
        //}

        //if (Input.GetMouseButton(0))
        //{
        //    if (!Starting_Phase)
        //    {
        //        //dead tap bug rare
        //        if (lerp_value <= 0.09f || isGround_Check == true)
        //        {
        //            Starting_Phase = true;
        //        }

        //        if (Reset_point.GetComponent<BoxCollider>().enabled == true && Jump_Time == 0.0f)
        //        {
        //            Starting_Phase = true;
        //            Reset_point.GetComponent<BoxCollider>().enabled = false;
        //            print("isin");
        //        }
        //    }

        //}
        // if (Input.GetMouseButtonUp(0))
        //{


        //    if (!Starting_Phase)
        //    {
        //        if (Reset_point.GetComponent<BoxCollider>().enabled == true && Jump_Time == 0.0f  )
        //        {
        //            Starting_Phase = true;
        //            Reset_point.GetComponent<BoxCollider>().enabled = false;
        //            print("isin");
        //        }
        //        //dead tap bug
        //        if (lerp_value <= 0.09f || isGround_Check == true && Reset_point.GetComponent<BoxCollider>().enabled == true)
        //        {
        //            Starting_Phase = true;
        //        }
        //    }

        //}
        ////
        #endregion
        reset_Count += Time.deltaTime * 0.4f;
        if (reset_Count > 0.15f) // 0.45f default value
        {
            Tap_count = 0;
            reset_Count = 0; 
        }
        Count_Down.text = "" + Mathf.Round(Display_Count); 
        Display_Count -=1 * Time.deltaTime;       
        UI_Manager.UI_Instance.Score = Score_Test;       
        if (Display_Count <= 0)
        {
            Display_Count = 0;
            Count_Disable.SetActive(false);
        }
     //Only for testing the Levels (Updated the Code line)
        if (Input.GetKey(KeyCode.R))
        {            
            GameManger.Instance.Control_Scene(0);
        }
     //this condition checks during start of the game 
        if (disable_movement_start)
        {
            //Vector3 position = new Vector3(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z);
            #region clamping_valuesforRotation 
            turning_speed = Mathf.Round(this.transform.rotation.z);
            if(turning_speed == 0)
            {
                turning_speed = 1;               
                bring_valuetozero += 1 * Time.deltaTime;
                if (bring_valuetozero >= 1.16f && turning_speed == 1)
                {
                    turning_speed = 0;
                    //bring_valuetozero = 0;
                    //Score_Test += 1;
                    //PlayerPrefs.SetInt("Score", Score_Test);
                    print("check");
                }


            }else if (turning_speed != 0)
            {
                bring_valuetozero = 0;   //reset timer for clamping
            }
            #endregion

            Vector3 current_movement = new Vector3(this.transform.rotation.x, this.transform.rotation.y, turning_speed + Speed_Control);
            //this.transform.Rotate(current_movement * Time.deltaTime, 0.2f);
            Rotate_Count = current_movement.z * Time.deltaTime;
            this.transform.Rotate(0, 0, Rotate_Count, Space.World);
        }
        //
     //this condition checks during start of the game 
        if (disable_movement_start)
        {
     //this is used for moving the ball 
        if (turning_speed == 0) // trying to fix passenger bug
            {
                //Score_Test += 1;
                //PlayerPrefs.SetInt("Score", Score_Test);  this has been changed according to design
                if (isCompleted_Ride)
                {
                    GameManger.Instance.Winning_State();

                    if (reference_next_level.Select_levels == 9)
                    {
                        UI_Manager.UI_Instance.Replay_Button.SetActive(true);
                        UI_Manager.UI_Instance.Next_button.SetActive(false);
                    }
                    if (reference_next_level.Select_levels > 9)
                    {
                        reference_next_level.Select_levels = 1;
                        PlayerPrefs.SetInt("savelvl", reference_next_level.Select_levels);
                    }
                    if (reference_next_level.Select_levels == 0 || reference_next_level.Select_levels < 9)
                    {
                        reference_next_level.Select_levels += 1;
                        Camera_zoomout_effect.reference_for_Startzoome.Start_Zoom = true;
                        PlayerPrefs.SetInt("savelvl", reference_next_level.Select_levels);
                    }

                }
                
            }
        }
        #region Jump_Code

     //Player Control this will be changed to OnClick
        if (disable_movement_start)
        {
            if (Starting_Phase)
            {
                Single_jump(select_height);

               if (Input.GetMouseButtonDown(0)) // 1 frame
                    {
                        if (Starting_Phase == true && Disable_Jump == true && isGround_Check == false && Acces_inputs == true && disable_movement_start == true)
                        {
                            Reset_point.GetComponent<BoxCollider>().enabled = false;
                            print("Reset_Collider");
                        }

                        if (isGround_Check)
                        {
                            Disable_Jump = true;
                            if (Disable_Jump)
                            {
                                Tap_count += 1;

                                if (Tap_count > 1)
                                { 
                                    Switch_Collider(1);
                                    Tap_count = 0;
                                }
                                print("Checking for Double_jump" + Tap_count);
                            }
                        }

                        if (Tap_count == 0)
                        {
                            isGround_Check = false;
                        }


                    }
                               
               if (Input.GetMouseButtonUp(0))  // 1 frame
               {

                    if (isGround_Check)
                        //Tap_count = 0;
                        Tap_count += 1;
                    //if (jump_time_collider <= 0.75f)
                    Switch_Collider(0);
                    //trying out to fix dead tap bug                   
                    if (lerp_value <= 0.1f || Reset_point.GetComponent<BoxCollider>().enabled == true)
                    {
                        Reset_point.GetComponent<BoxCollider>().enabled = false;
                    }
                    //
                }
                 
               if (Input.GetMouseButton(0)) // more than 1 frame
                {

                    if (lerp_value == 0)
                    {
                        Switch_Collider(0);
                    }
                    else if (lerp_value > 0.2f && Tap_count > 1)
                    {
                        Disable_Jump = false;
                        Switch_Collider(1);
                    }
               
                    if (Acces_inputs)
                    {
                        #region unused_code
                        //jump_time_collider += Time.deltaTime * 1.45f;
                        //if (jump_time_collider > 0.32f) //0.35f
                        //{
                        //    Starting_Phase = false;
                        //    jump_time_collider = 0;

                        //}
                        #endregion
                        Single_jump(1);
                        if (isGround_Check)
                        {
                             
                            if (Tap_count == 4 || Tap_count > 1)
                            {
                                Speed_Control += 1.9f / 2 ;
                                Disable_Jump = false;     // default this does not exsist
                                Tap_count = 1;
                            }
                            if (Disable_Jump)
                            {
                                select_height = 1;
                                if (Jump_Time >= 0.01)  //0.31f
                                {
                                    select_height = 2;
                                    
                                }

                            }
                            if (!Disable_Jump)
                            {

                                Tap_count = 0;

                            }
                        }
                    }
                }
               else
                {
                    //this solves the dead tap bug
                    if (Starting_Phase == true && Disable_Jump == true && isGround_Check == false && Acces_inputs == true && disable_movement_start == true)
                    {
                        Reset_point.GetComponent<BoxCollider>().enabled = false;
                        print("Reset_Collider");
                    }
                    //
                    if (isGround_Check)
                    {
                        select_height = 2;
                        if (select_height == 2)
                        {
                            Jump_Time = 0;

                        }
                        //this checks when ball is in air
                        if (Tap_count == 0 || Tap_count >0) // default tap_count = 0
                        {
                            Disable_Jump = true;
                        }
                        else if (Tap_count != 0)
                        {
                            //Disable_Jump = false; // default  Disable_Jump  is false
                            isGround_Check = false;
                        }
                    }

                }
            }
           
            Score.text = "" + Score_Test;
            Single_jump(select_height);  // trying to fix the starting bug
            if (lerp_value >= 1)
            {
                lerp_value = 1;
            }
            else if (lerp_value <= 0)
            {
                lerp_value = 0;
            }
            Jump_count.text = "Jump_Count" + " " + Tap_count;
        }
        #endregion

    }
    private void FixedUpdate()
    {
    //this is called in the Update because it deals with unity physics interactions
        Raycast_point_forJumpDetection();
    }
    //this is used for controlling ground collider's, when player jumps in the air
    public void Switch_Collider(int Select)
    {
        switch (Select)
        {
            //this is where player jumps
            case 0:
                Reset_point.GetComponent<BoxCollider>().enabled = false;
                Acces_inputs = true;
                //lerp_value -= 3.8f * Time.deltaTime / 6f;
                //Starting_Phase = false;            
                break;
            //this is to revert back the player
            case 1: //is_falling              
                Reset_point.GetComponent<BoxCollider>().enabled = true;
                Acces_inputs = false;
                Starting_Phase = false;
                Speed_Control += 34.6f/6;              
                break;            

        }
    } 
    //Jump is called only in Case 1:
    void Single_jump(int Select)
    {  
        switch (Select)
        {
            //this is where player jumps
            case 1:
                if (isGround_Check)
                {
                    lerp_value += 10.2f * Time.deltaTime / 4.3f; // jump value 8.2f
                    if (lerp_value > 0.47f)    //dfault 0.51f
                    {
                        lerp_value = 0.47f; // clamp the value                       

                    }
                    if(lerp_value > 0.37f) // 0.47f
                    {
                        Switch_Collider(1);
                    }
                    Player_jump.transform.position = Vector3.Lerp(Reset_point.position, Jump_point.position, lerp_value);
                    Jump_Time += 5.41f * Time.deltaTime/2;
                   
                }
                break;
            //this is to revert back the player
            case 2:
                if (!isGround_Check)
                {
                    Disable_Jump = true;
                    
                }               
                lerp_value -= 4.4f * Time.deltaTime/6f;    //default value 3.1f              
                Player_jump.transform.position = Vector3.Lerp(Reset_point.position, Jump_point.position, lerp_value);
                Speed_Control = 40.27f;
                if (lerp_value == 0 || lerp_value < 0.278f)
                {
                    Acces_inputs = true;
                }              
                break;                       

        }
    }
    //this checks whelther player is hitting the ground, used Laymasks to use in for specific objects 
    private void Raycast_point_forJumpDetection()
    {
       //this is used for double jump bug
       RaycastHit hit;
       if(Physics.Raycast(ray_start_obj.transform.position, transform.TransformDirection(Vector3.down)*distance , out hit,Mathf.Infinity, 1 << 9))
        {   
            print("not on Ground");           
            isGround_Check = false;
            //bugfix
            Air_Time += Time.deltaTime * 0.23f;
            if (isGround_Check == false && Air_Time >= 0.0f && Speed_Control > 40.27f) //gliding time check
            {
                Starting_Phase = true;
                Switch_Collider(0);
                Air_Time = 0;
            }
            else
            {
                Starting_Phase = false;
            }            
            //       
            //trying to fix start time bug

            if (Starting_Phase == false && Disable_Jump == false && isGround_Check == false && Acces_inputs == false && disable_movement_start == true)
            {
                Reset_point.GetComponent<BoxCollider>().enabled = false;
                Switch_Collider(0);
                print("Reset_Collider");
            }
            Debug.DrawRay(ray_start_obj.transform.position, transform.TransformDirection(Vector3.down) * distance, Color.red);
        }
       else if (!Physics.Raycast(ray_start_obj.transform.position, transform.TransformDirection(Vector3.down) * distance*2.5f / 4.0f, out hit, Mathf.Infinity))
        {

            print("Ground_check");
            //Acces_inputs = false;
            isGround_Check = true;
            Switch_Collider(0);
            //if (isGround_Check) { Disable_Jump = true; }
            if (Tap_count == 0)
            {
                Tap_count = 0;
 
            }
            if (lerp_value > 0.2f && Tap_count > 1)
            {
                Switch_Collider(1);
            }
            Debug.DrawRay(ray_start_obj.transform.position, transform.TransformDirection(Vector3.down) * distance, Color.green);

            
        }
              
    }
    //this is called starting of the game which disables the controlles till the game starts
    IEnumerator Start_Time()
    {        
        Camera_zoomout_effect.reference_for_Startzoome.Start_Zoom = true;
        Reset_point.GetComponent<BoxCollider>().enabled = true;
        disable_movement_start = false;
        Starting_Phase = false;
        Acces_inputs = false;
        Disable_Jump = true;
        UI_Manager.UI_Instance.level_panel_off.SetActive(false);
        yield return new WaitForSeconds(Count);
        Switch_Collider(1);
        disable_movement_start = true;
        Starting_Phase = true;
        Acces_inputs = true;

    }

    
}

 
 
