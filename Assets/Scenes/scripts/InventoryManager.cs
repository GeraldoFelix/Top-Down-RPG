using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static InventoryManager Instance { get; private set; }

    public GameObject background_inventory;
    public GameObject background_item;
    Entity entity_stats;

    public List<Weapon> inventory_;

    int selection_hotkey = 1;

    public int gold_inv;
    public Text gold_text;

    int active_slot;

    private void Awake()
    {
        if (Instance != null && Instance !=this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        RefreshInventory();
        entity_stats = GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>();
    }

    // Update is called once per frame
    void Update()
    {
        InputKey();
    }

    public void RefreshInventory () 
    {   
        GameObject[] destroy_objects = GameObject.FindGameObjectsWithTag("Slot");

        foreach (GameObject obj in destroy_objects) {
            Destroy(obj);
        }

        int number_hotkey = 1;
        foreach (Weapon w in inventory_) {

            GameObject slot_instance = Instantiate(background_item, background_inventory.transform);

            if (w == null) {
                slot_instance.GetComponent<Image>().enabled = false;
            }
            else {
                slot_instance.GetComponent<Image>().enabled = true;
                slot_instance.GetComponentInChildren<Image>().sprite = w.weapon_icon;
                slot_instance.GetComponentInChildren<Outline>().enabled = false;
                if (selection_hotkey == number_hotkey)
                {
                    slot_instance.GetComponentInChildren<Outline>().enabled = true;
                }
            }
            slot_instance.GetComponentInChildren<Text>().text = number_hotkey.ToString();
            number_hotkey++;
        }
    }

    void Selection(int hotkey_number)
    {
        entity_stats.attack_damage = inventory_[hotkey_number].attack_damage;
        entity_stats.attack_speed = inventory_[hotkey_number].attack_speed;
        entity_stats.attack_range = inventory_[hotkey_number].attack_range;
        entity_stats.attack_life = inventory_[hotkey_number].attack_life;

        selection_hotkey = hotkey_number + 1;
        active_slot = hotkey_number + 1;
        RefreshInventory();
    }

    void InputKey ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Selection(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Selection(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Selection(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Selection(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Selection(4);
        }
    }

    public void GoldAdd (int gold_add)
    {   
        gold_inv += gold_add;
        gold_text.text = gold_inv.ToString();
    }

    public void ActiveSlot()
    {
        if (active_slot != 3)
        {
            inventory_[active_slot] = null;
            Selection(2);
            RefreshInventory();
        }
    }
}
