using System;
using Elementary;
using UnityEngine;

namespace Modules.Components
{
    public class DeathComponent : MonoBehaviour, IDeathComponent
    {
        public event Action OnDeath
        {
            add { deathReceiver.OnEvent += value; }
            remove { deathReceiver.OnEvent -= value; }
        }
        [SerializeField] private EventReceiver deathReceiver;
        
    }
}