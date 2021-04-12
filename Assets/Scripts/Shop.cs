using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;

    public Text standardTextCost;
    public Text missileLauncherTextCost;
    public Text laserBeamerTextCost;

    public 

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
        standardTextCost.text = "$" + standardTurret.cost;
        missileLauncherTextCost.text = "$" + missileLauncher.cost;
        laserBeamerTextCost.text = "$" + laserBeamer.cost;
    }

    public void SelectStandardTurret() {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Missle Launcher Selected");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer Selected");
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}
