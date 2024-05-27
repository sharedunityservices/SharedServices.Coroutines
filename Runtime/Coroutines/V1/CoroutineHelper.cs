using System.Collections;

namespace SharedServices.Coroutines.V1
{
    public abstract class CoroutineHelper
    {
        public abstract RoutineObject StartCoroutine(IEnumerator routine);
        public abstract void StopCoroutine(RoutineObject routine);
        public abstract void Dispose();
    }
}