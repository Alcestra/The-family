using UnityEngine;
using UnityEngine.UI;

public class CombatMenu : MonoBehaviour
{

    //
    public Combat CurrentCombat;

    //info
    public Text RacketName;
    public Text ACP;
    public Text DCP;
    public Text WinChance;

       
   
    void Update()
    {
        CombatInfo();
    }

    public void Open (Combat CurrentFight)
    {
        CurrentCombat = CurrentFight;
    }


    public void CombatInfo()
    {
        RacketName.text = CurrentCombat.RacketName;
        WinChance.text = CurrentCombat.WinningChance.ToString();

        //displaying nr values
        ACP.text = CurrentCombat.PlayerCombatPower.ToString();
        DCP.text = CurrentCombat.NPCCombatPower.ToString();

    }
}
