using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class LifeEvent : UnityEvent<int>{}
public class Life : MonoBehaviour
{
    public Text LivesLabel;

    public int currentLife;
    public int startingLife;
    public int damageNumber;

    public LifeEvent onDamageTaken;
    public Death damageScript; //reference to create listener from death script
    void Start()
    {
        currentLife = startingLife;
        damageScript.onDamage.AddListener(Damage);
    }
    public void resetLife()
    {
        currentLife = startingLife;
    }
    public void Damage()
    {
        currentLife -= damageNumber; //created a variable instead of hardcoding the damage
        LivesLabel.text = currentLife.ToString();
        onDamageTaken.Invoke(currentLife); //invoking current life so other scripts can subscribe to this variable
    }
}
