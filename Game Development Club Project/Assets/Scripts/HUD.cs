using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    Text text;

    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        float waveNumber = 1 + GameObject.Find("Main Camera").GetComponent<LevelController>().Level;
        float health = GameObject.Find("Player").GetComponent<ShipBase>().health;
        if(health >= 1)
        {
            text.text =
            "Health: " + health + "\n" +
            "Wave: " + waveNumber;
        }
        else
        {
            text.text = "Game Over" + "\n" +
                waveNumber + " waves survived";
        }
    }
}
