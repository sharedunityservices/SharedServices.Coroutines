using UnityEngine;

namespace Services.Coroutines
{
    public class RoutineObject
    {
        internal Coroutine Coroutine { get; }
        internal EditorCoroutine EditorCoroutine { get; }

        public RoutineObject(Coroutine coroutine)
        {
            Coroutine = coroutine;
        }
        
        public RoutineObject(EditorCoroutine editorCoroutine)
        {
            EditorCoroutine = editorCoroutine;
        }
    }
}