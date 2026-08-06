using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public Weapon w_;
    public Text Item_name_holder;
    public Text Item_price_holder;
    public Image Item_image_holder;
    public Text Item_stats_holder;

    public Button shop_button;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Setup(w_);
    }

    public void Setup(Weapon w)
    {
        Item_name_holder.text = w.weapon_name;
        Item_price_holder.text = w.weapon_price.ToString();
        Item_image_holder.sprite = w.weapon_icon;
        Item_stats_holder.text = "Damage: " + w.attack_damage.ToString() + "\n" + "Speed: " + w.attack_speed.ToString() + "\n" + "Range: " + w.attack_range.ToString();

        if (InventoryManager.Instance.gold_inv < w.weapon_price)
        {
            shop_button.interactable = false;
        }
        else
        {
             shop_button.interactable= true;
        }
    }

    public void BuyWeapon ()
    {
        if (InventoryManager.Instance.inventory_[4] != null)
        {
            
        }
        else
        {
            for (int i = 0; i < 4; i++) {
                if (InventoryManager.Instance.inventory_[i] == null)
                {
                    InventoryManager.Instance.inventory_[i] = w_;
                    InventoryManager.Instance.RefreshInventory();
                    break;
                }
             }
            InventoryManager.Instance.GoldAdd(w_.weapon_price * -1);
            RefreshShop();
            Destroy(this.gameObject);
        }
        }

    void RefreshShop()
    {
        GameObject[] shop_buttons = GameObject.FindGameObjectsWithTag("Itemshop");

        foreach (var item in shop_buttons)
        {
            item.GetComponent<ShopItem>().Setup(item.GetComponent<ShopItem>().w_);
        }
    }
}
