using UnityEngine;
using UnityEngine.UI;

public class CombatMenu : MonoBehaviour
{

    //
    public Combat Combat;

    //info
    public Text RacketName;
    public Text ACP;
    public Text DCP;
    public Text WinChance;

    public UI_Interaction uiInteraction;   
   
    void Update()
    {
        CombatInfo();
    }

    public void CombatInfo()
    {
        RacketName.text = Combat.RacketName;
        WinChance.text = Combat.WinningChance;

        //displaying nr values
        ACP.text = Combat.PlayerCombatPower.ToString();
        DCP.text = Combat.NPCCombatPower.ToString();

    }

    public void AttackRacket()
    {
        Combat.SimulateFight();
    }

    public void ForfitFight()
    {
        uiInteraction.closeCombatMenu();
    }
}
