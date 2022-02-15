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
    }
    
    public void Kick()
    {
        rb.velocity = Random.insideUnitCircle * Speed;
    }

    private void Update()
    {
        rb.velocity = rb.velocity.normalized * Speed;
    }
}