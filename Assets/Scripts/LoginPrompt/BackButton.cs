using System;
using UnityEngine;

namespace LoginPrompt
{
    public class BackButton : MonoBehaviour
    {
        public static event Action OnBackButtonPressed;

        public void PostOnBackButtonPressed()
        {
            OnBackButtonPressed?.Invoke();
        }
    }
}
