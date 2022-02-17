using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float Speed = 1f;
    private Rigidbody2D rb;
    public GameStateController reset;
    public Death resetPos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //moved from update
        resetPos.onDamage.AddListener(resetPosition);
        reset.onStart.AddListener(Kick);
    }
    private void Update()
    {
        rb.velocity = rb.velocity.normalized * Speed;
    }

    public void Kick()
    {
        rb.velocity = Random.insideUnitCircle * Speed;
        Debug.Log("kick");
    }

    public void resetPosition()
    {
        transform.position = Vector3.zero;    //reset the ball position to zero
        rb.velocity = Vector2.zero; //reset the ball velocity to zero
        Debug.Log("reset");
    }
}