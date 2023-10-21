using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornDestroyer : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Thorn"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
