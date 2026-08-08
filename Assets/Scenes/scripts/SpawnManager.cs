using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject porta_;

    public List<GameObject> spawn_points;

    public List<GameObject> enemies;

    public int enemies_alives = 0;
    bool dungeon_active = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Check_dungeon();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            porta_.SetActive(true);
            spawn_enemies();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            dungeon_active=true;
        }
    }

    void spawn_enemies()
    {
        foreach (GameObject spawn in spawn_points)
        {   
            int enemy_random = Random.Range(0, enemies.Count);
            GameObject new_enemy = Instantiate(enemies[enemy_random], spawn.transform.position, Quaternion.identity);
            new_enemy.GetComponent<Entity>().spawnManager = this;
            enemies_alives++;
        }
    }

    void Check_dungeon()
    {
        if (enemies_alives <= 0)
        {
            dungeon_active = false;
            porta_.SetActive(false);
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
