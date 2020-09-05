using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//bugs found 
//1 extra spawning-->fixed
//2 rotation logic rework-->fixed
//new things added in the gamedesign levels are closed, there are enemies to avoid and passengers to collect to, coin for more score
//HandCrafted_levels is called in this script because to get customized value for each set of levels
public class P_manger : MonoBehaviour
{
    [SerializeField] GameObject[] feeding_variable_passenger;
    [SerializeField] 
    private int count_passenger,count_obstrucals;
    [SerializeField] GameObject[] obstucals_vehicals;
    [SerializeField] GameObject[] Slowmoving_vehicals;
    //[SerializeField]HandCrafted_levels instance_handcrafted;
    private void Awake()
    {       
        for (int i = 0; i < feeding_variable_passenger.Length; i++)
        {
            feeding_variable_passenger[i].SetActive(false);            
        }
        for (int i = 0; i < obstucals_vehicals.Length; i++)
        {
            obstucals_vehicals[i].SetActive(false);
        }
        for(int i = 0; i <Slowmoving_vehicals.Length; i++)
        {
            Slowmoving_vehicals[i].SetActive(false);
        }
      
    }
    private void Start()
    {
        count_passenger = Level_Manager.instance_reference.reference_Objects[Level_Manager.instance_reference.Select_levels].Passenger_count;       //Random.Range(1, 4);
                                                                                                                                                    //count_passenger =instance_handcrafted.Passenger_count;
        Random_passengers(count_passenger);
        count_obstrucals = Level_Manager.instance_reference.reference_Objects[Level_Manager.instance_reference.Select_levels].Vechicals_count;      //Random.Range(1,4);                                                                                                                                                    //count_obstrucals = instance_handcrafted.Vechicals_count;
        Random_obstrucals(count_obstrucals);

        
    }

     

    private void Random_passengers(int number_passenger)
    {
        //Random returns 1 value 
        if (number_passenger == 2) 
        {
            feeding_variable_passenger[Random.Range(0, 2)].SetActive(true);
            feeding_variable_passenger[Random.Range(2, 4)].SetActive(true);
            //feeding_variable_passenger[Random.Range(3, feeding_variable_passenger.Length)].SetActive(false);
            UI_Manager.UI_Instance.Pcount_UI = number_passenger;

        } 
        else if (number_passenger == 1)
        {
            feeding_variable_passenger[Random.Range(0, 3)].SetActive(true);
            UI_Manager.UI_Instance.Pcount_UI = number_passenger;
        }
        else if (number_passenger == 3)
        {
            feeding_variable_passenger[Random.Range(0, 2)].SetActive(true);
            feeding_variable_passenger[Random.Range(2, 4)].SetActive(true);
            feeding_variable_passenger[Random.Range(4, 5)].SetActive(true);
            //feeding_variable_passenger[Random.Range(4, feeding_variable_passenger.Length)].SetActive(false);
            UI_Manager.UI_Instance.Pcount_UI = number_passenger;
        }
        else if (number_passenger == 4)
        {
            feeding_variable_passenger[Random.Range(0, 2)].SetActive(true);
            feeding_variable_passenger[Random.Range(2, 4)].SetActive(true);
            feeding_variable_passenger[Random.Range(4, 5)].SetActive(true);
            //feeding_variable_passenger[Random.Range(4, feeding_variable_passenger.Length)].SetActive(false);
            UI_Manager.UI_Instance.Pcount_UI = number_passenger;
        }
        if (number_passenger > 4)
        {
            Debug.LogError("there are no more passenger");
        }
 
    }
 
    private void Random_obstrucals(int number_passenger)
    {
        //Random returns 1 value 
        if (number_passenger == 2)
        {
            obstucals_vehicals[Random.Range(0, obstucals_vehicals.Length)].SetActive(true);
            obstucals_vehicals[Random.Range(1, obstucals_vehicals.Length)].SetActive(true);
            Slowmoving_vehicals[Random.Range(0, Slowmoving_vehicals.Length)].SetActive(true);
            Slowmoving_vehicals[Random.Range(1, Slowmoving_vehicals.Length)].SetActive(true);

        }
        else if (number_passenger == 1)
        {
            obstucals_vehicals[Random.Range(0, obstucals_vehicals.Length)].SetActive(true);
            Slowmoving_vehicals[Random.Range(0, Slowmoving_vehicals.Length)].SetActive(true);

        }
        else if (number_passenger > 3)
        {
            //Debug.LogError("there are no more passenger");
            obstucals_vehicals[Random.Range(0, obstucals_vehicals.Length)].SetActive(true);
            obstucals_vehicals[Random.Range(1, obstucals_vehicals.Length)].SetActive(true);
            obstucals_vehicals[Random.Range(2, obstucals_vehicals.Length)].SetActive(true);
            Slowmoving_vehicals[Random.Range(1, Slowmoving_vehicals.Length)].SetActive(true);
            Slowmoving_vehicals[Random.Range(0, Slowmoving_vehicals.Length)].SetActive(true);
            Slowmoving_vehicals[Random.Range(2, Slowmoving_vehicals.Length)].SetActive(true);

        }
        else if (number_passenger > 4)
        {
            
            Slowmoving_vehicals[Random.Range(1, Slowmoving_vehicals.Length)].SetActive(true);
            Slowmoving_vehicals[Random.Range(0, Slowmoving_vehicals.Length)].SetActive(true);
            Slowmoving_vehicals[Random.Range(2, Slowmoving_vehicals.Length)].SetActive(true);
        }
        if(number_passenger > 5)
        {
            Debug.LogError("there are no more Vechicals");
        }

    }

    

}
