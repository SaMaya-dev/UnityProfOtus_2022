using System;
using UnityEngine;
using UnityEngine.UI;
/*
public class PlayerPopup //: Popup
{
    [SerializeField] private Text levelTxt;
    [SerializeField] private Text hpTxt;
    [SerializeField] private Text damageTxt;
    [SerializeField] private Image icon;
    [SerializeField] private Button btn;

    private IPresentationModel presenter;
    protected override void OnShow(object args)
    {
        if (args is not IPresentationModel presenter)
        {
            throw new Exception("Expected Presentation model!");
        }

        this.presenter = presenter;

        this.levelTxt.text = $"Level {presenter.GetTLevel() / presenter.GetMaxLevel()}";
        this.hpTxt.text = presenter.GetHP();
        this.damageTxt.text = presenter.GetDamage();
        this.icon.sprite = presenter.GetIcon();

        this.btn.interactable = presenter.CanBeUpgraded();
        this.btn.onClick.AddListener(this.OnBuyButtonClicked);
    }
    
    protected override void OnHide()
    {
        this.btn.onClick.RemoveListener(this.OnBuyButtonClicked);
    }

    private void OnBuyButtonClicked()
    {
        this.presenter.BtnClicked();
        this.btn.interactable = presenter.CanBeUpgraded();
    }
}

public class UpgradePresentationModel : IPresentationModel
{
    private UpgradeInfo upgradeInfo;
    private PlayerUpgrader playerUpgrader;
    
    public UpgradePresentationModel(UpgradeInfo upgradeInfo, PlayerUpgrader playerUpgrader)
    {
        this.upgradeInfo = upgradeInfo;
        this.playerUpgrader = playerUpgrader;
    }
    
    public string GetTLevel =>  upgradeInfo.level;
    public string GetMaxLevel =>  upgradeInfo.maxLevel;
    
    public string GetHP => upgradeInfo.hp;

    public string GetDamage => upgradeInfo.damage;

    public bool CanBeUpgraded => playerUpgrader.CanBeUpgraded(upgradeInfo.level);

    public Sprite GetIcon => upgradeInfo.icon;

    public void BtnClicked()
    {
        playerUpgrader.Upgrade(upgradeInfo.level);
    }
}

public interface IPresentationModel
{
    string GetTLevel();
    string GetMaxLevel();
    string GetHP();
    string GetDamage();
    bool CanBeUpgraded(string level);
    Sprite GetIcon();
    void BtnClicked();
}

public class PlayerUpgrader
{
    public bool CanBeUpgraded(string level)
    {
        return true;
    }

    public void Upgrade()
    {
        //...
    }
}

public class UpgradeInfo
{
    public string level { get; set; }
    public string maxLevel { get; set; }
    public string damage { get; set; }
    public string hp { get; set; }
    public Sprite icon { get; set; }
}
*/