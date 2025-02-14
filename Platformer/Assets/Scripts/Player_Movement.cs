using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D player;
    [SerializeField] private float speed;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      
            player.linearVelocity = new Vector2(speed * Time.deltaTime, 0);


    }
}
