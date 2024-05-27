using System.Collections;
using SharedServices.V1;

namespace SharedServices.Coroutines.V1
{
    public interface ICoroutineService : IService
    {
        public RoutineObject StartCoroutine(IEnumerator routine);
        public void StopCoroutine(RoutineObject routineObject);
    }
}