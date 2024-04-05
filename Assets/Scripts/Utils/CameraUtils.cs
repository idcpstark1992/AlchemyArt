using UnityEngine;

public static class CameraUtils
{
    public static Camera GameCamera { get; private set; }

    public static void AssignateCamera(Camera _camera)
    {
        GameCamera = _camera;
    }
    public static Vector3 ScreenToWorldPoint(Vector2 _InputVectorPosition)
    {
        return GameCamera.ScreenToWorldPoint(_InputVectorPosition);
    }
    public static Vector3 WordlPointToScreenPoint(Vector3 _InputPosition)
    {
        return GameCamera.WorldToScreenPoint(_InputPosition);
    }
    public static Ray GetRayPointFromCenter(Vector2 _screenCoordinates) => GameCamera.ScreenPointToRay(_screenCoordinates);
}
