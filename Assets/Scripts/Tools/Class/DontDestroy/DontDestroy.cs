using UnityEngine;
/// <summary>
/// Класс отвечающий за неразрушимость объекта.
/// </summary>
public class DontDestroy :MonoBehaviour
{
    private void Awake() => DontDestroyOnLoad(this);
}