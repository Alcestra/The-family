using UnityEngine;

public class Brewery : MonoBehaviour
{
    //Holds all the numbers for each pub

    public BreweryMenu breweryMenu;


    //strings holding the name/size and type of racket
    [Header ("Name size type")]
    public string BreweryName;
    public string BrewerySize;
    public string BreweryType;

    //Floats for storing upkeep/consumtion/POL activity and upgrade lvls + costs
    [Header("Building info")]
    public int BreweryUpkeep;
    public int BreweryProduction;
    public int BreweryProductionSpeed;
    public int BreweryPoliceActivity;

    [Header("Building upgrade lvls")]
    public int BrewerySecurity;
    public int BreweryDeflect;
    public int BreweryprodLVL;
    public int BreweryProdSpeed;

    [Header("LVL upgrade costs")]
    public float BrewerySecUpgradeCost;
    public float BreweryDefUpgradeCost;
    public float BreweryProdUpgradeCost;
    public float BreweryProdSpeedCost;

    private void Start()
    {
       Resources.Instance.IncreaseTotalUpkeep(BreweryUpkeep);
       Resources.Instance.IncreaseTotalProduction(BreweryProduction);
       Resources.Instance.IncreaseTotalPoliceActivity(BreweryPoliceActivity);
    }

    public void OpenBreweryUI()
    {
        breweryMenu.Open(this);
    }

    //lvl update for each upgrade
    #region upgrade lvl
    public void UpgradeSEC()
    {
        BrewerySecurity += 1;
        BreweryUpkeep += 1;
        Resources.Instance.IncreaseTotalUpkeep(1);
        Resources.Instance.Spend((int)BrewerySecUpgradeCost);
        UpgradeCostsSec();
    }

    public void UpgradeDef()
    {
        BreweryDeflect += 1;
        BreweryUpkeep += 4;
        BreweryPoliceActivity -= 2;
        Resources.Instance.IncreaseTotalUpkeep(4);
        Resources.Instance.Spend((int)BreweryDefUpgradeCost);
        Resources.Instance.DecreaseTotalPoliceActivity(2);
        UpgradeCostsDEF();
    }

    public void Upgradeproduction()
    {
        BreweryprodLVL += 1;
        BreweryUpkeep += 8;
        BreweryProduction += 2;
        BreweryPoliceActivity += 8;
        Resources.Instance.IncreaseTotalUpkeep(8);
        Resources.Instance.Spend((int)BreweryProdUpgradeCost);
        Resources.Instance.IncreaseTotalProduction(2);
        Resources.Instance.IncreaseTotalPoliceActivity(8);
        UpGradeCostsProd();
    }

    public void UpgradeProdSpeed()
    {
        BreweryProdSpeed += 1;
        BreweryUpkeep += 6;
        BreweryProductionSpeed += 2;
        Resources.Instance.IncreaseTotalUpkeep(6);
        Resources.Instance.Spend((int)BreweryProdSpeedCost);
        Resources.Instance.IncreaseTotalProduction(2);
        UpgradeCostsProdSpeed();
    }

    #endregion

    //Upgrade costs multiplyer 
    #region UPCosts
    void UpGradeCostsProd()
    {
        BreweryProdUpgradeCost += BreweryProdUpgradeCost * .5f;
    }

    void UpgradeCostsDEF()
    {
        BreweryDefUpgradeCost += BreweryDefUpgradeCost * 2f;
    }

    void UpgradeCostsSec()
    {
        BrewerySecUpgradeCost += BrewerySecUpgradeCost * 2f;
    }

    void UpgradeCostsProdSpeed()
    {
        BreweryProdSpeedCost += BreweryProdSpeedCost * .75f;
    }
    #endregion
}
