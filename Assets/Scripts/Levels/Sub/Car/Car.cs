using UnityEngine;

/// <summary>
/// Класс администратор машины.
/// </summary>
public class Car : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private CarController _controller;

    public CarController Controller { get  =>  _controller; }

    public void Init(DataCar data)
    {
        _rb.mass = data.Mass;
        _controller.Init(data, _rb);
    }

    public void Stop() => _controller.StopCar();
}
