using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject square;

    Entity player_damage;

    float cooldown;
    bool can_attack = true;
    void Start()
    {
        player_damage = gameObject.GetComponent<Entity>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack ()
    {
        if (Input.GetMouseButton(0) && can_attack == true)
        {
            GameObject projectile_instance = Instantiate(square, transform.position, Quaternion.identity);

            projectile_instance.GetComponent<ProjectileDamage>().damage = player_damage.attack_damage * ((player_damage.bonus_attack + 100)/100);
            projectile_instance.GetComponent<ProjectileDamage>().projectile_life = player_damage.attack_life;

            Vector2 projectile_direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            projectile_direction.Normalize();

            projectile_instance.GetComponent<Rigidbody2D>().AddForce(projectile_direction * player_damage.attack_range, ForceMode2D.Impulse);

            can_attack = false;
            cooldown = 0;
        }

        cooldown_();

        if (Input.GetKeyDown(KeyCode.G)) {
            InventoryManager.Instance.ActiveSlot();
        }
    }


    void cooldown_()
    {
        if (cooldown > (player_damage.attack_speed * ((100 - player_damage.bonus_attack_speed)/100)) && can_attack==false)
        {
            can_attack = true;
        }
        else
        {
            cooldown += Time.deltaTime;
        }
    }
}
