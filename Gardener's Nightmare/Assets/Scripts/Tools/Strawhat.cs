using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawhat : MonoBehaviour
{
    [SerializeField] private Collider _DropZone;
    private Rigidbody _Rigidbody;

    private void Start()
    {
        _Rigidbody=GetComponent<Rigidbody>();
    }



    public void CheckDropZone()
    {
        if (_DropZone.bounds.Contains(transform.position))
        {
            transform.SetPositionAndRotation(_DropZone.transform.position, _DropZone.transform.rotation);
            transform.parent = _DropZone.transform;
            _Rigidbody.isKinematic = true;
        }
        else
            _Rigidbody.isKinematic = false;
    }
}
