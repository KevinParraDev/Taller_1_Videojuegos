using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 100;
    [SerializeField] private int coins = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Move(float direction)
    {
        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);

        if (direction != 0)
            anim.SetBool("Walking", true);
        else
            anim.SetBool("Walking", false);

        if (direction == -1)
            sprite.flipX = true;
        else if (direction == 1)
            sprite.flipX = false;
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
        anim.SetTrigger("Jump");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            Debug.Log("Encontró una moneda");
            coins++;
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("Llegó a la meta");
        }
    }

    private void Update()
    {
        Move(Input.GetAxisRaw("Horizontal"));

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
}
