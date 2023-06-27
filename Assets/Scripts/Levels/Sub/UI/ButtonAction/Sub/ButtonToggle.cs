using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ButtonToggle : ButtonBase
{
    [SerializeField] private List<GameObject> _objects;

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);

        for(int i = 0; i < _objects.Count; i++)
            _objects[i].SetActive(!_objects[i].activeSelf);
    }
}
