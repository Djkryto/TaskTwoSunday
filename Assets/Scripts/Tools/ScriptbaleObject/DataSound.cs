using UnityEngine;
/// <summary>
/// Данные кнопок.
/// </summary>
[CreateAssetMenu(fileName = "DataSound", menuName = "Scriptable Object/Sound/Data", order = 50)]
public class DataSound :ScriptableObject
{
    [SerializeField] private AudioClip _button;
    [SerializeField] private AudioClip _music;
    [SerializeField] private AudioClip _effect;
    [SerializeField] private AudioClip _musicMenu;

    public AudioClip Button { get => _button; }
    public AudioClip Music { get => _music;}
    public AudioClip MenuMusic { get => _musicMenu; }
    public AudioClip Effect { get => _effect;}
}