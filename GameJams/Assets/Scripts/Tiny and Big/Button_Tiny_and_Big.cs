using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Tiny_and_Big : MonoBehaviour, IButtons
{
    public GameManager_Tiny_and_Big gameManager;

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
