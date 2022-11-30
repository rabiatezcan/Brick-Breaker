using UnityEngine;

namespace GameCore
{
    [CreateAssetMenu(menuName = "Game/Movement Settings", order = 2)]
    public class MovementSettings : ScriptableObject
    {
        [Header("Movement Parameters")]

        [SerializeField] private float _minX;
        [SerializeField] private float _maxX;
        [SerializeField] private float _horizontalSpeed;

        public float MinX => _minX;
        public float MaxX => _maxX;
        public float HorizontalSpeed => _horizontalSpeed;
    }
}