using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    private GameObject activatonObj;
    private SwitchPlayer activationScript;

    private int followedPlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Tiny");
        followedPlayer = 1;

        activatonObj = GameObject.Find("GameManager");
        activationScript = activatonObj.GetComponent<SwitchPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        int activePlayer = activationScript.activePlayer;
        if (followedPlayer == activePlayer)
        {
            if (Vector3.Distance(player.transform.position, (transform.position + (offset*followedPlayer))) > 1)
            {
                transform.position += ((player.transform.position - transform.position) + (offset*followedPlayer)) * Time.deltaTime*2;
            }
        }
        else
        {
            if (activePlayer == 1)
            {
                player = GameObject.Find("Tiny");
            } else
            {
                player = GameObject.Find("Big");
            }
            followedPlayer = activePlayer;
        }
    }
}
