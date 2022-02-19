using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rigidbody2D;
    private Vector3 originalPosition;
    public Death death;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        originalPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.y);
        death.onDamage.AddListener(resetPosition);
    }
    void Update()
    {
        PlayerControls();
    }

    public void PlayerControls()
    {
        rigidbody2D.velocity = Vector2.right * Input.GetAxis("Horizontal") * playerSpeed;
    }
    public void resetPosition()
    {
        transform.position = originalPosition;
    }
}