using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{

    private Rigidbody2D player;

    public float maxVelocity = 3;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        addVelocityY(yAxis);
        addVelocityX(xAxis);

        float angle = Mathf.Atan2(player.velocity.y, player.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    private void clampVelocity()
    {
        float x = Mathf.Clamp(player.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(player.velocity.y, -maxVelocity, maxVelocity);

        player.velocity = new Vector2(x, y);
    }

    private void addVelocityY(float multiplier)
    {
        Vector2 force = Vector2.up * multiplier;

        player.AddForce(force);
    }

    private void addVelocityX(float multiplier)
    {
        Vector2 force = Vector2.right * multiplier;

        player.AddForce(force);
    }
}
