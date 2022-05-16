using UnityEngine;

public class Building : MonoBehaviour
{
    public int EnemyPower;
    public string EnemyRacketName;
    public bool playerOwned = false;

    public Material HighLightMat;

  /* private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform == transform)
            {
                //add in mat change for the building 
                GetComponent<MeshRenderer>().material = HighLightMat;
            }
        }
    }
  */
    private void OnMouseEnter()
    {
        GetComponent<MeshRenderer>().material = HighLightMat;
    }
}
