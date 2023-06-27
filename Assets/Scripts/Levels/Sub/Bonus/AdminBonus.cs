using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс отвечающий за бонус.
/// </summary>
public class AdminBonus : MonoBehaviour
{
    [SerializeField] private List<Essence> _essences = new List<Essence>();

    private int _countEssention;

    public void Init(Action sound)
    {
        for (int i = 0; i < _essences.Count; i++)
            _essences[i].Init(AddEssetion,sound);
    }

    private void Awake()
    {
        //for(int i = 0; i < _essences.Count; i++)
        //    _essences[i].Init(AddEssetion);
    }

    /// <summary>
    /// Увеличение количество эсенции.
    /// </summary>
    public void AddEssetion() => _countEssention++;

    /// <summary>
    /// Расчёт прогресса уровняю
    /// </summary>
    public void StarInit(List<GameObject> stars)
    {
        if(_countEssention == _essences.Count)
        {
            for(int i = 0; i < stars.Count; i++)
                stars[i].SetActive(true);
        }
        else if (_countEssention >= 9)
        {
            for (int i = 0; i < stars.Count - 1; i++)
                stars[i].SetActive(true);
        }
        else if(_countEssention >= 6)
        {
            for (int i = 0; i < stars.Count - 2; i++)
                stars[i].SetActive(true);
        }
        else
        {
            for (int i = 0; i < stars.Count; i++)
                stars[i].SetActive(false);
        }
    }
}