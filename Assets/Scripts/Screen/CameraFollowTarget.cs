using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    public GameObject target;
    public float PixelsPerUnit = 16;

    void Update()
    {
        transform.position = PixelPerfectClamp(target.transform.position, PixelsPerUnit) / Time.deltaTime / 2;
    }

    private Vector3 PixelPerfectClamp(Vector3 moveVector, float pixelsPerUnit)
    {
        Vector3 vectorInPixels = new Vector3(Mathf.CeilToInt(moveVector.x * pixelsPerUnit), Mathf.CeilToInt(moveVector.y * pixelsPerUnit), Mathf.CeilToInt(moveVector.z * pixelsPerUnit));
        return vectorInPixels / pixelsPerUnit;
    }
}
