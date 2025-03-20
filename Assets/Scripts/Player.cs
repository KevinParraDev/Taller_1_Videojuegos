using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float forceJump = 10;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Move(float direction)
    {
        //transform.Translate(Vector2.right * direction * Time.deltaTime * speed);
        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * forceJump);
    }

    private void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        Move(inputX);
    }

}
