using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 5f;
    public Vector3 offset = new Vector3(0f, 0f, -10f);

    [Header("Map Boundaries")]
    public Transform topBoundary;
    public Transform bottomBoundary;
    public Transform leftBoundary;
    public Transform rightBoundary;

    private Camera cam;
    private float minX, maxX, minY, maxY;

    private void Awake()
    {
        cam = GetComponent<Camera>();

        // Lee automáticamente las posiciones de los boundaries
        if (topBoundary)    maxY = topBoundary.position.y;
        if (bottomBoundary) minY = bottomBoundary.position.y;
        if (leftBoundary)   minX = leftBoundary.position.x;
        if (rightBoundary)  maxX = rightBoundary.position.x;
    }

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        float halfHeight = cam.orthographicSize;
        float halfWidth  = halfHeight * cam.aspect;

        smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minX + halfWidth,  maxX - halfWidth);
        smoothedPosition.y = Mathf.Clamp(smoothedPosition.y, minY + halfHeight, maxY - halfHeight);

        transform.position = smoothedPosition;
    }
}