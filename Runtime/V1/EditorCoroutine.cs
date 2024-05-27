using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Services.Coroutines
{
    public class EditorCoroutine
    {
        private readonly Stack<IEnumerator> _stack = new();

        public static EditorCoroutine StartCoroutine(IEnumerator routine)
        {
            var coroutine = new EditorCoroutine(routine);
            coroutine.StartCoroutine();
            return coroutine;
        }

        private readonly IEnumerator _routine;

        private EditorCoroutine(IEnumerator routine)
        {
            _stack.Push(routine);
        }

        private void StartCoroutine()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.update += Update;
#endif
        }

        internal void Stop()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.update -= Update;
#endif
        }

        private void Update()
        {
            var top = _stack.Peek();
            if (top == null)
            {
                Stop();
                return;
            }

            if (!top.MoveNext())
            {
                _stack.Pop();
                if (_stack.Count != 0) return;
                Stop();
                return;
            }

            if (top.Current is IEnumerator enumerator)
            {
                _stack.Push(enumerator);
            }
            else if (top.Current is YieldInstruction instruction)
            {
                _stack.Push(Yield(instruction));
            }
        }

        private static IEnumerator Yield(YieldInstruction yieldInstruction)
        {
            yield return yieldInstruction;
        }
    }
}