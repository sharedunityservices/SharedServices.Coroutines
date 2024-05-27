using System.Collections;
using SharedServices;
using SharedServices.V1;

namespace Services.Coroutines
{
    public interface ICoroutineService : IService
    {
        public RoutineObject StartCoroutine(IEnumerator routine);
        public void StopCoroutine(RoutineObject routineObject);
    }
}