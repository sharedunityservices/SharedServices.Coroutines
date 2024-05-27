using System.Collections;
using Object = UnityEngine.Object;

namespace Services.Coroutines
{
    public class CoroutineRuntimeHelper : CoroutineHelper
    {
        private readonly CoroutineServiceMonoBehaviour _coroutineMonoBehaviour =
            GameObjectUtil.CreateDDOLWith<CoroutineServiceMonoBehaviour>("CoroutineService");

        public override RoutineObject StartCoroutine(IEnumerator routine)
        {
            return new RoutineObject(_coroutineMonoBehaviour.StartCoroutine(routine));
        }
        
        public override void StopCoroutine(RoutineObject routine)
        {
            _coroutineMonoBehaviour.StopCoroutine(routine.Coroutine);
        }

        public override void Dispose()
        {
            if (_coroutineMonoBehaviour) Object.Destroy(_coroutineMonoBehaviour.gameObject);
        }
    }
}