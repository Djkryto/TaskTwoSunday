using UnityEngine;
/// <summary>
/// Класс отвечающих за положения экрана.
/// </summary>
public class PositonSceen : MonoBehaviour
{
    public NamePositionScreen _screen;

    private void Awake()
    {
        switch(_screen)
        {
            case NamePositionScreen.Free :
                Screen.orientation = ScreenOrientation.Unknown;
                break;

            case NamePositionScreen.Landscape:
                Screen.orientation = ScreenOrientation.LandscapeLeft;
                break;

            case NamePositionScreen.Portrain:
                Screen.orientation = ScreenOrientation.Portrait;
                break;
        }
    }
}
