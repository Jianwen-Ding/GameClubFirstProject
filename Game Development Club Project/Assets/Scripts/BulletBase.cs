using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    //Mean to be a root object to be inherited
    [SerializeField ]
    private int Damage;
    [SerializeField]
    private float Angle;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private bool IsEnemy;
    [SerializeField]
    private float borderXMin;
    [SerializeField]
    private float borderXMax;
    [SerializeField]
    private float borderYMin;
    [SerializeField]
    private float borderYMax;
    [SerializeField]
    private GameObject ExplosionResidue;
    private Rigidbody2D selfRigidBody;
    
    // Start is called before the first frame update
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "OuterBorder")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player" && IsEnemy)
        {
            //Instantiate(ExplosionResidue, gameObject.transform.position, Quaternion.identity.normalized);
            collision.gameObject.GetComponent<ShipBase>().damagePlayer(Damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy" && IsEnemy == false)
        {
            //Instantiate(ExplosionResidue, gameObject.transform.position, Quaternion.identity.normalized);
            collision.gameObject.GetComponent<EnemyBase>().DamageEnemy(Damage);
            Destroy(gameObject);
        }
    }
    public virtual void StartProjectile(float Angle, float Speed, bool IsEnemy)
    {
        this.IsEnemy = IsEnemy;
        this.Angle = Angle;
        this.Speed = Speed;
        selfRigidBody = gameObject.GetComponent<Rigidbody2D>();
        selfRigidBody.velocity = ShortcutFunctions.locationOutOfAngle(Speed, Angle);
    }
    public void Update()
    {
       if(gameObject.transform.position.x < borderXMin || gameObject.transform.position.x > borderXMax || gameObject.transform.position.y < borderYMin || gameObject.transform.position.y > borderYMax)
        {
            Destroy(gameObject);
        }
    }
}