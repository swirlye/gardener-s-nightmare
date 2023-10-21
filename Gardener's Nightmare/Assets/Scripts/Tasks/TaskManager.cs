using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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

    [SerializeField] GameObject _ChomperCheckmark;
    [SerializeField] GameObject _OrchidCheckmark;
    [SerializeField] GameObject _CactusCheckmark;
    [SerializeField] GameObject _EliCheckmark;

    public void FinishPlant(PlantType plantType)
    {
        OnPlantFinished.Invoke(plantType);
        switch (plantType)
        {
            case PlantType.Chompers:
                _ChomperCheckmark.SetActive(true);
                break;
            case PlantType.Orchid:
                _OrchidCheckmark.SetActive(true);
                break;
            case PlantType.Cactus:
                _CactusCheckmark.SetActive(true);
                break;
            case PlantType.Ivy:
                _EliCheckmark.SetActive(true);
                break;
        }

        _plantsDone += 1;
        CheckDone();
    }

    public UnityEvent<int> OnSelectNewSong;

    public void SelectSong(int songNumber)
    {
        OnSelectNewSong.Invoke(songNumber);
    }

    private void CheckDone()
    {


        if(_plantsDone == _AmountOfPlantsToFinish)
        {
            OnGameWon.Invoke();
        }
    }
}
