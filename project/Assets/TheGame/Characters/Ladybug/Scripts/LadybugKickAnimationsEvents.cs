using System;
using UnityEngine;

namespace TheGame.Characters.Ladybug
{
    public class LadybugKickAnimationsEvents : MonoBehaviour
    {
        public event Action OnKick;
        
        public void InvokeOnKickEvent() => 
            OnKick?.Invoke();
    }
}