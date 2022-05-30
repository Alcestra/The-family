using UnityEngine;
using UnityEngine.UI;

public class ResourceMenu : MonoBehaviour
{   
    //cash
    public Text playerCash;
    public Text Upkeep;

    //liqour
    public Text currentLiqour;
    public Text maxLiqour;
    public Text LiqourProd;
    


    // Update is called once per frame
    void Update()
    {
        ResourceUpdate();
    }


    void ResourceUpdate()
    {
        //updating display values
        playerCash.text = Resources.Instance.PlayerCash.ToString() + "$";
        currentLiqour.text = Resources.Instance.currentLiqour.ToString();
       maxLiqour.text = Resources.Instance.LiqourStorage.ToString();
        Upkeep.text = "(" +Resources.Instance.NetIncome.ToString()  + "$" + ")";
        LiqourProd.text = "(" +Resources.Instance.NetProduction.ToString() + ")";
    }
}
