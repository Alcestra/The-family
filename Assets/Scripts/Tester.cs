using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{

    private GridSystem gridSystem;

    private void Start()
    {
       gridSystem =  new GridSystem(10, 10, 2f);
    }

    private void Update()
    {
        Debug.Log(gridSystem.getGridPosition(MouseWorldPos.GetPosition()));
    }
}
