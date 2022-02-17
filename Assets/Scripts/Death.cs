using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Death : MonoBehaviour
{
    public UnityEvent onDamage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //GameStateController.Instance.Lives--; moved to lifeController
        //GameStateController.Instance.Reset();
        onDamage.Invoke();
    }

    //adicionar eventos para reduzir vida

}