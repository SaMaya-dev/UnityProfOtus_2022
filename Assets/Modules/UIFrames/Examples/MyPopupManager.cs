using System;
using UIFrames.Unity;
using UnityEngine;

namespace UIFrames.Examples
{
    public sealed class MyPopupManager : MonoBehaviour, IPopupManager<MyPopupName>
    {
        public event Action<MyPopupName> OnPopupShown;

        public event Action<MyPopupName> OnPopupHidden;

        [SerializeField]
        private MyPopupSupplier supplier;

        private IPopupManager<MyPopupName> manager;

        private void Awake()
        {
            this.manager = new PopupManager<MyPopupName, UnityFrame>(this.supplier);
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

        public void ShowPopup(MyPopupName key, object args = null)
        {
            this.manager.ShowPopup(key, args);
        }

        public bool IsPopupActive(MyPopupName popupName)
        {
            return this.manager.IsPopupActive(popupName);
        }

        public void HidePopup(MyPopupName key)
        {
            this.manager.HidePopup(key);
        }

        public void HideAllPopups()
        {
            this.manager.HideAllPopups();
        }

        private void OnShowPopup(MyPopupName popupName)
        {
            this.OnPopupShown?.Invoke(popupName);
        }

        private void OnHidePopup(MyPopupName popupName)
        {
            this.OnPopupHidden?.Invoke(popupName);
        }
    }
}