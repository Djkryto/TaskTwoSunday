using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Сущность отвечающая за звук в игре.
/// </summary>
public class AdminAudio : MonoBehaviour
{

    [SerializeField] private Action<float> _updateAudioVolum;
    [SerializeField] private Slider _volum;
    [SerializeField] private List<ButtonBase> _buttons;

    [SerializeField] private AudioSource _sourceButton;
    [SerializeField] private AudioSource _sourceMusic;
    [SerializeField] private AudioSource _sourceEffect;
    [SerializeField] private AudioSource _sourceCar;

    public void Init(DataSound data,Action<float> UpdateAudioVolum,float volum)
    {
        _sourceButton.clip = data.Button;
        _updateAudioVolum = UpdateAudioVolum;

        if (_sourceEffect != null)
            _sourceEffect.clip = data.Effect;

        if(AdminScene.GetIndexScene() != NameLevel.Menu)
            _sourceMusic.clip = data.Music;
        else
            _sourceMusic.clip = data.MenuMusic;

        for (int i = 0; i < _buttons.Count; i++)
            _buttons[i].Init(_sourceButton.Play);

        InitVolum(volum);
        _volum.onValueChanged.AddListener((float value) => UpdateVolum());
        _sourceMusic.Play();
    }
    /// <summary>
    /// Обновление значение при  изменении ползунка.
    /// </summary>
    public void UpdateVolum()
    {
        float volum = _volum.value;

        _updateAudioVolum(volum);

        if (_sourceButton != null)
            _sourceButton.volume = volum;

        if (_sourceCar != null)
            _sourceCar.volume = volum;

        if (_sourceMusic != null)
            _sourceMusic.volume = volum;

        if(_sourceEffect != null)
            _sourceEffect.volume = volum;
    }

    private void InitVolum(float volum)
    {
        _volum.value = volum;

        if (_sourceButton != null)
            _sourceButton.volume = volum;

        if (_sourceCar != null)
            _sourceCar.volume = volum;

        if (_sourceMusic != null)
            _sourceMusic.volume = volum;

        if (_sourceEffect != null)
            _sourceEffect.volume = volum;
    }
    public void SoundButton() => _sourceButton.Play();
    public void SoundEffect() => _sourceEffect.Play();
    public void SoundMusic() => _sourceMusic.Play();
}
