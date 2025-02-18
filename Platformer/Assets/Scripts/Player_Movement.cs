using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D player;
    [SerializeField] private float speed, thrust;
    public float Xinput;
    public bool facing_right = true;
    public bool is_Grounded;
    public Animator anim;
    public LayerMask groundlayer;
    public Transform groundcheck;


    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Xinput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(Xinput) > 0)
        {
            player.linearVelocity = new Vector2(Xinput * speed * Time.deltaTime, 0);
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);

        }

        if (Xinput > 0 && !facing_right )
        {
            flip();
        }
        else if (Xinput < 0 && facing_right) {
        
            flip();

        }

        is_Grounded = Physics2D.OverlapCircle(groundcheck.position, 1f, groundlayer);

        if (Input.GetKeyDown(KeyCode.Space) && is_Grounded)
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
      
           player.linearVelocity = new Vector2(player.linearVelocity.x, thrust);
            anim.SetBool("jumping", true);
        
   
    }


}
