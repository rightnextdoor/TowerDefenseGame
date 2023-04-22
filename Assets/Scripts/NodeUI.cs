using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject ui;

    public TextMeshProUGUI upgradeCostText;
    public TextMeshProUGUI sellCostText;
    public Button upgradeButton;

    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();

        sellCostText.text = "$" + target.turretBlueprint.GetSellAmount();

        if(!target.isUpgraded)
        {
            upgradeCostText.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        } else
        {
            upgradeCostText.text = "DONE";
            upgradeButton.interactable = false;
        }

        ui.SetActive(true);
    }

    public void Hide() {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
