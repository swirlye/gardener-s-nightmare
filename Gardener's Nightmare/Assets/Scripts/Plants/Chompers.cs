

using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class Chompers : MonoBehaviour
{
    public int LikesThisSongNumber = 0;
    [SerializeField] private Animator _Animator;
    [SerializeField] private int _AttackPauseTime;

    [SerializeField] private AudioClip _AttackSound;
    [SerializeField] private float _AttackSoundDelay;
    [SerializeField] private AudioClip _FedSound;

    public bool ChomperFed = false;
    public bool ChomperAngry = true;

    private void Start()
    {
        _Animator = GetComponent<Animator>();
        TaskManager.Instance.OnSelectNewSong.AddListener(NewSongPlayed);
    }

    private void NewSongPlayed(int songNumber)
    {
        if(songNumber == LikesThisSongNumber)
            ChomperAngry = false;
        else
            ChomperAngry = true;
    }

    #region Attack

    private bool _inRange = false;
    public async void PlayerStartInRange()
    {
        if (!ChomperAngry)
            return;
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
        if (!ChomperAngry)
            return;

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
        if (!ChomperAngry)
            return;

        //_Animator.SetBool("Attack", true);
        SoundManager.Instance.PlaySound(_AttackSound, _AttackSoundDelay);
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
        SoundManager.Instance.PlaySound(_FedSound);
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
