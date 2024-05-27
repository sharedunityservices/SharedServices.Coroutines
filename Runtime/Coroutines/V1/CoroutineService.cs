using System;
using System.Collections;
using UnityEngine;

namespace SharedServices.Coroutines.V1
{
    public class CoroutineService : ICoroutineService, IDisposable
    {
        private static CoroutineHelper _coroutineHelper = new CoroutineEditorHelper();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            _coroutineHelper = Application.isPlaying ? new CoroutineRuntimeHelper() : new CoroutineEditorHelper(); 
        }

        public void Dispose()
        {
            _coroutineHelper?.Dispose();
        }

        public RoutineObject StartCoroutine(IEnumerator routine)
        {
            return _coroutineHelper.StartCoroutine(routine);
        }

        public void StopCoroutine(RoutineObject routine)
        {
            _coroutineHelper.StopCoroutine(routine);
        }
    }
}