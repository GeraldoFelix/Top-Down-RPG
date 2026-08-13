using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{

    public static MainManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public Slider hp_bar;
    public Slider exp_bar;

    Entity player_stats;
    public GameObject stats_screen;

    public Text[] stats_value;

    public GameObject damagepopup;
    
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
        //hp 
        hp_bar.maxValue = player_stats.max_hp;
        hp_bar.value = player_stats.hp;

        // exp
        exp_bar.maxValue = player_stats.level * 100;
        exp_bar.value = player_stats.exp;
    }

    public void SelectStat(string stat)
    {
        if (stat == "HP")
        {
            player_stats.hp += 5;
            player_stats.max_hp += 5;
        }

        if (stat == "Atk")
        {
            player_stats.bonus_attack += 4;
        }

        if (stat == "atk_speed")
        {
            player_stats.bonus_attack_speed += 2.5f;
        }

        if (stat == "Speed")
        {
            player_stats.base_speed += 200;
        }

        stats_screen.SetActive(false);
    }

    public void SetupLevelUp()
    {
        stats_screen.SetActive(true);

        stats_value[0].text = player_stats.max_hp.ToString();

        stats_value[1].text = (player_stats.bonus_attack + 5).ToString();

        stats_value[2].text = (player_stats.bonus_attack_speed + 2.5f).ToString();

        stats_value[3].text = (Mathf.CeilToInt(player_stats.base_speed/1000)).ToString();
    }
}
