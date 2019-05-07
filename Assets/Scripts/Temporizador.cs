using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporizador : MonoBehaviour
{
	private float tiempo = 0;

    void Update()
    {
        tiempo+=Time.deltaTime;
        Debug.Log(tiempo);
		Messenger<float>.Broadcast(GameEvent.TIME,tiempo);
    }
}
