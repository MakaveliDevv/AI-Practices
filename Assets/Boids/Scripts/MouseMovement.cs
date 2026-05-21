using UnityEngine;
using UnityEngine.InputSystem;

public class MouseMovement : MonoBehaviour
{
    public static MouseMovement Instance;

    [SerializeField] private Camera cam;
    [SerializeField] private Plane raycastPlane = new(Vector3.forward, Vector3.zero); // Vector3.up = 3D | Vector3.forward 2D
    private Vector2 mouseDelta;

    private void Awake()
    {
        Instance = this;    
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 pos = GetMouseWorldPosition();

        // Debug.Log(pos);
    }

    void FixedUpdate()
    {  
        // mouseDelta = Mouse.current.delta.ReadValue();
        mouseDelta = Mouse.current.position.ReadValue();
    }

    // public Vector3 GetMouseWorldPosition(Camera cam, float distanceFromCamera)
    // {
    //     Vector3 mouseScreenPos = Input.mousePosition;
    //     mouseScreenPos.z = distanceFromCamera;

    //     Vector3 worldPos = cam.ScreenToWorldPoint(mouseScreenPos);

    //     return worldPos;
    // }

    public Vector3 GetMouseWorldPosition()
    {
        if(Mouse.current == null)
            return Vector3.zero;

        Ray ray = cam.ScreenPointToRay(mouseDelta);

        if (raycastPlane.Raycast(ray, out float d))
        {
            Vector3 hit = ray.GetPoint(d);
            return hit;
        }

        return Vector3.zero;
    }
}
