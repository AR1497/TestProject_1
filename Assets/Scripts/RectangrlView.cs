using UnityEngine;

public class RectangrlView : MonoBehaviour
{
    private PointerView _pointerView;

    private float LastClickTime = 0.0f;

    private void OnEnable()
    {
        _pointerView = FindObjectOfType<PointerView>().GetComponent<PointerView>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        float timeFromLastClick = Time.time - LastClickTime;
        LastClickTime = Time.time;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (timeFromLastClick < 0.2)
            {
                Destroy(gameObject);
            }
        }
    }
}
