using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorldPos : MonoBehaviour
{

    private static MouseWorldPos instance;
    [SerializeField] private LayerMask Floor;

    private void Awake()
    {
        instance = this;
    }    

    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.Floor);
        return raycastHit.point;
    }

}
