using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderReset : MonoBehaviour
{

    public GameObject spaceship;

    // Start is called before the first frame update
    void Start()
    {
        spaceship = GameObject.Find("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        ResetPosition();
    }

    private void ResetPosition()
    {
        spaceship.transform.position = new Vector3(0, 0, 0);
    }
}
