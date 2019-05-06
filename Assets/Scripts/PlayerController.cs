using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int vidas = 3;

    // Update is called once per frame
    void Update()
    {
        Input.GetAxis("Horizontal");
    }
}
