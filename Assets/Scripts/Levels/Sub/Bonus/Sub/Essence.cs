using System;
using UnityEngine;

/// <summary>
/// Класс отвечающих за поведение эссенций.
/// </summary>
public class Essence : MonoBehaviour
{
    private Action _addEssention;
    private Action _soundEffect;
    public void Init(Action action,Action soundEffect)
    {
        _addEssention = action;
        _soundEffect = soundEffect;
    }

    public void Update() => transform.Rotate(0.5f,0.5f,0);

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.Player)
        {
            _addEssention();
            _soundEffect(); 
            Destroy(gameObject);
        }
    }
}
