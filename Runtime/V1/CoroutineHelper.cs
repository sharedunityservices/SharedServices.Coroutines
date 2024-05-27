using System.Collections;

namespace Services.Coroutines
{
    public abstract class CoroutineHelper
    {
        public abstract RoutineObject StartCoroutine(IEnumerator routine);
        public abstract void StopCoroutine(RoutineObject routine);
        public abstract void Dispose();
    }
}