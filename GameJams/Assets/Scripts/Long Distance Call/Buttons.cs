using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public int coinCost;
    public int rudeness;
    public int information;

    [SerializeField] GameManager gameManager;

    public void Option()
    {
        gameManager.LoseCoins(coinCost, rudeness, information);
    }

    public void Retry()
    {
        this.transform.parent.gameObject.SetActive(false); 
        gameManager.Reset();
        gameManager.dialogueText.gameObject.SetActive(true);
    }
}
