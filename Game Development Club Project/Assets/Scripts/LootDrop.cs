using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    float[] Angles;
    [SerializeField]
    float[] Speeds;
    [SerializeField]
    float CooldDown;
    [SerializeField]
    float AngleDeviation;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerShipShooter>().SwitchUpgrade(bulletPrefab, Angles, Speeds, CooldDown, AngleDeviation);
            Destroy(gameObject);
        }
    }
    
}
