using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Pushable"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"))*3);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Pushable") && other.rigidbody.velocity.magnitude == 0)
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"))*3);
        }
    }
}
