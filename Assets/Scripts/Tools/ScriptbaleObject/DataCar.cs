using UnityEngine;

/// <summary>
/// Данные машины.
/// </summary>
[CreateAssetMenu(fileName = "CarValue",menuName = "Scriptable Object/Car/Data Car",order = 50)]
public class DataCar : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private float _mass;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _sensitiveAngle;
    [SerializeField] private float _breakSpeed;

    [SerializeField] private AudioClip _passiveCar;
    [SerializeField] private AudioClip _activeCar;

    public float Mass { get => _mass; }
    public float Speed { get => _speed; }
    public float MaxSpeed { get => _maxSpeed; }
    public float SensityveAngle { get => _sensitiveAngle; }
    public float BreakSpeed { get => _breakSpeed; }

    public AudioClip SoundPassiveCar { get => _passiveCar;}
    public AudioClip SoundActiveCar { get => _activeCar;}
}