using System.Collections;
using System.Collections.Generic;
using _Project.Develop.Runtime.Gameplay.Features.TriggeredFeatures;
using UnityEngine;

namespace _Project.Develop.Runtime.Utils
{
    public class TransformCoroutineCurveWaypointsMover : MonoBehaviour
    {
        // Consts
        private const int MinCountPointsToProcess = 1;

        [Header("References:")]
        [SerializeField] private Transform[] _waypoints = null;
        [SerializeField] private AnimationCurve _xOffsetCurve = null;
        [SerializeField] private AnimationCurve _yOffsetCurve = null;

        [Space]
        [Header("Settings:")]
        [SerializeField] private float _speed = 5f;

        // Runtime
        private Queue<Vector2> _waypointsQueue = null;
        private Coroutine _processRoutine = null;

        private void Awake()
        {
            _waypointsQueue = new Queue<Vector2>();

            foreach (Transform point in _waypoints)
                _waypointsQueue.Enqueue(point.position);
        }

        private void OnEnable()
            => StartMoveRoutine();

        private void OnDisable()
            => StopMoveRoutine();

        private void Update()
            => StartMoveRoutine();

        private void StartMoveRoutine()
        {
            if (_processRoutine is null && _waypointsQueue.Count > MinCountPointsToProcess)
                _processRoutine = StartCoroutine(MoveProcess());
        }

        private void StopMoveRoutine()
        {
            if (_processRoutine is null)
                return;

            StopCoroutine(_processRoutine);

            _processRoutine = null;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IDamageable damageable))
                damageable.TakeDamage();
        }

        private IEnumerator MoveProcess()
        {
            Vector2 startPosition = transform.position;
            Vector2 endPosition = _waypointsQueue.Dequeue();

            _waypointsQueue.Enqueue(endPosition);

            float duration = Vector2.Distance(startPosition, endPosition) / _speed;

            float progress = 0f;

            while (progress < duration)
            {
                float xOffset = _xOffsetCurve == null
                    ? 0f
                    : _xOffsetCurve.Evaluate(progress / duration);

                float yOffset = _yOffsetCurve == null
                    ? 0f
                    : _yOffsetCurve.Evaluate(progress / duration);

                Vector2 offset = Vector2.right * xOffset + Vector2.up * yOffset;

                transform.position = Vector2.Lerp(startPosition, endPosition, progress / duration) + offset;

                progress += Time.deltaTime;

                yield return null;
            }

            _processRoutine = null;
        }
    }
}