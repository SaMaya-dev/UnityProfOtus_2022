using System;
using TMPro;
using UIFrames.Unity;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePopup : UnityFrame
{
    [SerializeField] private TextMeshProUGUI levelTxt;
    [SerializeField] private TextMeshProUGUI hpTxt;
    [SerializeField] private TextMeshProUGUI damageTxt;
    [SerializeField] private Image icon;
    [SerializeField] private Button btn;

    private IUpgradePopupPresentationModel presenter;
    protected override void OnShow(object args)
    {
        if (args is not IUpgradePopupPresentationModel presenter)
        {
            throw new Exception("Expected Presentation model!");
        }

        this.presenter = presenter;

        this.levelTxt.text = $"Level {presenter.GetLevel()} / {presenter.GetMaxLevel()}";
        this.hpTxt.text = $"Hit points {presenter.GetHP()} / {presenter.GetMaxHP()}";
        this.damageTxt.text = presenter.GetDamage();
        this.icon.sprite = presenter.GetIcon();

        this.btn.interactable = presenter.CanBeUpgraded(presenter.GetLevel());
        this.btn.onClick.AddListener(this.OnBuyButtonClicked);
    }
    
    protected override void OnHide()
    {
        this.btn.onClick.RemoveListener(this.OnBuyButtonClicked);
    }

    private void OnBuyButtonClicked()
    {
        this.presenter.BtnClicked();
        this.btn.interactable = presenter.CanBeUpgraded(presenter.GetLevel());
    }
}
