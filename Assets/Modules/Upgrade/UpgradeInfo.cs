using UnityEngine;

namespace Upgrades
{ 
    [CreateAssetMenu]
    public class UpgradeInfo : ScriptableObject
    {
        public string level;
        public string maxLevel;
        public string hp;
        public string maxHp;
        public string damage;
        public Sprite icon;
    }
}
