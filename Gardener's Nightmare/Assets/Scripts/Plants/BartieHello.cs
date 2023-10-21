using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BartieHello : MonoBehaviour
{
    [SerializeField] private AudioClip _HelloBartieSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SoundManager.Instance.PlaySound(_HelloBartieSound);

            Destroy(gameObject);
        }
    }
}
