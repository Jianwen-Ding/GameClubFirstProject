using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    //imma be honest i suck at public and private varibles ill work on it more later
    //this class is meant to be inherited
    private int Health;
    private float TimeUntilFire;
    private float TimeUntilFireLeft;
    [SerializeField]
    private GameObject BulletPrefab;
    //Instantiates a single object upon death, that object that can be used to spawn particles or show a single animation
    [SerializeField]
    private GameObject DestroyParticleEffect;
    public virtual void DamageEnemy(int Damage)
    {
        Health -= Damage;
        //Death
        if (Health <= 0)
        {
            Instantiate(DestroyParticleEffect, gameObject.transform.position, Quaternion.identity.normalized);
            Destroy(gameObject);
        }
    }
    
    // Shoots a BulletPrefab at several angles at the parameters of the Angles. Angles and Speeds need to be the same
    public virtual void Shoot(Vector3 ShootPosition ,GameObject BulletPrefab, float[] Angles, float[] Speeds)
    {
        for(int x = 0; x < Angles.Length; x++)
        {
            GameObject spawnedObject = Instantiate(BulletPrefab, ShootPosition, Quaternion.identity.normalized);
            spawnedObject.GetComponent<BulletBase>().StartProjectile(Angles[x], Speeds[x], true);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeUntilFireLeft < 0 )
        {

        }
    }
}
