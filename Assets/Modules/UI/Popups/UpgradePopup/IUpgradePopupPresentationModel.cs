using System;
using UnityEngine;

namespace Upgrades
{
    public interface IUpgradePopupPresentationModel
    {
        event Action<IUpgradePopupPresentationModel> OnStateChanged;
        string GetLevelText();
        string GetHPText();
        string GetDamageText();
        bool CanBeUpgraded();
        Sprite GetIcon();
        void OnButtonClicked();
    }
}
