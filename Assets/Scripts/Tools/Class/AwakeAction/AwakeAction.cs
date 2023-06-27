using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����� ���������� �� �������� ��� �������� �������.
/// </summary>
public class AwakeAction : MonoBehaviour
{
    [SerializeField] private List<GameObject> _gameObjects;

    private void Awake()
    {
        for(int i = 0; i < _gameObjects.Count; i++)
            _gameObjects[i].SetActive(!_gameObjects[i].activeSelf);
    }
}
