using UnityEngine;

/// <summary>
/// Класс управления машиной.
/// </summary>
public class CarController : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    private AudioClip _passive;
    private AudioClip _active;
    private Rigidbody _rb;

    private float _horizontal;
    private float _vertical;
    private float _currentStreetAngle;

    private float _speedForce;
    private float _sensitiveAngle;
    private float _maxSpeed;

    private bool _switchSound;
    private bool _storeSwitchSound;
    private bool _isBracking;
    private bool _isMove;

    private float _timer;

    [SerializeField] private WheelCollider _wheelFrontRightCollider;
    [SerializeField] private WheelCollider _wheelFrontLeftCollider;
    [SerializeField] private WheelCollider _wheelBackRightCollider;
    [SerializeField] private WheelCollider _wheelBackLeftCollider;

    [SerializeField] private Transform _wheelFrontRightTransform;
    [SerializeField] private Transform _wheelFrontLeftTransform;
    [SerializeField] private Transform _wheelBackRightTransform;
    [SerializeField] private Transform _wheelBackLeftTransform;

    private const float SPEED_MULTIPLIER = 20;

    /// <summary>
    /// Остановка машины.
    /// </summary>
    public void StopCar() => _isMove = false;


    public void Init(DataCar data,Rigidbody rb)
    {
        _isMove = true;

        _speedForce = data.Speed;
        _sensitiveAngle = data.SensityveAngle;
        _maxSpeed = data.MaxSpeed;

        _rb = rb;

        _active = data.SoundActiveCar;
        _passive = data.SoundPassiveCar;

        _switchSound = true;
    }

    private void FixedUpdate()
    {
        if (!_isMove)
        {
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, 0);
            return;
        }

        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    /// <summary>
    /// Установка вектора направления поездки.
    /// </summary>
    /// <param name="direct">Направление</param>
    public void SetDirect(Vector3 direct)
    {
        _horizontal = direct.x;
        _vertical =  direct.y;

        if (direct.x == 0 && direct.y == 0)
            _isBracking = true;
        else
            _isBracking = false;
    }

    private void HandleMotor()
    {
        SetClampSpeed();
        SwitchSound();

        if (_isBracking)
        {
            ApplyBreaking();
        }
        else
        {
            _timer = _rb.velocity.magnitude;
            _wheelFrontRightCollider.motorTorque = HandleSpeed();
            _wheelFrontLeftCollider.motorTorque = HandleSpeed();
        }
    }

    private void ApplyBreaking()
    {
        if (_timer > 0)
            _timer -= Time.fixedDeltaTime * 3;

        _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, _timer);

        _wheelBackRightCollider.motorTorque = 0;
        _wheelBackLeftCollider.motorTorque = 0;
        _wheelFrontLeftCollider.motorTorque = 0;
        _wheelFrontRightCollider.motorTorque = 0;
    }

    private void HandleSteering()
    {
        _currentStreetAngle = _sensitiveAngle * _horizontal;
        _wheelFrontLeftCollider.steerAngle = _currentStreetAngle;
        _wheelFrontRightCollider.steerAngle = _currentStreetAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheels(_wheelBackLeftCollider, _wheelBackLeftTransform);
        UpdateSingleWheels(_wheelBackRightCollider, _wheelBackRightTransform);
        UpdateSingleWheels(_wheelBackLeftCollider, _wheelBackLeftTransform);
        UpdateSingleWheels(_wheelBackRightCollider, _wheelBackRightTransform);
    }

    private void UpdateSingleWheels(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;

        wheelCollider.GetWorldPose(out pos, out rot);

        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }

    private float HandleSpeed()
    {
        if (_rb.velocity.magnitude < 10)
            return _vertical * _speedForce * SPEED_MULTIPLIER;
        else
            return _vertical * _speedForce ;
    }

    private void SetClampSpeed() => _rb.velocity = Vector3.ClampMagnitude(_rb.velocity,_maxSpeed);

    private void SwitchSound()
    {
        if (_isBracking != _storeSwitchSound)
        {
            if (_switchSound)
            {
                _audio.Pause();
                _audio.clip = _passive;
                _audio.Play();

                _switchSound = false;
            }
            else
            {
                _audio.Pause();
                _audio.clip = _active;
                _audio.Play();

                _switchSound = true;
            }

            _storeSwitchSound = _isBracking;
        }
    }
}
