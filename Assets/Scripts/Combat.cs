using UnityEngine;

public class Combat : MonoBehaviour
{
    public PlayerHQ PlayerHQ;
    public GameObject CombatWinScreen;
    public GameObject CombatLossScreen;

    //display this info 
    public CombatMenu CombatMenu;

    //name of the building thats getting attacked 
    public string RacketName;

    //combat info values 
    public int PlayerCombatPower;
    public int NPCCombatPower;
    public int WinChance;

    //Display for win chance based on high mid and low  
    public string WinningChance;

    public bool PlayerWon;
    public Building activeBuilding;

    public void Update()
    {
        WinChanceCalculation();
        WinChanceDisplay();
        UpdatePlayerCP();
    }

    void UpdatePlayerCP()
    {
        PlayerCombatPower = PlayerHQ.CombatPower;
    }

    //this and the name is edited in the building script for the combat calculation on run time, this is so it propperly displays 
    public void GetNPCCombatPower(int enemyPower)
    {
        NPCCombatPower = enemyPower;
    }

    public void GetNPCRacketName(string racketName)
    {
        RacketName = racketName;
    }

    public void WinChanceCalculation()
    {
        WinChance = PlayerCombatPower - NPCCombatPower;
    }

    public void WinChanceDisplay()
    {
        if (WinChance > 30)
        {
            WinningChance = "certain";
        }
        else if (WinChance > 5)
        {
            WinningChance = "High";
        }
        else if (WinChance <= 5 && WinChance >= -5)
        {
            WinningChance = "Mid";
        }
        else if (WinChance < -5 && WinChance > -15)
        {
            WinningChance = "Low";
        }
        else if(WinChance < -15)
        {
            WinningChance = "None";
        }
    }   

    public void SimulateFight()
    {
        int playerValue = 0;
        //certain
        if(WinChance > 30)
        {
            playerValue = Random.Range(1, 9);
        }
        //high 
        else if (WinChance > 5 && WinChance <=30)
        {
            playerValue = Random.Range(1, 11);
        }
        //mid
        else if (WinChance <= 5 && WinChance >= -5)
        {
            playerValue = Random.Range(8, 11);
        }
        //low
        else if (WinChance < -5 && WinChance >=-15)
        {
            playerValue = Random.Range(9, 11);
        }
        //none
        else if (WinChance < -15)
        {
            playerValue = Random.Range(10, 11);
        }

        if (playerValue != 10)
            PlayerWon = true;
        else
            PlayerWon = false;


        if(PlayerWon == true)
        {
            CombatWinScreen.GetComponent<WinMenu>().activeBuilding = activeBuilding;
            CombatWinScreen.SetActive(true);
            
        }
        else if (PlayerWon == false)
        {
            CombatLossScreen.SetActive(true);
            PlayerHQ.CombatPower -= Random.Range(1, 11);
        }

        Debug.Log(playerValue);
        Debug.Log(PlayerWon);
    }    
    
}
