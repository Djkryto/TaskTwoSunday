using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    private Transform _target;
    private float _transitionSpeed;
    private float _rotationSpeed;

    public void Init(Transform target, DataCamera data)
    {
        _target = target;
        _transitionSpeed = data.TransitionSpeed;
        _rotationSpeed = data.RotationSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleTranslation();
        HandleRotation();
    }

    private void HandleTranslation()
    {
        var targetPosition = _target.TransformPoint(_offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, _transitionSpeed * Time.deltaTime);
    }

    private void HandleRotation()
    {
        var direction = _target.position - transform.position;
        var rotation =Quaternion.LookRotation(direction,Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
    }
}
