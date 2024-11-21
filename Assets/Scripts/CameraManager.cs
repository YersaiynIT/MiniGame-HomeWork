using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _followCamera;

    private Transform _cameraTarget;

    public void Initialize(Transform cameraTarget)
    {
        _cameraTarget = cameraTarget;

        SetCameraTarget();
    }

    public void SetCameraTarget()
    {
        _followCamera.Follow = _cameraTarget.transform;
        _followCamera.LookAt = _cameraTarget.transform;
    }
}
