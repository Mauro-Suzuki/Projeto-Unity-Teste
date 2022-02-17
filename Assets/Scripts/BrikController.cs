using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class BrikController : MonoBehaviour
{
    public UnityEvent onBreak; 
    private void OnCollisionEnter2D(Collision2D other)
    {
        onBreak.Invoke(); //Invoke the onBreak event on collision
        Destroy(gameObject);
    }
}