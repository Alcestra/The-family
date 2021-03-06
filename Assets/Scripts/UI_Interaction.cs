using UnityEngine;

public class UI_Interaction : MonoBehaviour
{
    public GameObject Pub_UI;
    public GameObject Brewery_UI;
    public GameObject Combat_UI;
    public GameObject HQ_UI;
    public GameObject CombatWin_UI;
    public GameObject combatLoss_UI;
    public GameObject Guid;
    public GameObject PauseMenu;

    public bool activeUI = false;
    private Building activeBuilding;

    // Update is called once per frame
    void Update()
    {
        InputCheck();
    }

    public void closeCombatMenu()
    {
        Combat_UI.SetActive(false);
        activeUI = false;
        Time.timeScale = 1f;
    }
    public void closeWinMenu()
    {
        CombatWin_UI.SetActive(false);
        Combat_UI.SetActive(false);
        activeUI =false;
        Time.timeScale = 1f;
    }

    public void CloseLoseMenu()
    {
        combatLoss_UI.SetActive(false);
        Combat_UI.SetActive(false);
        activeUI=false;
        Time.timeScale = 1f;
    }

    public void CloseResume()
    {
        PauseMenu.SetActive(false);
        activeUI = false;
        Time.timeScale=1f;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("eh");
    }

    void InputCheck()
    {        

        if (Input.GetMouseButtonDown(0) && activeUI == false)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.GetComponent<Building>() != null)
                {
                    activeBuilding = hit.transform.GetComponent<Building>();

                    if (hit.transform.GetComponent<Building>().playerOwned)
                    {

                       if (hit.transform.GetComponent<Bar>() != null && hit.transform.GetComponent<Bar>().isActiveAndEnabled)
                       {
                            Time.timeScale = 0f;
                            Pub_UI.SetActive(true);
                            activeUI = true;
                            hit.transform.GetComponent<Bar>().OpenPubUI();
                       }

                        else if (hit.transform.GetComponent<Brewery>() != null && hit.transform.GetComponent<Brewery>().isActiveAndEnabled)
                        {
                            Time.timeScale = 0f;
                            Brewery_UI.SetActive(true);
                            activeUI = true;
                            hit.transform.GetComponent<Brewery>().OpenBreweryUI();
                        }

                       else if (hit.transform.GetComponent<PlayerHQ>() != null && hit.transform.GetComponent<PlayerHQ>().isActiveAndEnabled)
                       {
                            Time.timeScale = 0f;
                            HQ_UI.SetActive(true);
                            activeUI=true;
                            hit.transform.GetComponent<PlayerHQ>().OpenHQUI();
                       }

                       else if(HQ_UI.GetComponent<PlayerHQmenu>() != null && HQ_UI.GetComponent<PlayerHQmenu>().isActiveAndEnabled)
                       {                            
                            Time.timeScale=0f;
                            HQ_UI.SetActive(false);
                            activeUI = true;
                       }

                       else
                       {
                            Time.timeScale = 0f;
                            CombatWin_UI.SetActive(true);
                            activeUI = true;
                       }
                    }

                    else
                    {
                        Time.timeScale = 0f;
                        Combat_UI.SetActive(true);
                        activeUI = true;
                        int enemyCP = hit.transform.GetComponent<Building>().EnemyPower;
                        string enemyRacketName = hit.transform.GetComponent<Building>().EnemyRacketName;
                        Combat_UI.GetComponent<Combat>().GetNPCCombatPower(enemyCP);
                        Combat_UI.GetComponent<Combat>().GetNPCRacketName(enemyRacketName);
                        Combat_UI.GetComponent<Combat>().activeBuilding = activeBuilding;
                    }

                }
            }
        }
         // close menues
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

        if (Input.GetKeyDown(KeyCode.Escape) && HQ_UI.activeInHierarchy == true)
        {
            HQ_UI.SetActive(false);
            activeUI=false;
            Time.timeScale = 1;
        }

        if(Input.GetKeyDown(KeyCode.Escape) && HQ_UI.GetComponent<PlayerHQmenu>().HireMenu.activeInHierarchy == true)
        {
            HQ_UI.GetComponent<PlayerHQmenu>().HireMenu.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Escape) && CombatWin_UI.activeInHierarchy == true)
        {
            CombatWin_UI.SetActive(false);
            activeUI = false;
            Time.timeScale = 1;
        }

        if(Input.GetKeyDown(KeyCode.Escape)&& combatLoss_UI.activeInHierarchy == true)
        {
            combatLoss_UI.SetActive(false);
            activeUI = false;
            Time.timeScale = 1;
        }


        //Guid for the game tab
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Guid.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            Guid.SetActive(false);
        }


        //open pause menu
        if(Input.GetKeyDown(KeyCode.Escape) && activeUI == false)
        {
            Time.timeScale = 0;
            activeUI = true;
            PauseMenu.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && activeUI == true)
        {
            Time.timeScale = 1;
            activeUI=false;
            PauseMenu.SetActive(false);
        }

    }   

}
