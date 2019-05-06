using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private int health;

    private string[] colors;
    private string currentColor;
    private int colorIterator;

    void Start()
    {
        colors = new string[]{"Azul","Rojo","Amarillo"};
        currentColor = colors[0];
        colorIterator = 0;
    }

   	void Hurt(){
   		if(health>0)
   		{
   			health-=1;
   		}
   	}
   	public void nextColor()
   	{
   		if(colorIterator < 2)
   		{
   			colorIterator++;
   			currentColor = colors[colorIterator];
   		}
   		else
   		{
   			colorIterator=0;
   			currentColor = colors[colorIterator];
   		}
   	}
   	public string getCurrentColor ()
   	{
   		return currentColor;
   	}
}
