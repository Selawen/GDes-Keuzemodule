using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour
{
    public int coinCost;
    public int rudeness;
    public int information;

    [SerializeField] GameManager gameManager;

    public void Option()
    {
        EventSystem.current.SetSelectedGameObject(null);
        gameManager.LoseCoins(coinCost, rudeness, information);
    }

    public void Retry()
    {
        this.transform.parent.gameObject.SetActive(false); 
        gameManager.Reset();
        gameManager.dialogueText.gameObject.SetActive(true);
    }
}
