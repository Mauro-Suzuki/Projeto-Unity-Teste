using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _velocity;
    private Rigidbody2D rbody;
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }//comando getcomponent movido do update para o start
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rbody.velocity = Vector2.left * _velocity;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rbody.velocity = Vector2.right * _velocity;
        }
        else
        {
            rbody.velocity = Vector2.zero;
        }
    }
}