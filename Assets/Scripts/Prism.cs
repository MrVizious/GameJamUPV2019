using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prism : MonoBehaviour
{
    public bool azulStrong, amarilloStrong, rojoStrong;

    private void Start() {
        azulStrong = amarilloStrong = rojoStrong = false;
    }

    public void addColor(string color){
        if(color == "Azul") azulStrong = true;
        else if(color == "Amarillo") amarilloStrong = true;
        else if(color == "Rojo") rojoStrong = true;

        if(azulStrong && amarilloStrong && rojoStrong) GameOver();
    }

    private void GameOver(){
        Debug.Log("You lost!");
    }

}
