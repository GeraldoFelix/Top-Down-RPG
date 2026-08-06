using UnityEngine;

public class Entity : MonoBehaviour
{
    public float max_hp;
    public float hp;
    public float base_speed;
    public float attack_damage;
    public float attack_speed;
    public float attack_range;
    public float attack_life;
    public int gold_carry;

    void Start()
    {
        hp = max_hp;
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }

    void Death()
    {
        if (hp <= 0)
        {
            if (this.gameObject.tag != "Player") {
                InventoryManager.Instance.GoldAdd(100);
            }
            Destroy (this.gameObject);
        }
        
    }

    public void LifeUpdate(float hp_to_update)
    {
        hp -= hp_to_update;
        Death();
    }
}
