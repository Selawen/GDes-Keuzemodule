using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayer : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;
    public int activePlayer = 1;

    /*
    public bool p1Dead;
    public bool p2Dead;

    private GameObject Hazard;
    private Die deathScript;
    */
    
    // Start is called before the first frame update
    void Start()
    {
        activePlayer = 1;
        /*
        p1Dead = false;
        p2Dead = false;
        p3Dead = false;

        Hazard = GameObject.Find("Spikes");
        deathScript = Hazard.GetComponent<Die>();
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("e"))
        {
            SwitchKitten();
        }
    }

    public void SwitchKitten()
    {
            if (activePlayer == 1)
            {
                p1.GetComponent<Movement>().enabled = false;
                p2.GetComponent<Movement>().enabled = true;
                activePlayer = 2;
            }
            else if (activePlayer == 2)
            {
                p2.GetComponent<Movement>().enabled = false;
                p1.GetComponent<Movement>().enabled = true;
                activePlayer = 1;
            }
    }
}
