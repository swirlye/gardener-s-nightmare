

using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class Cactus : MonoBehaviour
{
    [SerializeField] private Animator _Animator;
    [SerializeField] private int _AttackPauseTime;
    [SerializeField] private GameObject _ThornToShoot;
    [SerializeField] private float _ThornSpeed;
    [SerializeField] private Transform _ThornSpawnPosition;

    [SerializeField] private AudioClip _AttackSound;
    [SerializeField] private float _AttackSoundDelay;
    [SerializeField] private AudioClip _FedSound;

    public bool ChomperFed = false;

    private void Start()
    {
        _Animator = GetComponent<Animator>();
        _thornPool = FindObjectOfType<ThornPool>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    #region Attack

    private ThornPool _thornPool;
    private bool _inRange = false;

    private GameObject _player;

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
        _ThornToShoot = _thornPool.GetThorn();
        _ThornToShoot.transform.position = _ThornSpawnPosition.position;

        if(_player == null)
            _player = GameObject.FindGameObjectWithTag("Player");
        _ThornToShoot.transform.LookAt(_player.transform.position);

        Rigidbody physicsThorn = _ThornToShoot.GetComponent<Rigidbody>();
        physicsThorn.velocity = Vector3.zero;
        physicsThorn.isKinematic = false;
        physicsThorn.AddRelativeForce(new Vector3(0, 0, _ThornSpeed), ForceMode.Impulse);

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
