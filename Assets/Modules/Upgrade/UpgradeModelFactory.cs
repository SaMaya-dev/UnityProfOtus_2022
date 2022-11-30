using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Upgrades
{
    public sealed class UpgradeModelFactory : MonoBehaviour
    {
        [SerializeField] private Upgrades upgrades;

        [Inject] private PlayerUpgrader playerUpgrader;

        //Получается, Кешировать моде, потому что мы меняе
        // private Dictionary<int, IUpgradePopupPresentationModel> cashedModels =
        //     new Dictionary<int, IUpgradePopupPresentationModel>();

        public IUpgradePopupPresentationModel Create()
        {
            int level = playerUpgrader.GetNewLevel();

            if (level >= upgrades.upgradeList.Count)
                level = upgrades.upgradeList.Count - 1;

            // if (!cashedModels.ContainsKey(level))
            //     cashedModels[level] = new UpgradePopupPresentationModel(upgrades.upgradeList[level], playerUpgrader);

            // return cashedModels[level];

            return new UpgradePopupPresentationModel(upgrades.upgradeList[level], playerUpgrader, this);
        }
        
    }
}