using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridDebugObject : MonoBehaviour
{

    [SerializeField] private TextMeshPro TextMeshPro;

    private GridObject GridObject;

   public void setGridObject(GridObject gridObject)
    {
        this.GridObject = gridObject;
    }


    private void Update()
    {
        TextMeshPro.text = GridObject.ToString();
    }

}
