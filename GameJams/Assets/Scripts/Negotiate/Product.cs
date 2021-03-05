using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class Product
{
    private GameObject thisProduct;
    private TextMeshProUGUI productText;
    public int cost { get; private set; }
    public int maxFreshness { get; private set; }
    public int freshness;

    public Product(Vector3 pos)
    {
        freshness = 200;
        //thisProduct = new GameObject();
        //thisProduct.layer = 5;
        //thisProduct.name = "Product";
        //thisProduct.AddComponent<SpriteRenderer>();
        //thisProduct.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Carrot");
        //thisProduct.transform.position = pos;
        //thisProduct.transform.localScale = new Vector3(20, 20, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public bool Expire()
    {
        freshness--;
        if (freshness <= 0)
        {
            return true;
        }
        return false;
    }
}
