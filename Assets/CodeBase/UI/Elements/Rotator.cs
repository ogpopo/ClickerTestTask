using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.UI.Elements
{
    public class Rotator : MonoBehaviour
    {
        [FormerlySerializedAs("rotationAxis")] [SerializeField] private Vector3 _rotationAxis;
        [FormerlySerializedAs("rotationSpeed")] [SerializeField] private float _rotationSpeed;

        private void Update() => 
            transform.Rotate(_rotationAxis, _rotationSpeed * Time.deltaTime);
    }
}