using System;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Базовая кнопка дейсвтия.
/// </summary>
public class ButtonBase : MonoBehaviour,IPointerDownHandler
{
    protected Action _playSound;
    public virtual void Init(Action sound) => _playSound = sound;
    public virtual void OnPointerDown(PointerEventData eventData) => _playSound();
}
