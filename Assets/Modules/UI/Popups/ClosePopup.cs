using Game.GameEngine;
using UIFrames;
using UnityEngine;
using Zenject;

public class ClosePopup : MonoBehaviour
{
    [SerializeField] private PopupName key;
    [Inject] private IPopupManager<PopupName> popupManager;
    
    public void HidePopup()
    {
        popupManager.HidePopup(key);
    }
    
}
