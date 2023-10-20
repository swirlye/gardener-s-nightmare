using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAssets : MonoBehaviour
{

    private static SoundAssets _soundAssets;

    public AudioClip Amadeus_Buildup;
    public AudioClip Amadeus_Shot;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            SoundManager.PlaySound();
        }
    }
    public static SoundAssets soundAssets
    {
        get
        {
            if (_soundAssets == null) _soundAssets = Instantiate(Resources.Load<SoundAssets>("SoundAssets"));
            return _soundAssets;
        }
        
    }

    public void playAmadeusSound()
    {

       
    }
}
