using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // add eventos

public class BrikController : MonoBehaviour
{
    public UnityEvent onBreak; //add variavel de evento
    private void OnCollisionEnter2D(Collision2D other)
    {
        /*
        var game = GamePlay.Instance;
        game.Score++; */
        //removed the GamePlay.Instance
        onBreak.Invoke(); //Invoke the onBreak event on collision
        Destroy(gameObject);
    }
}