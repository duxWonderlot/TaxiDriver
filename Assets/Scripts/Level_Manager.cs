using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    #region description
    //Made saparate objects because there will be a cause player gets false feedback in the game
    //Speed of the Ball reduce, Reduce the Size of the Object for more movement for player
    //Trying to Solve Open Space Obstrucals
    //    
    //trying to color_code each level for debuging
    //level is never opened everything is closed
    #endregion
    public HandCrafted_levels[] reference_Objects;
    [SerializeField] Transform Spawn_point;
    public int Select_levels;
    private Material mat;
    private Material mat1;
    public static Level_Manager instance_reference;
    //[SerializeField]HandCrafted_levels[] Select_Levels;
    private void Awake()
    {
        //these are called once during the start of the game in order to get new levels of the game
        for (int r = 0; r < reference_Objects[Select_levels].Feeding_Values_Obs.Length; r++)
        {
            Select_levels = PlayerPrefs.GetInt("savelvl");
            Instantiate(reference_Objects[Select_levels].Feeding_Values_Obs[r],Spawn_point);
            reference_Objects[Select_levels].Feeding_Values_Obs[r].GetComponentInChildren<Renderer>().sharedMaterial.color = reference_Objects[Select_levels].value;          
            mat = reference_Objects[Select_levels].Feeding_Values_Obs[r].GetComponentInChildren<Renderer>().sharedMaterial;
            mat.SetColor("_EmissionColor", reference_Objects[Select_levels].value);
             
        }
        for (int r1 = 0; r1 < reference_Objects[Select_levels].Emplty_obs_Spawn.Length; r1++)
        {
            Select_levels = PlayerPrefs.GetInt("savelvl");
            Instantiate(reference_Objects[Select_levels].Emplty_obs_Spawn[r1],Spawn_point);
            mat1 = reference_Objects[Select_levels].Emplty_obs_Spawn[r1].GetComponentInChildren<Renderer>().sharedMaterial;
            mat1 = reference_Objects[Select_levels].Emplty_obs_Spawn[r1].GetComponentInChildren<Renderer>().sharedMaterial;
            mat1.SetColor("_EmissionColor", Color.red);

        }

        if(instance_reference == null)
        {
            instance_reference = this;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
     
    }
    private void Start()
    {
      
        for (int r2 = 0; r2 < reference_Objects[Select_levels].Emplty_obs_Spawn.Length; r2++)
        {
            reference_Objects[Select_levels].Emplty_obs_Spawn[r2].SetActive(false); 
        }
         
        for (int i = 0; i < reference_Objects[Select_levels].Feeding_Values_Obs.Length; i++)
        {
           //not for use for now Random Levels
            Linear_level(Random.Range(0, reference_Objects[Select_levels].Feeding_Values_Obs.Length)); 
        }
        

    }
    #region Selecting_Level_UnusedMedthod
    void Select_level(int i) {

          
    }
    #endregion
    private void Update()
    {

        #region this is used for disabling Platforms
        //7,8,9,10,11      
        #region Unused_Code
        //if (Feeding_Values_Obs[7].activeInHierarchy == true)
        //{
        //    Feeding_Values_Obs[7].SetActive(true);
        //    Feeding_Values_Obs[7].transform.GetChild(1).gameObject.SetActive(false);
        //    Feeding_Values_Obs[7].transform.GetChild(2).gameObject.SetActive(false);
        //    Feeding_Values_Obs[7].transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = false;
        //}
        ////8
        //else if (Feeding_Values_Obs[8].activeInHierarchy == true)
        //{
        //    Feeding_Values_Obs[8].SetActive(true);

        //    Feeding_Values_Obs[8].transform.GetChild(1).gameObject.SetActive(false);
        //    Feeding_Values_Obs[8].transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = false;
        //}
        ////9
        //else if (Feeding_Values_Obs[9].activeInHierarchy == true)
        //{
        //    Feeding_Values_Obs[9].SetActive(true);

        //    Feeding_Values_Obs[9].transform.GetChild(1).gameObject.SetActive(false);
        //    Feeding_Values_Obs[9].transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = false;
        //}
        ////10
        //else if (Feeding_Values_Obs[10].activeInHierarchy == true)
        //{
        //    Feeding_Values_Obs[10].SetActive(true);

        //    Feeding_Values_Obs[10].transform.GetChild(1).gameObject.SetActive(false);
        //    Feeding_Values_Obs[10].transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = false;
        //}
        ////11
        //else if (Feeding_Values_Obs[11].activeInHierarchy == true)
        //{
        //    Feeding_Values_Obs[11].SetActive(true);
        //    Feeding_Values_Obs[11].transform.GetChild(1).gameObject.SetActive(false);
        //    Feeding_Values_Obs[11].transform.GetChild(2).gameObject.SetActive(false);
        //    Feeding_Values_Obs[11].transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = false;
        //}
        #endregion
        
        if (reference_Objects[Select_levels].Feeding_Values_Obs[0].activeSelf == false)
        {

            reference_Objects[Select_levels].Emplty_obs_Spawn[0].SetActive(true);
        }
        else if (reference_Objects[Select_levels].Feeding_Values_Obs[1].activeSelf == false)
        {

            reference_Objects[Select_levels].Emplty_obs_Spawn[1].SetActive(true);
        }
         else if (reference_Objects[Select_levels].Feeding_Values_Obs[2].activeSelf == false)
        {

            reference_Objects[Select_levels].Emplty_obs_Spawn[2].SetActive(true);
        }
        if (reference_Objects[Select_levels].Feeding_Values_Obs[3].activeSelf == false)
        {

            reference_Objects[Select_levels].Emplty_obs_Spawn[3].SetActive(true);
        }
        else if (reference_Objects[Select_levels].Feeding_Values_Obs[4].activeSelf == false)
        {

            reference_Objects[Select_levels].Emplty_obs_Spawn[4].SetActive(true);
        }
        #endregion

    }
    void Linear_level(int i)
    {

        if (i == 1)
        {

            reference_Objects[Select_levels].Feeding_Values_Obs[0].SetActive(false);
            reference_Objects[Select_levels].Feeding_Values_Obs[Random.Range(2, reference_Objects[Select_levels].Feeding_Values_Obs.Length)].SetActive(true);
            //this is for platforms
            // reference_Objects.Feeding_Values_Obs[Random.Range(7, reference_Objects.Feeding_Values_Obs.Length)].SetActive(false);

        }
        else if (i == 2)
        {
            reference_Objects[Select_levels].Feeding_Values_Obs[3].SetActive(false);
            reference_Objects[Select_levels].Feeding_Values_Obs[Random.Range(0, reference_Objects[Select_levels].Feeding_Values_Obs.Length)].SetActive(true);
            //this is for platforms
            //reference_Objects.Feeding_Values_Obs[Random.Range(8, reference_Objects.Feeding_Values_Obs.Length)].SetActive(true);



        }
        else if (i == 3)
        {
            reference_Objects[Select_levels].Feeding_Values_Obs[0].SetActive(false);
            reference_Objects[Select_levels].Feeding_Values_Obs[Random.Range(2, reference_Objects[Select_levels].Feeding_Values_Obs.Length)].SetActive(true);
            //reference_Objects.Feeding_Values_Obs[Random.Range(0, reference_Objects.Feeding_Values_Obs.Length)].SetActive(true);
            //this is for platforms
            //reference_Objects.Feeding_Values_Obs[Random.Range(9, reference_Objects.Feeding_Values_Obs.Length)].SetActive(false);


        }
        else if (i == 4)
        {
            reference_Objects[Select_levels].Feeding_Values_Obs[3].SetActive(false);
            reference_Objects[Select_levels].Feeding_Values_Obs[Random.Range(0, 3)].SetActive(true);
            reference_Objects[Select_levels].Feeding_Values_Obs[Random.Range(2, reference_Objects[Select_levels].Feeding_Values_Obs.Length)].SetActive(true);
            // reference_Objects.Feeding_Values_Obs[Random.Range(0, reference_Objects.Feeding_Values_Obs.Length)].SetActive(true);
            //this is for platforms
            //reference_Objects.Feeding_Values_Obs[Random.Range(10, reference_Objects.Feeding_Values_Obs.Length)].SetActive(true);           

        }
    }
    public void Refresh_new_level(int i)
    {
        Select_levels = i;
        PlayerPrefs.SetInt("savelvl", Select_levels);
        GameManger.Instance.Control_Scene(0);
    }
    #region Arcade_mode

    //this is Arcade_mode
    /*
    void Random_level(int i)
    {
        
        if (i == 1)
        {

            reference_Objects.Feeding_Values_Obs[Random.Range(0, reference_Objects.Feeding_Values_Obs.Length)].SetActive(false);
            reference_Objects.Feeding_Values_Obs[Random.Range(2, reference_Objects.Feeding_Values_Obs.Length)].SetActive(true);
            this is for platforms
            reference_Objects.Feeding_Values_Obs[Random.Range(7, reference_Objects.Feeding_Values_Obs.Length)].SetActive(false);
             


        }
        else if(i == 2)
        {
            reference_Objects.Feeding_Values_Obs[Random.Range(2, reference_Objects.Feeding_Values_Obs.Length)].SetActive(false);
            reference_Objects.Feeding_Values_Obs[Random.Range(0, reference_Objects.Feeding_Values_Obs.Length)].SetActive(true);
            this is for platforms
            reference_Objects.Feeding_Values_Obs[Random.Range(8, reference_Objects.Feeding_Values_Obs.Length)].SetActive(true);

             

        }
        else if (i == 3)
        {
            reference_Objects.Feeding_Values_Obs[Random.Range(1, reference_Objects.Feeding_Values_Obs.Length)].SetActive(false);
            reference_Objects.Feeding_Values_Obs[Random.Range(2, reference_Objects.Feeding_Values_Obs.Length)].SetActive(true);
            reference_Objects.Feeding_Values_Obs[Random.Range(0, reference_Objects.Feeding_Values_Obs.Length)].SetActive(true);
            this is for platforms
            reference_Objects.Feeding_Values_Obs[Random.Range(9, reference_Objects.Feeding_Values_Obs.Length)].SetActive(false);
 

        }
        else if (i == 4)
        {
            reference_Objects.Feeding_Values_Obs[Random.Range(3, reference_Objects.Feeding_Values_Obs.Length)].SetActive(false);

            reference_Objects.Feeding_Values_Obs[Random.Range(0,3)].SetActive(true);
            reference_Objects.Feeding_Values_Obs[Random.Range(2, reference_Objects.Feeding_Values_Obs.Length)].SetActive(true);
            reference_Objects.Feeding_Values_Obs[Random.Range(0, reference_Objects.Feeding_Values_Obs.Length)].SetActive(true);
            this is for platforms
            reference_Objects.Feeding_Values_Obs[Random.Range(10, reference_Objects.Feeding_Values_Obs.Length)].SetActive(true);           

        }
    }
    */
    #endregion
}
