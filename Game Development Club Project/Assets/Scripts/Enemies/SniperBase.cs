using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBase : EnemyBase
{
    [SerializeField]
    float rightStepSpeed;
    [SerializeField]
    float tooClose;
    [SerializeField]
    float tooFar;
    [SerializeField]
    float adjustSpeed;
    [SerializeField]
    float distanceBetweenEnemy;
    public override void HandleMovement()
    {
        distanceBetweenEnemy = ShortcutFunctions.DistPoints(transform.position.x, transform.position.y, Enemy.transform.position.x, Enemy.transform.position.y);
        angle = ShortcutFunctions.AngleBetweenTwoPoints(transform.position.x, transform.position.y, Enemy.transform.position.x, Enemy.transform.position.y);
        baseRigidbody.AddForce(ShortcutFunctions.locationOutOfAngle(rightStepSpeed, angle + 90));
        if (distanceBetweenEnemy < tooClose)
        {
            baseRigidbody.AddForce(ShortcutFunctions.locationOutOfAngle(-adjustSpeed, angle));
        }
        else if (distanceBetweenEnemy > tooFar)
        {
            baseRigidbody.AddForce(ShortcutFunctions.locationOutOfAngle(adjustSpeed, angle));
        }
    }
}
