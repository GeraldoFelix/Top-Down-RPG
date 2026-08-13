using UnityEngine;
using UnityEngine.UI;

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
    public int exp_carry;

    public SpawnManager spawnManager;

    // xp jogador
    public int level = 1;
    public int exp = 0;

    public float bonus_attack = 0;
    public float bonus_attack_speed = 0;

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
            // da ouro
            if (this.gameObject.tag != "Player") {
                InventoryManager.Instance.GoldAdd(gold_carry);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>().AddExp(exp_carry);
            }

            // conta quantas entidades tem no campo apos a morte de um
            if (this.gameObject.tag == "Enemy")
            {
                spawnManager.enemies_alives--;
            }
            Destroy (this.gameObject);
        }
        
    }

    public void LifeUpdate(float hp_to_update)
    {

        GameObject new_bar = Instantiate(MainManager.Instance.damagepopup, this.gameObject.transform.position, Quaternion.identity);
        new_bar.GetComponentInChildren<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1, 1), 5), ForceMode2D.Impulse );

        new_bar.GetComponentInChildren<Text>().text = hp_to_update.ToString();
        Destroy(new_bar, 1);

        hp -= hp_to_update;
        Death();
    }

    void AddExp(int exp_)
    {
        exp += exp_;

        if (exp >= level * 100)
        {
            level++;
            exp = 0;
            MainManager.Instance.SetupLevelUp();
        }
    }


}
