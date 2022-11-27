using System;
using Sirenix.OdinInspector;
using UIFrames;
using UIFrames.Unity;
using UnityEngine;

namespace Game.GameEngine
{
    public sealed class PopupManager : MonoBehaviour, IPopupManager<PopupName>
    {
        public event Action<PopupName> OnPopupShown;

        public event Action<PopupName> OnPopupHidden;

        [SerializeField]
        private PopupSupplier supplier;

        private IPopupManager<PopupName> manager;

        private void Awake()
        {
            this.manager = new PopupManager<PopupName, UnityFrame>(this.supplier);
        }

        private void OnEnable()
        {
            this.manager.OnPopupShown += this.OnShowPopup;
            this.manager.OnPopupHidden += this.OnHidePopup;
        }

        private void OnDisable()
        {
            this.manager.OnPopupShown -= this.OnShowPopup;
            this.manager.OnPopupHidden -= this.OnHidePopup;
        }

        [Button]
        public void ShowPopup(PopupName key, object args = null)
        {
            this.manager.ShowPopup(key, args);
        }

        [Button]
        public void HidePopup(PopupName key)
        {
            this.manager.HidePopup(key);
        }

        [Button]
        public void HideAllPopups()
        {
            this.manager.HideAllPopups();
        }

        public bool IsPopupActive(PopupName popupName)
        {
            return this.manager.IsPopupActive(popupName);
        }

        private void OnShowPopup(PopupName popupName)
        {
            this.OnPopupShown?.Invoke(popupName);
        }

        private void OnHidePopup(PopupName popupName)
        {
            this.OnPopupHidden?.Invoke(popupName);
        }
    }
}