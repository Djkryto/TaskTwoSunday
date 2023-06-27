using UnityEngine;
using System.Collections;

/// <summary>
/// Загрузчик сцен.
/// </summary>
public class LoaderScene : MonoBehaviour
{
    [SerializeField] private GameObject _image;
    private int _levelLoad;

    private void Start()
    {
        _levelLoad = FinderScript.FindGameScript.GetComponent<AdminScene>().LevelLoad;
        StartCoroutine(LoadAsync(_levelLoad));
    }

    private void Update() => _image.transform.Rotate(0, 0, -1);

    private IEnumerator LoadAsync(int nameLevel)
    {
        AsyncOperation operation = Application.LoadLevelAsync(nameLevel);

        while (operation.isDone)
        {
            yield return null;
        }
    }
}