using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class player_detection : MonoBehaviour
{

    private Material material_reference;
    [SerializeField] Color color2;
    //this is used for detecting collisions with respective objects in the game scene
    private void OnTriggerStay(Collider other)
    {      
        if(other.gameObject.tag == "obs1" || other.gameObject.tag == "barricate")
        {
            print("Game_Over");
            //UI_Manager.UI_Instance.GameOver_panel(true);
            PlayerPrefs.SetInt("Score", 0);
            GameManger.Instance.Game_Over_State();
            other.gameObject.GetComponent<Renderer>().sharedMaterial.color = color2;
            material_reference = other.gameObject.GetComponent<Renderer>().sharedMaterial;
            material_reference.SetColor("_EmissionColor", color2);
        }
  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obs")
        {
            //UI_Manager.UI_Instance.Pcount_UI -= 1;
            Player._Instance.Score_Test += 1;
            PlayerPrefs.SetInt("Score", Player._Instance.Score_Test);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "passenger")
        {
            UI_Manager.UI_Instance.Pcount_UI -= 1;
            Player._Instance.Score_Test += 5;
            PlayerPrefs.SetInt("Score", Player._Instance.Score_Test);
            other.gameObject.SetActive(false);
        }

    }


}

