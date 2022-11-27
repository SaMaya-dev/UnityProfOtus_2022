
using UnityEngine;

public interface IUpgradePopupPresentationModel
{
    string GetLevel();
    string GetMaxLevel();
    string GetHP();
    
    string GetMaxHP();
    string GetDamage();
    bool CanBeUpgraded(string level);
    Sprite GetIcon();
    void BtnClicked();
}
