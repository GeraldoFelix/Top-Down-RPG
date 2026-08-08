using UnityEngine;

public class Inimigos : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    GameObject player_position;

    Entity enemy_stats;

    float move_speed;


    void Start()
    {
        enemy_stats = gameObject.GetComponent<Entity>();
        move_speed = enemy_stats.base_speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        FollowPlayer();
    }

    void FollowPlayer ()
    {
        player_position = GameObject.FindWithTag("Player");

        transform.position = Vector3.MoveTowards(transform.position, player_position.transform.position, move_speed *  Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" )
        {
            collision.gameObject.GetComponent<Entity>().LifeUpdate(enemy_stats.attack_damage);
            enemy_stats.hp -= enemy_stats.max_hp + 1;
        }
    }
}
