using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_zoomout_effect : MonoBehaviour
{
    //this Script takes Access form Transfroms and Field of View of the Camera Component
    //This is Done Because gives a Level Growing Effect to the Game for the prototype
    //no Gaps in  2 to 3 levels
    //Until going down no inputs to player in any case
    //no Zoom in camera
    [SerializeField] Camera camera_for_Field_ofView;
    [SerializeField] float Zoomout;
    public bool Start_Zoom;
    [SerializeField] Transform get_zvalues;
    [SerializeField] float timer_for_ZoomPhase;
    public static Camera_zoomout_effect reference_for_Startzoome;
    private float Get_All_Zvalues;
    private void Awake()
    {
        if(reference_for_Startzoome == null)
        {
            reference_for_Startzoome = this;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

        
    }
    private void Start()
    {
        Zoomout = 0.6f;
        Get_All_Zvalues = PlayerPrefs.GetFloat("SaveValue");
        camera_for_Field_ofView.fieldOfView = PlayerPrefs.GetFloat("SaveValueFOV");
    }
    private void Update()
    {
        PlayerPrefs.SetFloat("SaveValue", Get_All_Zvalues);
        PlayerPrefs.SetFloat("SaveValueFOV", camera_for_Field_ofView.fieldOfView);
        if (Start_Zoom)
        {
            Get_All_Zvalues = get_zvalues.position.z - Zoomout / 2 * Time.deltaTime;
            this.transform.position = new Vector3(get_zvalues.position.x, get_zvalues.position.y, Get_All_Zvalues);
            camera_for_Field_ofView.fieldOfView -= 4.8f * Zoomout * Time.deltaTime;
           
            if (camera_for_Field_ofView.fieldOfView <= 19.8f)
            {
                camera_for_Field_ofView.fieldOfView = 34.9f;
               
            }

            timer_for_ZoomPhase += 0.1f*Time.deltaTime;
            if(timer_for_ZoomPhase >= 0.25f)
            {
                timer_for_ZoomPhase = 0;
                Start_Zoom = false;
                 
            }

            if(this.transform.position.z < -20.7f)
            {
                this.transform.position = new Vector3(get_zvalues.position.x, get_zvalues.position.y, -17.428f);
            }
        }
    }
}
