using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    private bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        menu = transform.Find("Canvas").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(paused) UnPause();
            else Pause();
        }
    }

    public void Pause(){
        Time.timeScale = 0f;
        paused = true;
        menu.SetActive(true);
    }
    public void UnPause(){
        Time.timeScale = 1f;
        paused = false;
        menu.SetActive(false);
    }
}
