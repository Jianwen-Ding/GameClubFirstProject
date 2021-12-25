using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motherbug : EnemyBase
{
    [SerializeField]
    GameObject[] EnemiesSpawn;
    [SerializeField]
    float TimeUntilChangeDir = 5;
    [SerializeField]
    float TimeUntilChangeDirLeft = 5;
    [SerializeField]
    float flySpeed;
    public override void enterShoot()
    {
        Instantiate(EnemiesSpawn[(int)Random.Range(0, EnemiesSpawn.Length)], gameObject.transform.position, Quaternion.identity.normalized);
    }
    public override void HandleMovement()
    {
        if(TimeUntilChangeDirLeft < 0)
        {
            TimeUntilChangeDirLeft = TimeUntilChangeDir;
            angle = Random.Range(0, 360);
        }
        TimeUntilChangeDirLeft -= Time.deltaTime;
        baseRigidbody.AddForce(ShortcutFunctions.locationOutOfAngle(flySpeed, angle));
    }
}
