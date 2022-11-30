using System;
using UnityEngine;
using Upgrades;

public class UpgradePopupPresentationModel : IUpgradePopupPresentationModel
{
    public event Action<IUpgradePopupPresentationModel> OnStateChanged;
        
    private readonly UpgradeInfo upgradeInfo;
    private readonly PlayerUpgrader playerUpgrader;
    private readonly UpgradeModelFactory factory;

    public UpgradePopupPresentationModel(UpgradeInfo upgradeInfo, PlayerUpgrader playerUpgrader, UpgradeModelFactory factory)
    {
        this.upgradeInfo = upgradeInfo;
        this.playerUpgrader = playerUpgrader;
        this.factory = factory;
    }
    
    public string GetLevelText() =>  $"Level {upgradeInfo.level} / {upgradeInfo.maxLevel}";
    public string GetHPText()=>  $"Level {upgradeInfo.hp} / {upgradeInfo.maxHp}";
    public string GetDamageText() => upgradeInfo.damage.ToString();
    public bool CanBeUpgraded() => playerUpgrader.CanBeUpgraded(upgradeInfo.level);
    public Sprite GetIcon() => upgradeInfo.icon;

    public void OnButtonClicked()
    {
        if (playerUpgrader.Upgrade(upgradeInfo.level))
        {
            var newModel = factory.Create();
            OnStateChanged?.Invoke(newModel);
        }
    }
}
