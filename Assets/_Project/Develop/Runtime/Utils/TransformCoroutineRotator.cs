using System.Collections;
using UnityEngine;

namespace _Project.Develop.Runtime.Utils
{
    public class TransformCoroutineRotator : MonoBehaviour
    {
        [Header("Settings:")]
        [SerializeField] private bool _xAxis = false;
        [SerializeField] private bool _yAxis = false;
        [SerializeField] private bool _zAxis = true;
        [SerializeField] private float _speed = 250f;

        // Runtime
        private Coroutine _processRoutine = null;

        private void Update()
        {
            if (_processRoutine is null)
                _processRoutine = StartCoroutine(RotateProcess());
        }

        private IEnumerator RotateProcess()
        {
            while (true)
            {
                Vector3 rotationAxis = GetCompositeRotationAxis();

                transform.rotation *= Quaternion.Euler(rotationAxis * _speed * Time.deltaTime);

                yield return null;
            }
        }

        private Vector3 GetCompositeRotationAxis()
        {
            Vector3 result = Vector3.zero;

            if (_xAxis)
                result += Vector3.right;

            if (_yAxis)
                result += Vector3.up;

            if (_zAxis)
                result += Vector3.forward;

            return result;
        }
    }
}