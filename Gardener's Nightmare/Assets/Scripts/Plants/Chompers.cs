

using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class Chompers : MonoBehaviour
{
    [SerializeField] private Animator _Animator;
    [SerializeField] private int _AttackPauseTime;

    [SerializeField] private AudioClip _AttackSound;
    [SerializeField] private float _AttackSoundDelay;
    [SerializeField] private AudioClip _FedSound;

    public bool ChomperFed = false;

    private void Start()
    {
        _Animator = GetComponent<Animator>();
    }

    #region Attack

    private bool _inRange = false;
    public async void PlayerStartInRange()
    {
        _inRange = true;
        OnAttackStart.Invoke();
        await AttackContinuously();
    }

    public void PlayerStopInRange()
    {
        //_Animator.SetBool("Attack", false);
        OnAttackEnd.Invoke();
        _inRange = false;
    }

    private async Task AttackContinuously()
    {
        _inRange = true;
        while (_inRange)
        {
            AttackOnce();
            await Task.Delay(_AttackPauseTime);
            //yield return new WaitForSeconds(_AttackPauseTime);
            await Task.Yield();
        }
    }

    private void AttackOnce()
    {
        //_Animator.SetBool("Attack", true);
        //SoundManager.PlaySoundDelayed(_AttackSound, _AttackSoundDelay);
    }

    #endregion

    #region Feed

    public void FeedPlant()
    {
        ChomperFed = true;
        OnFed.Invoke();
        TaskManager.Instance.FinishPlant(PlantType.Chompers);
        
    }

    private void FeedRections()
    {
        //SoundManager.PlaySound(_FedSound);
        //_Animator.SetBool("Fed", true);
    }

    #endregion


    private void OnDisable()
    {
        _inRange = false;
    }

    // DEBUG

    public UnityEvent OnAttackStart;
    public UnityEvent OnAttackEnd;
    public UnityEvent OnFed;

}
