using UnityEngine;

public class RangedBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject projectile_;
    Entity player_damage;
    GameObject player_;

    float cooldown;
    bool can_attack = true;
    void Start()
    {
        player_damage = gameObject.GetComponent<Entity>();
        player_ = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (can_attack == true)
        {
            GameObject projectile_instance = Instantiate(projectile_, transform.position, Quaternion.identity);

            projectile_instance.GetComponent<ProjectileDamage>().damage = player_damage.attack_damage;
            projectile_instance.GetComponent<ProjectileDamage>().projectile_life = player_damage.attack_life;

            Vector2 projectile_direction = player_.transform.position - transform.position;
            projectile_direction.Normalize();

            projectile_instance.GetComponent<Rigidbody2D>().AddForce(projectile_direction * player_damage.attack_range, ForceMode2D.Impulse);

            can_attack = false;
            cooldown = 0;
        }

        cooldown_();
    }


    void cooldown_()
    {
        if (cooldown > player_damage.attack_speed && can_attack == false)
        {
            can_attack = true;
        }
        else
        {
            cooldown += Time.deltaTime;
        }
    }
}
