using UnityEngine;



public class Combat : MonoBehaviour
{
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


    public void OpenCombatUI()
    {
        CombatMenu.Open(this);
    }

    public void WinChanceCalculation()
    {
        WinChance = PlayerCombatPower - NPCCombatPower;
    }

    public void WinChanceDisplay()
    {
        if (WinChance > 5)
        {
            WinningChance = "High";
        }
        else if (WinChance <= 5 && WinChance >= -5)
        {
            WinningChance = "Mid";
        }
        else if (WinChance < -5)
        {
            WinningChance = "Low";
        }

    }
}
