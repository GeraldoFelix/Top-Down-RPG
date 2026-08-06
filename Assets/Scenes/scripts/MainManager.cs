using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Slider hp_bar;

    Entity player_stats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player_stats = GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHP();
    }

    void PlayerHP()
    {
        hp_bar.maxValue = player_stats.max_hp;
        hp_bar.value = player_stats.hp;
    }
}
