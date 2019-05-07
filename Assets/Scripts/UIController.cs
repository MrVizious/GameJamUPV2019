using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	[SerializeField] private Sprite[] lifeSprites;
	[SerializeField] private GameObject lifeObjectPlOne;
	[SerializeField] private GameObject lifeObjectPlTwo;

	[SerializeField] private Sprite[] colorSprites;
	[SerializeField] private GameObject colorsObjectOne;
	[SerializeField] private GameObject colorsObjectTwo;

    
    void Start()
    {
     	lifeObjectPlOne.GetComponent<Image>().sprite=lifeSprites[0]; 
     	lifeObjectPlTwo.GetComponent<Image>().sprite=lifeSprites[0];
     	Messenger<int>.AddListener(GameEvent.PLAYER_ONE_HURT, One_Life_Update);
     	Messenger<int>.AddListener(GameEvent.PLAYER_TWO_HURT, Two_Life_Update);

     	colorsObjectOne.GetComponent<Image>().sprite=colorSprites[0];
		colorsObjectTwo.GetComponent<Image>().sprite=colorSprites[0];
		Messenger<int>.AddListener(GameEvent.PLAYER_ONE_COLOR, One_Color_Update);
     	Messenger<int>.AddListener(GameEvent.PLAYER_TWO_COLOR, Two_Color_Update);

    }

    public void One_Life_Update(int health)
    {
		lifeObjectPlOne.GetComponent<Image>().sprite=lifeSprites[3-health]; 
    }
    public void Two_Life_Update(int health)
    {
    	lifeObjectPlTwo.GetComponent<Image>().sprite=lifeSprites[3-health];
    }
    public void One_Color_Update(int color)
    {
     	colorsObjectOne.GetComponent<Image>().sprite=colorSprites[color];
    }
    public void Two_Color_Update(int color)
    {
     	colorsObjectTwo.GetComponent<Image>().sprite=colorSprites[color];
    }

    private void OnDestroy()
    {
        Messenger<int>.RemoveListener(GameEvent.PLAYER_ONE_HURT, One_Life_Update);
        Messenger<int>.RemoveListener(GameEvent.PLAYER_TWO_HURT, Two_Life_Update);
        Messenger<int>.RemoveListener(GameEvent.PLAYER_ONE_COLOR, One_Color_Update);
        Messenger<int>.RemoveListener(GameEvent.PLAYER_TWO_COLOR, Two_Color_Update);
    }
}
