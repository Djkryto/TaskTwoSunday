using UnityEngine;
/// <summary>
/// Панель управления.
/// </summary>
public class PanelControl : MonoBehaviour
{
    [SerializeField] private GameObject _touchMarker;
    [SerializeField] private Vector3 _targetVector;

    private CarController _car;

    private const float RANGE = 55;

    public void Init(CarController car) => _car = car;

    private void Awake() => _touchMarker.transform.position = transform.position;

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Vector3 touchPosition = Input.GetTouch(0).position;

            _targetVector = touchPosition - transform.position;

            _touchMarker.transform.position = 
                new Vector3(
                        Mathf.Clamp(touchPosition.x, transform.position.x - RANGE, RANGE + transform.position.x), 
                        Mathf.Clamp(touchPosition.y,transform.position.y - RANGE, RANGE + transform.position.y)
                    );

            _car.SetDirect(_targetVector);
        }
        else
        {
            _touchMarker.transform.position = transform.position;
            _car.SetDirect(Vector3.zero);
        }
    }
}