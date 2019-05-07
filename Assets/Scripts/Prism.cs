using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prism : MonoBehaviour
{
    public bool azulStrong, amarilloStrong, rojoStrong;

    private void Start() {
        azulStrong = amarilloStrong = rojoStrong = false;
        Time.timeScale = 1f;
    }

    public void addColor(string color){
        if(color == "Azul"){
            azulStrong = true;
            transform.Find("AltarLightsAzul").gameObject.SetActive(true);
        }
        else if(color == "Amarillo"){
            amarilloStrong = true;
            transform.Find("AltarLightsAmarillo").gameObject.SetActive(true);
        }
        else if(color == "Rojo"){
            rojoStrong = true;
            transform.Find("AltarLightsRojo").gameObject.SetActive(true);
        }

        if(azulStrong && amarilloStrong && rojoStrong) GameOver();
    }

    private void GameOver(){
        Debug.Log("You lost!");
    }

}
