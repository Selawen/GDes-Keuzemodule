using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_template : MonoBehaviour, IButtons
{
    public IGameManager gameManager;

    public IGameManager GameManager()
    {
        return gameManager;
    }

    public void Retry()
    {
        this.transform.parent.gameObject.SetActive(false);
        gameManager.Reset();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
