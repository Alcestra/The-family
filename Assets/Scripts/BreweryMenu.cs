using UnityEngine;
using UnityEngine.UI;

public class BreweryMenu : MonoBehaviour
{
    // is effectivly just a display

    //the pub that has the menu info
    public Brewery CurrentBrewery;

    //names and other over laying info
    #region Names
    [Header("Naming and sizes")]
    public Text BreweryName;
    public Text BrewerySize;
    public Text BreweryType;
    #endregion


    //numerical values for cost and upkeep of building
    #region info
    [Header("building expenses and earnings")]
    public Text BreweryUpkeep;
    public Text BreweryProduction;
    public Text BreweryProductionSpeed;
    public Text BreweryPoliceActivity;

    [Header("Upgrade lvls")]
    public Text BrewerySecurity;
    public Text BreweryDeflect;
    public Text BreweryProdLVL;
    public Text BreweryProdSpeed;

    [Header("Upgrade Costs")]
    public Text BrewerySecUpgradeCost;
    public Text BreweryDefUpgradeCost;
    public Text BreweryProdCost;
    public Text BreweryProdSpeedCost;
    #endregion

    [Header("Buttons")]
    public Button SecUpgradeButton;
    public Button DefUpgradeButton;
    public Button ProductionUpgradeButton;
    public Button ProductionSpeedUpgradeButton;



    private void Update()
    {
        BreweryInfoUpdate();
    }
    void CashCheck()
    {
        if (Resources.Instance.PlayerCash >= CurrentBrewery.BrewerySecUpgradeCost)
        {
            SecUpgradeButton.interactable = true;
        }
        else
            SecUpgradeButton.interactable = false;

        if (Resources.Instance.PlayerCash >= CurrentBrewery.BreweryDefUpgradeCost)
        {
            DefUpgradeButton.interactable = true;
        }
        else
            DefUpgradeButton.interactable = false;

        if (Resources.Instance.PlayerCash >= CurrentBrewery.BreweryProdUpgradeCost)
        {
            ProductionUpgradeButton.interactable = true;
        }
        else
            ProductionUpgradeButton.interactable = false;

        if(Resources.Instance.PlayerCash >= CurrentBrewery.BreweryProdSpeedCost)
        {
            ProductionSpeedUpgradeButton.interactable = true;
        }
        else
            ProductionSpeedUpgradeButton.interactable= false;
    }


    public void Open(Brewery currentBrewery)
    {
        CurrentBrewery = currentBrewery;
        BreweryInfoUpdate();
        LVLCHECKSec();
        LVLCHeckDEF();
        LVLCheckProduction();
        LVLProductionSpeed();
    }

    public void CloseUI()
    {
        CurrentBrewery = null;
    }

    #region Buttons for upgrade
    public void ButtonUpgradeSec()
    {
        if (CurrentBrewery.BrewerySecurity < 5 && Resources.Instance.SpendCheck(CurrentBrewery.BrewerySecUpgradeCost))
        {
            CashCheck();
            CurrentBrewery.UpgradeSEC();
            LVLCHECKSec();
        }

    }
    public void ButtonUpgradeDef()
    {
        if (CurrentBrewery.BreweryDeflect < 5 && Resources.Instance.SpendCheck(CurrentBrewery.BreweryDefUpgradeCost))
        {
            CashCheck();
            CurrentBrewery.UpgradeDef();
            LVLCHeckDEF();
        }
    }

    public void ButtonUpgradeProd()
    {
        if (CurrentBrewery.BreweryprodLVL < 5 && Resources.Instance.SpendCheck(CurrentBrewery.BreweryProdUpgradeCost))
        {
            CashCheck();
            CurrentBrewery.Upgradeproduction();
            LVLCheckProduction();
        }
    }

    public void ButtonUpgradeprodSpeed()
    {
        if (CurrentBrewery.BreweryProdSpeed < 5 && Resources.Instance.SpendCheck(CurrentBrewery.BreweryProdSpeedCost))
        {
            CashCheck();
            CurrentBrewery.UpgradeProdSpeed();
            LVLProductionSpeed();
        }
    }
#endregion

    #region LVL check
    void LVLCHECKSec()
    {
        if (CurrentBrewery.BrewerySecurity < 5 && Resources.Instance.PlayerCash >= CurrentBrewery.BrewerySecUpgradeCost)
        {
            SecUpgradeButton.interactable = true;
        }
        else
            SecUpgradeButton.interactable = false;
    }

    void LVLCHeckDEF()
    {
        if (CurrentBrewery.BreweryDeflect < 5 && Resources.Instance.PlayerCash >= CurrentBrewery.BreweryDefUpgradeCost)
        {
            DefUpgradeButton.interactable = true;
        }
        else
            DefUpgradeButton.interactable = false;
    }
    void LVLCheckProduction()
    {
        if (CurrentBrewery.BreweryprodLVL < 5 && Resources.Instance.PlayerCash >= CurrentBrewery.BreweryProdUpgradeCost)
        {
            ProductionUpgradeButton.interactable = true;
        }
        else
            ProductionUpgradeButton.interactable = false;
    }
     void LVLProductionSpeed()
    {
        if (CurrentBrewery.BreweryProdSpeed < 5 && Resources.Instance.PlayerCash >= CurrentBrewery.BreweryProdSpeedCost)
        {
            ProductionSpeedUpgradeButton.interactable = true;
        }
        else
            ProductionSpeedUpgradeButton.interactable = false;
    }
#endregion

    #region BreweryInfo
    public void BreweryInfoUpdate()
    {
        //building size/name and type
        BreweryName.text = CurrentBrewery.BreweryName;
        BrewerySize.text = CurrentBrewery.BrewerySize;
        BreweryType.text = CurrentBrewery.BreweryType;

        //building info regarding upgrades/costs/earnings

        //upgrade lvls
        BrewerySecurity.text = CurrentBrewery.BrewerySecurity.ToString();
        BreweryDeflect.text = CurrentBrewery.BreweryDeflect.ToString();
        BreweryProdLVL.text = CurrentBrewery.BreweryprodLVL.ToString();
        BreweryProdSpeed.text = CurrentBrewery.BreweryProdSpeed.ToString();

        //upgrade costs
        BrewerySecUpgradeCost.text = ((int)CurrentBrewery.BrewerySecUpgradeCost).ToString() + "$";
        BreweryDefUpgradeCost.text = ((int)CurrentBrewery.BreweryDefUpgradeCost).ToString() + "$";
        BreweryProdCost.text = ((int)CurrentBrewery.BreweryProdUpgradeCost).ToString() + "$";
        BreweryProdSpeedCost.text = ((int)CurrentBrewery.BreweryProdSpeedCost).ToString() + "$";

        //earnings and costs and police activity
        BreweryUpkeep.text = CurrentBrewery.BreweryUpkeep.ToString() + "$";
        BreweryProduction.text = CurrentBrewery.BreweryProduction.ToString();
        BreweryProductionSpeed.text = CurrentBrewery.BreweryProductionSpeed.ToString();
        BreweryPoliceActivity.text = CurrentBrewery.BreweryPoliceActivity.ToString();

    }
    #endregion
}

