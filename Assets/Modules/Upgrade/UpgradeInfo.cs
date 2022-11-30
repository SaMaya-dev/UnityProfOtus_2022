using UnityEngine;

namespace Upgrades
{ 
    [CreateAssetMenu]
    public class UpgradeInfo : ScriptableObject
    {
        public int level;
        public int maxLevel;
        public int hp;
        public int maxHp;
        public int damage;
        public Sprite icon;
    }
}
