using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void Show(){
        Time.timeScale = 0f;
        transform.Find("Canvas").gameObject.SetActive(true);
    }
}
