using Cinemachine;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private CinemachineVirtualCameraBase vCamera;

    private void Start()
    {
        vCamera = GetComponent<CinemachineVirtualCameraBase>();
    }

    private void Update()
    {
        var target = GameObject.FindWithTag("Player");

        if (target != null)
        {
            vCamera.Follow = target.transform;
            vCamera.LookAt = target.transform;
        }
    }
}
