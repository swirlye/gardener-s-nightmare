
using UnityEngine;

public class RadioSelectSong : MonoBehaviour
{
    [SerializeField] private AudioClip _SongToPlay;
    [SerializeField] private RadioSelectSong[] _OtherButtons;

    private Vector3 _startVector;

    public bool _IsActive = false;

    private void Start()
    {
        _startVector = transform.localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finger"))
        {
            if (_IsActive)
                return;

            //SoundManager.PlayAmbientSong(_SongToPlay); //check if it's already playing in soundmanager
            Select();

            foreach (var button in _OtherButtons)
            {
                if(button._IsActive)
                    button.Deselect();
            }         
            Debug.Log("Collided");
        }
    }

    public void Deselect()
    {
        transform.localPosition = _startVector;
        _IsActive = false;
    }

    private void Select()
    {
        transform.localPosition = new Vector3(_startVector.x, 0.099f, _startVector.z);
        _IsActive = true;
    }
}
