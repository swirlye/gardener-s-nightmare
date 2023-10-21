
using System.Collections.Generic;
using UnityEngine;

public class ThornPool : MonoBehaviour
{
    private List<GameObject> _availableThornsPool = new();

    [SerializeField] int _ThornsInPool;
    [SerializeField] GameObject _ThornPrefab;

    private void Start()
    {
        for(int i = 0; i < _ThornsInPool; i++)
        {
            GameObject newThorn = Instantiate(_ThornPrefab,transform.position, Quaternion.identity);
            _availableThornsPool.Add(newThorn);
            newThorn.SetActive(false);
        }
    }

    public GameObject GetThorn()
    {
        foreach(var thorn in _availableThornsPool)
        {
            if (!thorn.gameObject.activeInHierarchy)
            {
                thorn.SetActive(true);
                return thorn;
            }
        }

        GameObject newThorn = Instantiate(_ThornPrefab);
        _availableThornsPool.Add(newThorn);
        return newThorn;
    }
}
