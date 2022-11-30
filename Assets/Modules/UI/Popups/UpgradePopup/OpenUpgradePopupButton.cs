using Game.GameEngine;
using UIFrames;
using UnityEngine;
using UnityEngine.UI;
using Upgrades;
using Zenject;

//Вспомонательный классик для открытия попапа с настройками
public class OpenUpgradePopupButton : MonoBehaviour
{
    [SerializeField] private PopupName key;
    [SerializeField] private Button button;

    [Inject] private IPopupManager<PopupName> popupManager;
    [Inject] private UpgradeModelFactory upgradeModelFactory;
    
    private void Awake()
    {
        button.onClick.AddListener(ShowPopup);
    }

    private void ShowPopup()
    {
        var model = upgradeModelFactory.Create();
        popupManager.ShowPopup(key, model);
    }
}
