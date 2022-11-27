using UnityEngine;
using Upgrades;

public class UpgradePopupPresentationModel : IUpgradePopupPresentationModel
{
    private UpgradeInfo upgradeInfo;
    private PlayerUpgrader playerUpgrader;
    public UpgradePopupPresentationModel(UpgradeInfo upgradeInfo, PlayerUpgrader playerUpgrader)
    {
        this.upgradeInfo = upgradeInfo;
        this.playerUpgrader = playerUpgrader;
    }
    
    public string GetLevel() =>  upgradeInfo.level;

    public string GetMaxLevel() =>  upgradeInfo.maxLevel;
    public string GetHP()=> upgradeInfo.hp;
    public string GetMaxHP()=> upgradeInfo.maxHp;
    public string GetDamage() => upgradeInfo.damage;
    public bool CanBeUpgraded(string level) => playerUpgrader.CanBeUpgraded(upgradeInfo.level);
    public Sprite GetIcon() => upgradeInfo.icon;
    public void BtnClicked() => playerUpgrader.Upgrade(upgradeInfo.level);

}
