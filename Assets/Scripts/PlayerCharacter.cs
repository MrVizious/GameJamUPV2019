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
        colors = new string[]{"Azul","Amarillo","Rojo"};
        currentColor = colors[0];
        colorIterator = 0;
    }

   	void Hurt(){
   		if(health>0)
   		{
   			if(this.name=="Player1")
   			{
				Messenger<int>.Broadcast(GameEvent.PLAYER_ONE_HURT,health-1);
   			}
   			else if(this.name=="Player2")
   			{
				Messenger<int>.Broadcast(GameEvent.PLAYER_TWO_HURT,health-1);
   			}
   			
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
   		if(this.name=="Player1")
   		{
			Messenger<int>.Broadcast(GameEvent.PLAYER_ONE_COLOR,colorIterator);
   		}
   		else if(this.name=="Player2")
   		{
   			Messenger<int>.Broadcast(GameEvent.PLAYER_TWO_COLOR,colorIterator);
   		}
   	}
   	public string getCurrentColor ()
   	{
   		return currentColor;
   	}
}
