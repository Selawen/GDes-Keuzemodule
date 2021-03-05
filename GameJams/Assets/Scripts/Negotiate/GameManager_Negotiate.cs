using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager_Negotiate : MonoBehaviour
{
    [SerializeField] int money = 10;
    int soldAmount = 0;
    int expiredAmount = 0;

    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI amountText;
    [SerializeField] private TextMeshProUGUI expiredText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject GameOverPanel;

    public List<Product> products;


    // Start is called before the first frame update
    void Start()
    {
        coinText.text = money.ToString();

        products = new List<Product>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int expiredProducts = 0;
        foreach (Product p in products)
        {
            if (p.Expire())
            {
                expiredProducts++;
                amountText.text = products.Count.ToString();
                //Debug.Log("expired" + expiredProducts);
            }
        }
        if (expiredProducts >= 1)
        products.RemoveRange(0, expiredProducts);
        else if(expiredProducts == 1)
            products.RemoveAt(0);

        expiredAmount += expiredProducts;
        expiredText.text = "Expired: " + expiredAmount; 
        amountText.text = products.Count.ToString();

        if (money <= 1 && products.Count == 0)
        {
            scoreText.text = "You managed to sell " + soldAmount + " carrots";
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
        }
    }

    public void Reset()
    {
        money = 10;
        soldAmount = 0;
        expiredAmount = 0;
        coinText.text = money.ToString();
    }

    public void BuyProduct(int price)
    {
        if (money >= price)
        {
            //Debug.Log("bought" + products.Count);
            money -= price;
            AddProduct();
            coinText.text = money.ToString();
            amountText.text = products.Count.ToString();
        }
    }

    public void SellProduct(int price)
    {
        if (products.Count > 0)
        {
            //Debug.Log("sold" + products.Count);
            string coroutineString = "StartSelling(" + price + ")";
            //StartCoroutine(coroutineString);
            money += price;
            soldAmount++;
            products.RemoveAt(0);
            coinText.text = money.ToString();
            amountText.text = products.Count.ToString();
        }
    }

    private void AddProduct()
    {
        Product product = new Product(new Vector3(100, 100, 0));
        products.Add(product);
    }

    public IEnumerator StartSelling(int time)
    {
        yield return new WaitForSeconds((float)time);
        if (products.Count > 0)
        {
            //Debug.Log("sold" + products.Count);

            money += time;
            soldAmount++;
            products.RemoveAt(0);
            coinText.text = money.ToString();
            amountText.text = products.Count.ToString();
        }

    }
}
