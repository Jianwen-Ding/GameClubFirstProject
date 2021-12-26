using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blitzer : EnemyBase
{
    public override void enterShoot()
    {
        AngleOfBullets = ShortcutFunctions.addNumToAll(AngleOfBullets, (float)22.5);
        Shoot(gameObject.transform.position, BulletPrefab, ShortcutFunctions.addNumToAll(AngleOfBullets, ShortcutFunctions.AngleBetweenTwoPoints(transform.position.x, transform.position.y, Enemy.transform.position.x, Enemy.transform.position.y)), SpeedsOfBullets);
    }
    [SerializeField]
    float adjustSpeed;
    public override void HandleMovement()
    {
        angle = ShortcutFunctions.AngleBetweenTwoPoints(transform.position.x, transform.position.y, Enemy.transform.position.x, Enemy.transform.position.y);
        baseRigidbody.AddForce(ShortcutFunctions.locationOutOfAngle(adjustSpeed, angle));
    }
}

