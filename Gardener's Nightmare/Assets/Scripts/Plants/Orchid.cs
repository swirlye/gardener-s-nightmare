
using UnityEngine;

public class Orchid : MonoBehaviour
{
    [SerializeField] private AudioClip _FedSound;


    public void FeedPlant()
    {
        TaskManager.Instance.FinishPlant(PlantType.Orchid);
        if(_FedSound != null) SoundManager.Instance.PlaySound(_FedSound);
    }

}
