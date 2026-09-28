using System.Collections;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Collided
{
    public class BreakablePlatform : MonoBehaviour
    {
        [Header("Settings:")]
        [SerializeField] private float _timeToDestroy = 5f;

        // References
        private Coroutine _processRoutine = default;

        // Runtime
        private bool _isCollision = default;
        private float _timer = default;

        public float Progress => _timer / _timeToDestroy;

        private void Awake()
            => _timer = _timeToDestroy;

        private void OnCollisionStay2D()
        {
            if (_processRoutine == null)
                _processRoutine = StartCoroutine(ProcessRoutine());

            _isCollision = true;
        }

        private void OnCollisionExit2D()
            => _isCollision = false;

        private IEnumerator ProcessRoutine()
        {
            while (_timer > 0f)
            {
                if (_isCollision)
                    _timer -= Time.deltaTime;

                yield return null;
            }

            _processRoutine = null;

            Destroy(gameObject);
        }
    }
}