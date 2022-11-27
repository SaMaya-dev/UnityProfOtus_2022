using System.Collections.Generic;
using UnityEngine;

namespace Upgrades
{
    [CreateAssetMenu]
    public class Upgrades : ScriptableObject
    {
        public List<UpgradeInfo> upgradeList;
    }
}
