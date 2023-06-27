using UnityEngine;

/// <summary>
/// Сущность работающая с данными.
/// </summary>
public class Store : MonoBehaviour
{
    [SerializeField] private DataSound _dataSound;
    [SerializeField] private DataCar _dataCar;
    [SerializeField] private DataCamera _dataCamera;

    [SerializeField] private float _audioVolum;

    public float AudioVolum { get => _audioVolum; set => _audioVolum = value; }

    /// <summary>
    /// Обновление значения переменной _audioVolum.
    /// </summary>
    /// <param name="volum"></param>
    public void UpdateAudioVolum(float volum) => _audioVolum = volum;

    public DataCamera DataCamera { get => _dataCamera; }
    public DataSound DataSound { get => _dataSound; }
    public DataCar DataCar { get => _dataCar; }
}