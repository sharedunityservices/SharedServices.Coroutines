using System.Collections;
using UnityEngine;

namespace SharedServices.Coroutines.V1
{
    public class RoutineObject : CustomYieldInstruction
    {
        private bool _runtimeKeepWaiting = true;
        public override bool keepWaiting => Coroutine != null ? _runtimeKeepWaiting : EditorCoroutine is { KeepWaiting: true };
        
        internal Coroutine Coroutine { get; }
        internal EditorCoroutine EditorCoroutine { get; }

        public RoutineObject(CoroutineServiceMonoBehaviour coroutineServiceMonoBehaviour, IEnumerator routine)
        {
            Coroutine = coroutineServiceMonoBehaviour.StartCoroutineWithCallback(routine, () => _runtimeKeepWaiting = false);
        }
        
        public RoutineObject(EditorCoroutine editorCoroutine)
        {
            EditorCoroutine = editorCoroutine;
        }
    }
}