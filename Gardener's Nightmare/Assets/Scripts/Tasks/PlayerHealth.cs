
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int HealthPoints = 3;
    [SerializeField] private GameObject[] _HitOverlayImages;

    public UnityEvent OnHit;
    public UnityEvent OnDeath;

    public void HitOnce()
    {
        if (HealthPoints <= 0)
            return;

        HealthPoints--;
        _HitOverlayImages[HealthPoints].SetActive(true);
        OnHit.Invoke();
        if (HealthPoints <= 0 )
            OnDeath.Invoke();
    }

}
