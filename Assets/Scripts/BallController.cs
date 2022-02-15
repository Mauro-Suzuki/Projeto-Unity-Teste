using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float Speed = 1f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //comando removido do update
        //brik.onBreak.AddListener(Goal); exemplo
    }

    public void Kick()
    {
        rb.velocity = Random.insideUnitCircle * Speed;
    }

    public void resetPosition()
    {
        transform.position = Vector3.zero;    //reset the ball position to zero
        rb.velocity = Vector2.zero; //reset the ball velocity to zero
    }

    private void Update()
    {
        rb.velocity = rb.velocity.normalized * Speed;
    }
}