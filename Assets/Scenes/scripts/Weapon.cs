using UnityEngine;


[CreateAssetMenu(fileName = "Weapon")]
public class Weapon : ScriptableObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float attack_damage;
    public float attack_speed;
    public float attack_range;
    public Sprite weapon_icon;
    public string weapon_name;
    public int weapon_price;
    public float attack_life;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
