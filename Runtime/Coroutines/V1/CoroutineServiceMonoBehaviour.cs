using System;
using System.Collections;
using UnityEngine;

namespace SharedServices.Coroutines.V1
{
    public class CoroutineServiceMonoBehaviour : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
        
        internal Coroutine StartCoroutineWithCallback(IEnumerator routine, Action callback)
        {
            return StartCoroutine(RoutineWithCallback(routine, callback));
        }
        
        private IEnumerator RoutineWithCallback(IEnumerator routine, Action callback)
        {
            yield return routine;
            callback.Invoke();
        }
    }
}