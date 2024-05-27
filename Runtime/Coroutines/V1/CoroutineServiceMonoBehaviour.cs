using UnityEngine;

namespace SharedServices.Coroutines.V1
{
    public class CoroutineServiceMonoBehaviour : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}