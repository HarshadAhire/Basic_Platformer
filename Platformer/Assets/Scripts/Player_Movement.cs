using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D player;
    [SerializeField] private float speed, thrust = 100f;
    public float Xinput;
    public bool facing_right = true;
    public bool is_Grounded = true;




    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Xinput = Input.GetAxis("Horizontal");
            player.linearVelocity = new Vector2(Xinput * speed * Time.deltaTime, 0);

        if (Xinput > 0 && !facing_right )
        {
            flip();
        }
        else if (Xinput < 0 && facing_right) {
        
            flip();

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }

    }

    public void flip()
    {
        facing_right = !facing_right;
        transform.Rotate(0, 180, 0);
    }
    public void jump()
    {
        if (is_Grounded)
        {
            player.AddForce(Vector2.up* thrust, ForceMode2D.Impulse);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            is_Grounded=true;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        is_Grounded = false;
    }
}
