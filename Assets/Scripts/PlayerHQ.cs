using UnityEngine;

public class PlayerHQ : MonoBehaviour
{
    //Holds all the numbers for each pub

    public PlayerHQmenu HQMenu;  


    //strings holding the name/size and type of racket
    [Header("Name size type")]
    public string HQ;
    public string HQSize;
    public string HQType;

    //Floats for storing upkeep/consumtion/POL activity and upgrade lvls + costs
    [Header("Building info")]
    public int HQUpkeep;
    public int HQProduction;
    public int HQProductionSpeed;
    public int HQPoliceActivity;

    [Header("Building upgrade lvls")]
    public int HQSecurity;
    public int HQprodLVL;
    public int HQProdSpeed;

    [Header("LVL upgrade costs")]
    public float HQSecUpgradeCost;
    public float HQProdUpgradeCost;
    public float HQProdSpeedCost;


    [Header("combat power")]
    public int CombatPower;

    private void Start()
    {
        Resources.Instance.IncreaseTotalUpkeep(HQUpkeep);
        Resources.Instance.IncreaseTotalProduction(HQProduction);
        Resources.Instance.IncreaseTotalPoliceActivity(HQPoliceActivity);
    }

  

    public void OpenHQUI()
    {
        HQMenu.Open(this);
    }

    //lvl update for each upgrade
    #region upgrade lvl
    public void UpgradeSEC()
    {
        HQSecurity += 1;
        HQUpkeep += 1;
        Resources.Instance.IncreaseTotalUpkeep(1);
        Resources.Instance.Spend((int)HQSecUpgradeCost);
        UpgradeCostsSec();
    }

    

    public void Upgradeproduction()
    {
        HQprodLVL += 1;
        HQUpkeep += 8;
        HQProduction += 2;
        HQPoliceActivity += 8;
        Resources.Instance.IncreaseTotalUpkeep(8);
        Resources.Instance.Spend((int)HQProdUpgradeCost);
        Resources.Instance.IncreaseTotalProduction(2);
        Resources.Instance.IncreaseTotalPoliceActivity(8);
        UpGradeCostsProd();
    }

    public void UpgradeProdSpeed()
    {
        HQProdSpeed += 1;
        HQUpkeep += 6;
        HQProductionSpeed += 2;
        Resources.Instance.IncreaseTotalUpkeep(6);
        Resources.Instance.Spend((int)HQProdSpeedCost);
        Resources.Instance.IncreaseTotalProduction(2);
        UpgradeCostsProdSpeed();
    }


    public void HireTierOne()
    {
        CombatPower += 5;
    }

    public void HireTierTwo()
    {
        CombatPower += 10;
    }

    public void HireTierThree()
    {
        CombatPower += 20;
    }
    #endregion

    //Upgrade costs multiplyer 
    #region UPCosts
    void UpGradeCostsProd()
    {
        HQProdUpgradeCost += HQProdUpgradeCost * .5f;
    }

    

    void UpgradeCostsSec()
    {
        HQSecUpgradeCost += HQSecUpgradeCost * 2f;
    }

    void UpgradeCostsProdSpeed()
    {
        HQProdSpeedCost += HQProdSpeedCost * .75f;
    }
    #endregion

   
}
