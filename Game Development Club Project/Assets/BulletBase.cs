using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    //Mean to be a root object to be inherited
    private float Angle;
    private float Speed;
    public virtual void StartProjectile(float Angle, float Speed)
    {
        this.Angle = Angle;
        this.Speed = Speed;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
