using System;
using UIFrames.Unity;
using UnityEngine;

namespace UIFrames.Examples
{
    public sealed class MyScreenManager : MonoBehaviour, IScreenManager<MyScreenName>
    {
        public event Action<MyScreenName> OnScreenShown;

        public event Action<MyScreenName> OnScrenHidden;

        public event Action<MyScreenName> OnScreenChanged;

        [SerializeField]
        private MyScreenSupplier supplier;

        private IScreenManager<MyScreenName> manager;

        private void Awake()
        {
            this.manager = new ScreenManager<MyScreenName, UnityFrame>(this.supplier);
        }

        private void OnEnable()
        {
            this.manager.OnScreenShown += this.OnShowScreen;
            this.manager.OnScreenChanged += this.OnChangeScreen;
            this.manager.OnScrenHidden += this.OnHideScreen;
        }

        private void OnDisable()
        {
            this.manager.OnScreenShown -= this.OnShowScreen;
            this.manager.OnScreenChanged -= this.OnChangeScreen;
            this.manager.OnScrenHidden -= this.OnHideScreen;
        }
        
        public void ChangeScreen(MyScreenName key, object args = default)
        {
            this.manager.ChangeScreen(key, args);
        }

        public bool IsScreenActive(MyScreenName key)
        {
            return this.manager.IsScreenActive(key);
        }

        private void OnShowScreen(MyScreenName screenName)
        {
            this.OnScreenShown?.Invoke(screenName);
        }

        private void OnHideScreen(MyScreenName screenName)
        {
            this.OnScrenHidden?.Invoke(screenName);
        }

        private void OnChangeScreen(MyScreenName screenName)
        {
            this.OnScreenChanged?.Invoke(screenName);
        }
    }
}