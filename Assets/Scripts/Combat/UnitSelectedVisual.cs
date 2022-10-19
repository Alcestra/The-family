using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectedVisual : MonoBehaviour
{
    [SerializeField]private Unit unit;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        UnitActionSystem.Instance.onSelectedUnitChanged += UnitActionSystem_OnselectedUnitChange;
        updateVisual();
    }

    private void UnitActionSystem_OnselectedUnitChange(object  sender,EventArgs empty)
    {
        updateVisual();
    }


    private void updateVisual()
    {
        if (UnitActionSystem.Instance.GetSelectedUnit() == unit)
        {
            meshRenderer.enabled = true;
        }
        else
            meshRenderer.enabled = false;
    }

}
