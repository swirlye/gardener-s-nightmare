using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum PlantType { Chompers, Orchid, Cactus, Ivy}

public class TaskManager : MonoBehaviour
{

    #region Singleton

    public static TaskManager Instance { get; private set; }
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    #endregion

    public UnityEvent<PlantType> OnPlantFinished;
    public int _AmountOfPlantsToFinish;
    public UnityEvent OnGameWon;

    private int _plantsDone = 0;

    public void FinishPlant(PlantType plantType)
    {
        OnPlantFinished.Invoke(plantType);
        _plantsDone += 1;
        CheckDone();
    }

    private void CheckDone()
    {
        if(_plantsDone == _AmountOfPlantsToFinish)
        {
            OnGameWon.Invoke();
        }
    }
}
