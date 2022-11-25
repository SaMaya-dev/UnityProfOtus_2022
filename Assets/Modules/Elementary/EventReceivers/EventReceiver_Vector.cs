using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Elementary
{
    public class EventReceiver_Vector : MonoBehaviour
    {
        public event Action<Vector3> OnEvent;

        [PropertySpace(8)]
        [GUIColor(0, 1, 0)]
        [Button]
        public void Call(Vector3 vector3)
        {
            this.OnEvent?.Invoke(vector3);
        }
    }
}