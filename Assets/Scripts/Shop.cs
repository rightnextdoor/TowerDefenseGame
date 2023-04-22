using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;

    public TextMeshProUGUI standardTurretCostText;
    public TextMeshProUGUI missileLauncherCostText;
    public TextMeshProUGUI laserBeamerCostText;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
        standardTurretCostText.text = "$ " + standardTurret.cost.ToString();
        missileLauncherCostText.text = "$ " + missileLauncher.cost.ToString();
        laserBeamerCostText.text = "$ " + laserBeamer.cost.ToString();
    }

    public void SelectStandardTurret() {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher Selected");
        buildManager.SelectTurretToBuild(missileLauncher);
    }
    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer Selected");
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}
