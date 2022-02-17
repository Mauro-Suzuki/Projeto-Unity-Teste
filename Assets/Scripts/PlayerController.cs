using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _velocity;
    private Rigidbody2D rbody;
    private Vector3 orgPos;
    public Death death;
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        orgPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.y);
        death.onDamage.AddListener(resetPosition);
    }//getcomponent was moved from Update to Start
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
    public void resetPosition()
    {
        Debug.Log("reset player");
        transform.position = orgPos;
    }
}