using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ������������� ������.
/// </summary>
public class AdminScene : MonoBehaviour
{
    public bool flag;
    private int _levelLoad;
    public int LevelLoad { get =>  _levelLoad;}

    /// <summary>
    /// �������� ������.
    /// </summary>
    /// <param name="name">Id �����</param>
    public void LoalLevel(int name)
    {
        _levelLoad = name;
        Application.LoadLevel(NameLevel.Load);
    }

    /// <summary>
    /// ��������� index ������� �����.
    /// </summary>
    /// <returns></returns>
    public static int GetIndexScene() => SceneManager.GetActiveScene().buildIndex;
    /// <summary>
    /// ����� �� ����������.
    /// </summary>
    public void Quit() => Application.Quit();
}