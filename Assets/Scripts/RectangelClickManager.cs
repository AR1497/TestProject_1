using UnityEngine;

public class RectangelClickManager : MonoBehaviour
{
    public GameObject _spawnObject;
    public Camera _camera;
    public Transform pointer;

    private PointerView pointerView;

    private float _spawnOjectZ = 5f;

    public LineRenderer line;

    private void Start()
    {
        pointerView = pointer.gameObject.GetComponent<PointerView>();
        Material material = this.GetComponent<MeshRenderer>().sharedMaterial;

        line.startWidth = 0.2f;
        line.endWidth = 0.2f;
        line.positionCount = 0;
    }

    void Update()
    {
        InstanceObject();
        CreateLine();
        OnMouseOver();
    }

    private void CreateLine()
    {
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftShift))
        {
            Vector2 currentPoint = GetWarldCoordinate(Input.mousePosition);
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, currentPoint);
        }
        else
        {
            line.forceRenderingOff = false;
        }
    }

    private void InstanceObject()
    {
        Vector3 cursorPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        var newv = new Vector3(cursorPos.x, cursorPos.y, _spawnOjectZ);

        pointer.position = newv;

        var ray = new Ray(pointer.position, pointer.forward * 100f);
        Debug.DrawRay(pointer.position, pointer.forward * 100f, Color.yellow);
        RaycastHit hit;

        Physics.Raycast(ray, out hit, 15f);

        if (Input.GetKeyDown(KeyCode.Mouse0) && pointerView.CanInstance)
        {
            _spawnObject.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value, 1);
            if (hit.collider == null)
            {
                var gameObject = Instantiate(_spawnObject, newv, Quaternion.identity);
            }

        }
    }

    private Vector2 GetWarldCoordinate(Vector3 mousePosition)
    {
        Vector2 mousePoint = new Vector3(mousePosition.x, mousePosition.y, 1);
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = transform.TransformPoint(mousePos);
        }
    }
}