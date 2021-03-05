using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Buttons_Negotiate : MonoBehaviour
{
    [SerializeField] GameManager_Negotiate gameManager;
    [SerializeField] GameObject buyPanel;
    [SerializeField] GameObject sellPanel;
    [SerializeField] Slider slider;
    [SerializeField] int price;

    private void Start()
    {
        if (slider != null)
        {
            slider.onValueChanged.AddListener(ChangePrice);
        }
    }

    private bool buy;

    public void Retry()
    {
        this.transform.parent.gameObject.SetActive(false);
        gameManager.Reset();
    }

    public void BuyOrSell()
    {
        buyPanel.SetActive(buy);
        sellPanel.SetActive(!buy);
        this.GetComponentInChildren<TextMeshProUGUI>().text = buy? "sell": "buy";
        buy = !buy;
    }

    public void Buy()
    {
        gameManager.BuyProduct(price);
    }

    public void Sell()
    {

        gameManager.SellProduct(price);
    }

    public void ChangePrice(float newPrice)
    {
        price = (int)newPrice;
    }
}
