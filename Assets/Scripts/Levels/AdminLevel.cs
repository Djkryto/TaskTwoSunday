using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// Класс инициализирующий уровень.
/// </summary>
public class AdminLevel : MonoBehaviour
{
    [SerializeField] private CameraController _camera;
    [SerializeField] private End _end;
    [SerializeField] private AdminAudio _adminAudio;
    [SerializeField] private AdminBonus _audioBonus;
    [SerializeField] private PanelControl _jostick;
    [SerializeField] private Car _car;

    private void Awake()
    {
        var store = FinderScript.FindGameScript.GetComponent<Store>();

        if(_jostick != null)
            _jostick.Init(_car.Controller);

        if (_camera != null)
            _camera.Init(_car.transform,store.DataCamera);

        if (_car != null)
            _car.Init(store.DataCar);

        if (_audioBonus != null)
            _audioBonus.Init(_adminAudio.SoundEffect);

        if (_end != null)
            _end.Init(_car, _audioBonus);

        _adminAudio.Init(store.DataSound,store.UpdateAudioVolum,store.AudioVolum);  
    }
}
