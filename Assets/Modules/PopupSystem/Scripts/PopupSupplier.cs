using UIFrames.Unity;
using UnityEngine;

namespace Game.GameEngine
{
    public sealed class PopupSupplier : UnityFrameSupplier<PopupName, UnityFrame>
    {
        [SerializeField]
        private PopupFactory factory;

        protected override UnityFrame InstantiateFrame(PopupName key)
        {
            return this.factory.CreateFrame(key);
        }
    }
}