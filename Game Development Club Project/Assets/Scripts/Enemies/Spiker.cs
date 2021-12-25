using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiker : EnemyBase
{
    public override void enterShoot()
    {
        AngleOfBullets = ShortcutFunctions.addNumToAll(AngleOfBullets, (float)22.5);
        Shoot(gameObject.transform.position, BulletPrefab, ShortcutFunctions.addNumToAll(AngleOfBullets, ShortcutFunctions.AngleBetweenTwoPoints(transform.position.x, transform.position.y, Enemy.transform.position.x, Enemy.transform.position.y)), SpeedsOfBullets);

    }
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
