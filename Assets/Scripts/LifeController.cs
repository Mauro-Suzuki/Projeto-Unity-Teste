using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class LifeEvent : UnityEvent<int>{}
public class LifeController : MonoBehaviour
{
    public Text LivesLabel;

    public int CurrentLife;
    public int startingLife;
    public int damageNumber;

    public LifeEvent onDamageTaken;
    public GameStateController reset;
    public DeathController damageScript; //reference to create listener from death script
    void Start()
    {
        CurrentLife = startingLife;
        damageScript.onDamage.AddListener(Damage);
    }
    public void resetLife()
    {
        CurrentLife = startingLife;
    }
    public void Damage()
    {
        CurrentLife -= damageNumber; //created a variable instead of hardcoding the damage
        LivesLabel.text = CurrentLife.ToString();
        onDamageTaken.Invoke(CurrentLife); //invoking current life so other scripts can subscribe to this variable
    }
}
