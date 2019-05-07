using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class supercr : MonoBehaviour
{
    // Start is called before the first frame update

    void Start(){
        Invoke("LoadLevel", 40f);
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
