using UnityEngine;

namespace Upgrades
{
    public class PlayerUpgrader : MonoBehaviour
    {

        public int CurrentLevel => PlayerPrefs.GetInt("lvl", 0);
        public bool CanBeUpgraded(int level)
        {
            //ToDo
            return true;
        }

        public bool Upgrade(int level)
        {
            //ToDO
            if (CurrentLevel == level)
            {
                Debug.Log($"Max level {level}!");
                return false;
            }
                
            Debug.Log($"Upgraded to level {level}!");
            PlayerPrefs.SetInt("lvl", level);
            return true;
        }

        public int GetNewLevel()
        {
            return (CurrentLevel + 1);
        }
    }
}