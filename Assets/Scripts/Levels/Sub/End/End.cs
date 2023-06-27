using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс отвечающих за запуска окончания уровня.
/// </summary>
public class End : MonoBehaviour
{
    [SerializeField] private GameObject _endUI;

    [SerializeField] private List<GameObject> _stars;

    private Car _car;
    private AdminBonus _adminBonus;

    public void Init(Car car,AdminBonus adminBonus)
    {
        _car = car;
        _adminBonus = adminBonus;
    }

    public void Finish()
    {
        _car.Stop();
        _adminBonus.StarInit(_stars);
        _endUI.SetActive(true);
    }
}