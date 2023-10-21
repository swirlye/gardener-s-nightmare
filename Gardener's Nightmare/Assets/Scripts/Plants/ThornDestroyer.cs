using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornDestroyer : MonoBehaviour
{
    [SerializeField] private bool _PlayParrySound = false;
    [SerializeField] private AudioClip[] _ParryThornsClips;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Thorn"))
        {
            other.gameObject.SetActive(false);
            if(_PlayParrySound)
                SoundManager.Instance.PlayRandomSounnd(_ParryThornsClips);
        }
    }
}
