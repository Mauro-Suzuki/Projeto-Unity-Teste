using UnityEngine;

public class Ball : MonoBehaviour
{
    public float Speed = 1f;

    private Rigidbody2D rigidbody2D;
    public GameStateController resetState;
    public Death playerDeath;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>(); //moved from update
        playerDeath.onDamage.AddListener(resetBallPosition);
        resetState.onStart.AddListener(KickBallToRandomDirection);
    }
    private void Update()
    {
        rigidbody2D.velocity = rigidbody2D.velocity.normalized * Speed;  //Player movement
    }

    public void KickBallToRandomDirection()
    {
        rigidbody2D.velocity = Random.insideUnitCircle * Speed;
    }

    public void resetBallPosition()
    {
        transform.position = Vector3.zero;    //reset the ball position to zero
        rigidbody2D.velocity = Vector2.zero; //reset the ball velocity to zero
    }
}