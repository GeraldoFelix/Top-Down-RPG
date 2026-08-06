using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float damage;
    public bool is_player;
    public float projectile_life = 1f;
    void Start()
    {
        Destroy(this.gameObject, projectile_life);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Enemy" && is_player == true) || (collision.tag == "Player" && is_player == false))
        {
            collision.gameObject.GetComponent<Entity>().LifeUpdate(damage);
            Destroy(this.gameObject);
        }
        else if ((collision.tag == "Wall")) {
            Destroy(gameObject);
        }
    }
 }
