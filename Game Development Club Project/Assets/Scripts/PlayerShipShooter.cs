using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipShooter : MonoBehaviour
{

    [SerializeField]
    private float AngleDeviation;
    [SerializeField]
    private float[] anglesShoot;
    [SerializeField]
    private float[] speedsShoot;
    [SerializeField]
    private float shootCooldown;
    [SerializeField]
    private float shootCooldownLeft;
    [SerializeField]
    private GameObject BulletPrefab;
    [SerializeField]
    private GameObject ShootEffects;
    //Other
    Vector2 bulletHoleLocation = new Vector2(0,0 );
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Shoot()
    {
        Vector3 mouseGetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float AngleToIt = ShortcutFunctions.AngleBetweenTwoPoints(bulletHoleLocation.x + gameObject.transform.position.x, bulletHoleLocation.y + gameObject.transform.position.y, mouseGetPosition.x, mouseGetPosition.y);
        //Commented to reduce spam of empties
        //Instantiate(ShootEffects, gameObject.transform.position, Quaternion.identity.normalized);
        for (int x = 0; x < anglesShoot.Length; x++)
        {
            GameObject spawnedObject = Instantiate(BulletPrefab, new Vector3(bulletHoleLocation.x + gameObject.transform.position.x, bulletHoleLocation.y + gameObject.transform.position.y ), Quaternion.identity.normalized);
            float AngleFinal = anglesShoot[x] + Random.Range(-AngleDeviation, AngleDeviation) + AngleToIt;
            spawnedObject.GetComponent<BulletBase>().StartProjectile(AngleFinal, speedsShoot[x], false);
        }
    }
    public void SwitchUpgrade(GameObject prefab, float[] angles, float[] speeds, float Cooldown, float AngleDev)
    {
        BulletPrefab = prefab;
        AngleDeviation = AngleDev;
        anglesShoot = angles;
        speedsShoot = speeds;
        shootCooldown = Cooldown;
    }
    // Update is called once per frame
    void Update()
    {
        if(shootCooldownLeft < 0 && Input.GetAxis("Fire1") != 0)
        {
            Shoot();
            shootCooldownLeft = shootCooldown;
        }
        else
        {
            shootCooldownLeft -= Time.deltaTime;
        }
    }
}
