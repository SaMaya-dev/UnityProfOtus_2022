using UnityEngine;
using UnityEngine.Serialization;

namespace Upgrades
{
    public class PlayerUpgrader : MonoBehaviour
    {
        [SerializeField] private Upgrades upgrades;
        
        public IUpgradePopupPresentationModel GetModel()
        {
            return new UpgradePopupPresentationModel(upgrades.upgradeList[0], this);
        }
        
        public bool CanBeUpgraded(string level)
        {
            //ToDo
            return true;
        }

        public void Upgrade(string upgradeInfoLevel)
        {
            //ToDO
            Debug.Log($"Upgraded to level {upgradeInfoLevel}!");
        }
    }
}