using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is create
    public GameObject store_object;
    public GameObject store_warning;

    GameObject player_;

    public List<Weapon> weapons_sold;

    public GameObject shop_bg;
    public GameObject item_store;
    void Start()
    {
        RandomItem();
        store_object.SetActive(false);
        player_ = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position , player_.transform.position);

        if (distance < 2)
        {
            store_warning.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                store_object.SetActive(true);
            }
        }
        else {
            store_warning.SetActive(false);
            store_object.SetActive(false) ;
        }
    }

    void RandomItem ()
    {
        for (int i = 0; i < 3; i++)
        {
            int random_number = Random.Range(0, weapons_sold.Count);

            GameObject new_shop_item = Instantiate(item_store, shop_bg.transform);
            new_shop_item.GetComponent<ShopItem>().w_ = weapons_sold[random_number];
            new_shop_item.GetComponent<ShopItem>().Setup(weapons_sold[random_number]);
        }
    }
}
