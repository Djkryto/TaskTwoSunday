using UnityEngine;

public class TriggerEnd : MonoBehaviour
{
    [SerializeField] private End _end;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == Tags.Player)
            _end.Finish();
    }
}