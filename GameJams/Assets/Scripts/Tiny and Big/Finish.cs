using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameManager_Tiny_and_Big gameManager;
    bool finished = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("not finished");
        if (other.gameObject.CompareTag("Finish") && other.transform.localScale.x >= (transform.localScale.x -1) && !finished)
        {
            Debug.Log("finished");
            gameManager.finishedBlocks++;
            finished = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Finish") && other.transform.localScale.x >= (transform.localScale.x-1) && finished)
        {
            gameManager.finishedBlocks--;
            finished = false;
        }
    }
}
