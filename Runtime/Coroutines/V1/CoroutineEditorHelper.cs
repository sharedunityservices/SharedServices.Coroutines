using System.Collections;
using System.Collections.Generic;

namespace SharedServices.Coroutines.V1
{
    public class CoroutineEditorHelper : CoroutineHelper
    {
        private readonly List<RoutineObject> _editorRoutineObjects = new();
        
        public override RoutineObject StartCoroutine(IEnumerator routine)
        {
            var editorCoroutine = EditorCoroutine.StartCoroutine(routine);
            var editorRoutineObject = new RoutineObject(editorCoroutine);
            _editorRoutineObjects.Add(editorRoutineObject);
            return editorRoutineObject;
        }

        public override void StopCoroutine(RoutineObject routine)
        {
            _editorRoutineObjects.Remove(routine);
            routine.EditorCoroutine.Stop();
        }

        public override void Dispose()
        {
            foreach (var editorRoutineObject in _editorRoutineObjects) 
                editorRoutineObject.EditorCoroutine.Stop();
        }
    }
}