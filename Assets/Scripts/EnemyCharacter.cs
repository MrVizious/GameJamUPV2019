using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    public float health = 1f;
    public string color;

    public void Hurt(string rayColor){
        if(rayColor == color) health -= 0.7f * Time.deltaTime;
        Debug.Log("Life: "+ health);
    }
}
