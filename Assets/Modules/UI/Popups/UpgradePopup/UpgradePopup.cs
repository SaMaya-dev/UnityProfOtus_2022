using System;
using TMPro;
using UIFrames.Unity;
using UnityEngine;
using UnityEngine.UI;
using Upgrades;

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
        
        btn.onClick.AddListener(OnBuyButtonClicked);

        this.presenter = presenter;
        presenter.OnStateChanged += UpdateState;
        
        UpdateView();
    }
    
    protected override void OnHide()
    {
        btn.onClick.RemoveListener(this.OnBuyButtonClicked);
        
        if (presenter != null)
            presenter.OnStateChanged -= UpdateState;
    }
    
    private void UpdateView()
    {
        levelTxt.text = presenter.GetLevelText();
        hpTxt.text = $"Hit points {presenter.GetHPText()}";
        damageTxt.text = presenter.GetDamageText();
        icon.sprite = presenter.GetIcon();

        btn.interactable = presenter.CanBeUpgraded();
    }
    
    private void UpdateState(IUpgradePopupPresentationModel model)
    {
        if (presenter != model)
        {
            presenter.OnStateChanged -= UpdateState;
            
            presenter = model;
            presenter.OnStateChanged += UpdateState;
        }

        UpdateView();
    }

    private void OnBuyButtonClicked()
    {
        presenter.OnButtonClicked();
        btn.interactable = presenter.CanBeUpgraded();
    }
}
