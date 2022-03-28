using UnityEngine;

public class PointerView : MonoBehaviour
{
    public bool CanInstance = true;

    private void OnTriggerEnter(Collider other)
    {
        CanInstance = false;
        Debug.Log("Enter");
    }
    private void OnTriggerStay(Collider other)
    {
        CanInstance = false;
        Debug.Log("Stay");
    }
    private void OnTriggerExit(Collider other)
    {
        CanInstance = true;
        Debug.Log("Exit");

    }
}
