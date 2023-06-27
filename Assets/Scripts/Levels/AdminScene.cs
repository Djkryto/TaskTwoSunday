using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Администратор уровня.
/// </summary>
public class AdminScene : MonoBehaviour
{
    public bool flag;
    private int _levelLoad;
    public int LevelLoad { get =>  _levelLoad;}

    /// <summary>
    /// Загрузка уровня.
    /// </summary>
    /// <param name="name">Id сцены</param>
    public void LoalLevel(int name)
    {
        _levelLoad = name;
        Application.LoadLevel(NameLevel.Load);
    }

    /// <summary>
    /// Получение index текущей сцены.
    /// </summary>
    /// <returns></returns>
    public static int GetIndexScene() => SceneManager.GetActiveScene().buildIndex;
    /// <summary>
    /// Выход из приложения.
    /// </summary>
    public void Quit() => Application.Quit();
}