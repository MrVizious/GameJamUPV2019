﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public void LoadLevel(){
        SceneManager.LoadScene("Comic", LoadSceneMode.Single);
    }

    public void LoadSecret(){
        SceneManager.LoadScene("CamaraSecreta", LoadSceneMode.Single);
    }

    public void Quit(){
        Application.Quit();
    }
}
