using UnityEngine;

public class PointerView : MonoBehaviour
{
    public bool CanInstance = true;

    private void OnTriggerEnter(Collider other)
    {
        CanInstance = false;
    }
    private void OnTriggerStay(Collider other)
    {
        CanInstance = false;
    }
    private void OnTriggerExit(Collider other)
    {
        CanInstance = true;
    }
}
