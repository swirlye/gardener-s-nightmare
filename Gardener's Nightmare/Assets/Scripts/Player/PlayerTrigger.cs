// Created by Krista Plagemann //
// Checks a trigger enter for a tag or object and fires an event for it. //


using UnityEngine;
using UnityEngine.Events;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private string TagToCheck;
    [SerializeField] private bool CheckOnce = false;
    [SerializeField] private bool CheckForObject = false;
    [SerializeField] private GameObject ObjectToCheck;

    public UnityEvent OnEntered;
    public UnityEvent OnExited;

    private bool TriggeredOnce = false;

    private void OnTriggerEnter(Collider other)
    {
        if (CheckOnce && TriggeredOnce)
            return;
        if (CheckForObject)
        {
            if (other.gameObject == ObjectToCheck)
            {
                OnEntered?.Invoke();
                TriggeredOnce = true;
            }
        }
        else if (other.CompareTag(TagToCheck))
        {
            OnEntered?.Invoke();
            TriggeredOnce = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (CheckForObject)
        {
            if (other.gameObject == ObjectToCheck)
                OnExited?.Invoke();
        }
        else if (other.CompareTag(TagToCheck))
            OnExited?.Invoke();
    }
}
