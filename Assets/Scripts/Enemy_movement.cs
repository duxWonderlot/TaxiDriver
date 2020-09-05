using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_movement : MonoBehaviour
{
    //the following enemies have same speed as the player in the game
    //TODO: 
    //1)Enemy jump implemented--->implemented
    //2)Enemy jump Bugfix-->fixed
    //3)Implement Dash for Parabolic jump for enemy-->fixed
    //4)minor non-player charecter bugs fixed
    public int negate_values;
    public float fraction_value;
    // GameObject Eobject_referenceForRays,Eobject_endpoint;
    [SerializeField] Vector3 customize;
    [SerializeField] GameObject Eobj_jump;
    [SerializeField] Transform jump_start, jump_end;
    private int Edash;
    [Range(0, 3)]
    [SerializeField] float move = 1.2f, jump_timer;
    [SerializeField] bool Use_jump_mode;
    private void Start()
    {
        move = 0.071f;
        Edash = 1;
        Eobj_jump.transform.position = new Vector3(Eobj_jump.transform.position.x, Eobj_jump.transform.position.y, Eobj_jump.transform.position.z);
    }

    private void Update()
    {
        if (Player._Instance.disable_movement_start)
        {           
            Vector3 current_movement = new Vector3(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z + Player._Instance.Speed_Control*Edash);
            Player._Instance.Rotate_Count = current_movement.z * Time.deltaTime/fraction_value;
            this.transform.Rotate(0, 0, Player._Instance.Rotate_Count * negate_values, Space.World);
            if (Use_jump_mode)
            {
                Raycast_point_forJumpingBarricate();
            }
        }
      

    }

    private void Raycast_point_forJumpingBarricate()
    {
 
        RaycastHit hit; 
        if (Physics.Raycast(this.transform.position, transform.TransformDirection(customize) * 1f, out hit, Mathf.Infinity, 1 << 10))
        {
            print("nothing_Ahead");
            Debug.DrawRay(this.transform.position, transform.TransformDirection(customize) * 1f, Color.red);
            Switch_pos_jump(1,true,false);
            Edash = (Edash + 3)/2;
          
        }
        else if (!Physics.Raycast(this.transform.position, transform.TransformDirection(customize) * 1f, out hit, Mathf.Infinity,1 << 10))
        {
            print("obstrucle_Ahead");
            Switch_pos_jump(2,false,true);            
            Debug.DrawRay(this.transform.position, transform.TransformDirection(customize) * 1f, Color.green);
            Edash = 1;


        }

    }

    private void Switch_pos_jump(int i ,bool check,bool check2)
    { 
       switch (i)
        {
            case 1: // jump 
                    //move += 0.14f* Time.deltaTime / 7.5f; 
                if (check)
                {
                    move += 10.2f * Time.deltaTime / 4.3f;
                    if (move >= 0.071f)
                    {
                        //move = 0;
                        move = 0.071f;
                        print("value_goingbackto1");
                    }
                    Eobj_jump.transform.position = Vector3.Lerp(Eobj_jump.transform.position, jump_end.transform.position, move);
                      
                }
                break;
            case 2: // come_back  
                if (check2)
                {
                    move += 10.2f * Time.deltaTime / 4.3f;
                    if (move >= 0.071f)
                    {
                        move = 0.071f;
                        print("value_goingbackto2");
                    }
                    Eobj_jump.transform.position = Vector3.Lerp(Eobj_jump.transform.position, jump_start.transform.position, move);

                }
                break;
        }

    }
}
