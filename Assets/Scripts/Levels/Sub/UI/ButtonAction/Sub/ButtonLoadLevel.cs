using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonLoadLevel : ButtonBase
{
    [SerializeField] private EnumNameLevel NameLevel;
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);

        var gameScript = FinderScript.FindGameScript;

        gameScript.GetComponent<AdminScene>().LoalLevel((int)NameLevel);
    }
}
