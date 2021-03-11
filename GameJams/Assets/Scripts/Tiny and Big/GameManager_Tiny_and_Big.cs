using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class GameManager_Tiny_and_Big : MonoBehaviour, IGameManager
{
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject pushable;
    private SwitchPlayer switchScript;

    public int finishedBlocks = 0;

    private DateTime startTime;

    // Start is called before the first frame update
    void Start()
    {
        switchScript = gameObject.GetComponent<SwitchPlayer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (finishedBlocks == 2)
        {
            Time.timeScale = 0;
            scoreText.text = "Time: " + (DateTime.Now - startTime).Minutes + ":" + (DateTime.Now - startTime).Seconds + ":" + (DateTime.Now - startTime).Milliseconds;
            GameOverPanel.SetActive(true);
        }
    }

    public void Reset()
    {
        switchScript.activePlayer = 2;
        switchScript.SwitchKitten();
        switchScript.p1.GetComponent<Movement>().enabled = false;
        switchScript.p1.transform.position = new Vector3(0, 0.5f, 0);           
        switchScript.p1.GetComponent<Movement>().enabled = true;

        switchScript.p2.transform.position = new Vector3(8, 2.5f, 0);
        switchScript.p1.transform.position = new Vector3(0, 0.5f, 0);

        pushable.transform.position = new Vector3(14.21f, 3, 9.57f);

        finishedBlocks = 0;

        Time.timeScale = 1;
        startTime = DateTime.Now;
    }

    public void GameOver()
    {

    }
}
