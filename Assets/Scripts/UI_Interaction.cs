using UnityEngine;

public class UI_Interaction : MonoBehaviour
{
    public GameObject Pub_UI;
    public GameObject Brewery_UI;
    public GameObject Combat_UI;


    bool activeUI = false;

    // Update is called once per frame
    void Update()
    {
        InputCheck();
    }

    void InputCheck()
    {

        if (Input.GetMouseButtonDown(0) && activeUI == false)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.rigidbody != null)
                {
                    if (hit.transform.GetComponent<Bar>() != null)
                    {
                        Time.timeScale = 0f;
                        Pub_UI.SetActive(true);
                        activeUI = true;
                        hit.transform.GetComponent<Bar>().OpenPubUI();
                    }
                    else if (hit.transform.GetComponent<Brewery>() != null)
                    {
                        Time.timeScale = 0f;
                        Brewery_UI.SetActive(true);
                        activeUI = true;
                        hit.transform.GetComponent<Brewery>().OpenBreweryUI();

                    }
                    else if(hit.transform.GetComponent<Combat>() != null)
                    {
                        Time.timeScale = 0f;
                        Combat_UI.SetActive(true);
                        activeUI = true;
                        hit.transform.GetComponent<Combat>().OpenCombatUI();
                    }

                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && Pub_UI.activeInHierarchy == true)
        {
            Pub_UI.SetActive(false);
            activeUI = false;
            Time.timeScale = 1;
        }

        if(Input.GetKeyDown(KeyCode.Escape) && Brewery_UI.activeInHierarchy == true)
        {
             Brewery_UI.SetActive(false);
            activeUI = false;
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && Combat_UI.activeInHierarchy == true)
        {
            Combat_UI.SetActive(false);
            activeUI = false;
            Time.timeScale = 1;
        }

    }
}
