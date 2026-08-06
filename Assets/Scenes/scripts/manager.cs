using UnityEngine;

public class manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Entity player_stats;
    float move_speed;

    Entity player;
    void Start()
    {
        player_stats = gameObject.GetComponent<Entity>();
        move_speed = player_stats.base_speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        WASD();
    }

    void WASD()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontal * move_speed * Time.deltaTime, vertical * move_speed * Time.deltaTime));

        if ((horizontal > 0 || horizontal < 0) && (vertical > 0 || vertical < 0))
        {
            move_speed = player_stats.base_speed * 0.66f;
        }
        else
        {
            move_speed = player_stats.base_speed;
        }
    }
}
