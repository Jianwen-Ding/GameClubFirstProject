using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rammer : EnemyBase
{
    public override void enterShoot()
    {

    }
    [SerializeField]
    float flySpeed;
    public override void HandleMovement()
    {
        angle = ShortcutFunctions.AngleBetweenTwoPoints(transform.position.x, transform.position.y, Enemy.transform.position.x, Enemy.transform.position.y);
        baseRigidbody.AddForce(ShortcutFunctions.locationOutOfAngle(flySpeed, angle));
    }
}