using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{

    public Building[] buildings;
    public int buildingsAmount;
    public int buildingsOwned = 2;
    public GameObject WonText;

    private void Awake()
    {
       buildings = FindObjectsOfType<Building>();
        buildingsAmount = buildings.Length;
    }

    public void Update()
    {
        if(buildingsOwned == buildingsAmount)
        {
            Time.timeScale = 0f;
            WonText.SetActive(true);
        }
    }

    public void AcquiredBuilding() 
    { 
        buildingsOwned++;
    }
}

