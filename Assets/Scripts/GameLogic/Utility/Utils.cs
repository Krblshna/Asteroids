using UnityEngine;
using System;
using System.Collections;

namespace Asteroids.GameLogic.Utility
{
    public class Utils : Singleton<Utils>
    {
        public static void SetTimeOut(Action func, float seconds)
        {
            Utils.Instance.setTimeOut(func, seconds);
        }
        public void setTimeOut(Action func, float seconds)
        {
            StartCoroutine(delayed_action(func, seconds));
        }

        IEnumerator delayed_action(Action func, float seconds)
        {
            yield return new WaitForSeconds(seconds);
            func?.Invoke();
        }
    }
}