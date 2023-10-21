
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int HealthPoints = 3;
    [SerializeField] private GameObject[] _HitOverlayImages;

    public UnityEvent OnHit;
    public UnityEvent OnDeath;

    [SerializeField] private AudioClip[] _ChompersSounds;
    [SerializeField] private AudioClip[] _OrchidSounds;
    [SerializeField] private AudioClip[] _CactusSounds;
    [SerializeField] private AudioClip[] _IvyChompersSounds;

    public void HitOnce(PlantType plantType)
    {
        if (HealthPoints <= 0)
            return;

        switch (plantType)
        {
            case PlantType.Chompers:
                SoundManager.Instance.PlayRandomSounnd(_ChompersSounds);
                break;
                case PlantType.Orchid:
                SoundManager.Instance.PlayRandomSounnd(_OrchidSounds);
                break;
                case PlantType.Cactus:
                SoundManager.Instance.PlayRandomSounnd(_CactusSounds);
                break;
                case PlantType.Ivy:
                SoundManager.Instance.PlayRandomSounnd(_IvyChompersSounds);
                break;
        }

        HealthPoints--;
        _HitOverlayImages[HealthPoints].SetActive(true);
        OnHit.Invoke();
        if (HealthPoints <= 0 )
            OnDeath.Invoke();
    }

    public void HitFromThorn()
    {
        HitOnce(PlantType.Cactus);
    }

}
