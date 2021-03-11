using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private List<GameObject> doors;

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("pressed");
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject door in doors)
            {
                door.SetActive(false);
                door.GetComponentInChildren<TextMeshPro>().text = "Open";

            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject door in doors)
            {
                door.SetActive(true);
                door.GetComponentInChildren<TextMeshPro>().text = "Locked";

            }
        }
    }
}
