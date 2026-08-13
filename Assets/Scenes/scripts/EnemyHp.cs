using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Slider hp_bar;
    Entity stats;

    void Start()
    {
        hp_bar = GetComponentInChildren<Slider>();
        stats = GetComponentInParent<Entity>();
    }

    // Update is called once per frame
    void Update()
    {
        hp_bar.maxValue = stats.max_hp;
        hp_bar.value = stats.hp;
    }
}
