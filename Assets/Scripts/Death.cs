using UnityEngine;
using UnityEngine.Events;

public class Death : MonoBehaviour
{
    public UnityEvent onDamage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        onDamage.Invoke();
    }
}