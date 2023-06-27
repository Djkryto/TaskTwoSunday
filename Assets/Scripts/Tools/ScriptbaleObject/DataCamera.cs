using UnityEngine;

/// <summary>
/// Данные камеры.
/// </summary>
[CreateAssetMenu(fileName = "DataCamera", menuName = "Scriptable Object/Camera/Data Camera", order = 50)]
public class DataCamera : ScriptableObject
{
    [SerializeField] private float _transitionSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Vector3 _offset;

    public float TransitionSpeed { get => _transitionSpeed; }
    public Vector3 Offset { get => _offset; }
    public float RotationSpeed { get => _rotationSpeed;}
}