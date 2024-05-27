using UnityEngine;

namespace Services.Coroutines
{
    public class CoroutineServiceMonoBehaviour : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}