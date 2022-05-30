using UnityEngine;
using UnityEngine.UI;

public class PlayerHQmenu : MonoBehaviour
{

    // is effectivly just a display

    
    public PlayerHQ HQ;
    public GameObject HireMenu;

    //names and other over laying info
    #region Names
    [Header("Naming and sizes")]
    public Text HQName;
    public Text HQType;
    #endregion


    //numerical values for cost and upkeep of building
    #region info
    [Header("building expenses and earnings")]
    public Text HQUpkeep;
    public Text HQProduction;
    public Text HQProductionSpeed;
    public Text HQPoliceActivity;

    [Header("Upgrade lvls")]
    public Text HQSecurity;
    public Text HQProdLVL;
    public Text HQProdSpeed;

    [Header("Upgrade Costs")]
    public Text HQSecUpgradeCost;
    public Text HQProdCost;
    public Text HQProdSpeedCost;
    #endregion

    [Header("Buttons")]
    public Button SecUpgradeButton;
    public Button ProductionUpgradeButton;
    public Button ProductionSpeedUpgradeButton;
    public Button HireManPower;

    private void Update()
    {
        HQInfoUpdate();
    }

    public void Open(PlayerHQ currentHQ)
    {
        HQ = currentHQ;
        HQInfoUpdate();
        LVLCHECKSec();
        LVLCheckProduction();
        LVLProductionSpeed();
    }

    public void CloseUI()
    {
        HQ = null;
    }

    #region Buttons for upgrade
    public void ButtonUpgradeSec()
    {
        if (HQ.HQSecurity < 5 && Resources.Instance.SpendCheck(HQ.HQSecUpgradeCost))
        {
            HQ.UpgradeSEC();
            LVLCHECKSec();
        }

    }
 
    public void ButtonUpgradeProd()
    {
        if (HQ.HQprodLVL < 5 && Resources.Instance.SpendCheck(HQ.HQProdUpgradeCost))
        {
            HQ.Upgradeproduction();
            LVLCheckProduction();
        }
    }
    public void ButtonUpgradeprodSpeed()
    {
        if (HQ.HQProdSpeed < 5 && Resources.Instance.SpendCheck(HQ.HQProdSpeedCost))
        {
            HQ.UpgradeProdSpeed();
            LVLProductionSpeed();
        }
    }
    public void HireManPowerButon()
    {
        HireMenu.SetActive(true);      
    }
    #endregion

    #region LVL check
    void LVLCHECKSec()
    {
        if (HQ.HQSecurity < 5 && Resources.Instance.PlayerCash >= HQ.HQSecUpgradeCost)
        {
            SecUpgradeButton.interactable = true;
        }
        else
            SecUpgradeButton.interactable = false;
    }

    
    void LVLCheckProduction()
    {
        if (HQ.HQprodLVL < 5 && Resources.Instance.PlayerCash >= HQ.HQProdUpgradeCost)
        {
            ProductionUpgradeButton.interactable = true;
        }
        else
            ProductionUpgradeButton.interactable = false;
    }
    void LVLProductionSpeed()
    {
        if (HQ.HQProdSpeed < 5 && Resources.Instance.PlayerCash >= HQ.HQProdSpeedCost)
        {
            ProductionSpeedUpgradeButton.interactable = true;
        }
        else
            ProductionSpeedUpgradeButton.interactable = false;
    }
    #endregion

    #region HQInfo
    public void HQInfoUpdate()
    {
        //building size/name and type
        HQName.text = HQ.HQ;
        HQType.text = HQ.HQType;

        //building info regarding upgrades/costs/earnings

        //upgrade lvls
        HQSecurity.text = HQ.HQSecurity.ToString();
        HQProdLVL.text = HQ.HQprodLVL.ToString();
        HQProdSpeed.text = HQ.HQProdSpeed.ToString();

        //upgrade costs
        HQSecUpgradeCost.text = ((int)HQ.HQSecUpgradeCost).ToString() + "$";
        HQProdCost.text = ((int)HQ.HQProdUpgradeCost).ToString() + "$";
        HQProdSpeedCost.text = ((int)HQ.HQProdSpeedCost).ToString() + "$";

        //earnings and costs and police activity
        HQUpkeep.text = HQ.HQUpkeep.ToString() + "$";
        HQProduction.text = HQ.HQProduction.ToString();
        HQProductionSpeed.text = HQ.HQProductionSpeed.ToString();
        HQPoliceActivity.text = HQ.HQPoliceActivity.ToString();

    }
    #endregion
}
