using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Aiming : MonoBehaviour
{
    public CharacterController controller;
    public Transform cameraTarget;
    public GameObject reticle;
    public CinemachineVirtualCamera aimCamera;
    public CinemachineFreeLook thirdCamera;
    public float speed;
    public float sensitivity;
    public bool aiming;
    public float h, v;
    public float rotationVelocity;
    public float turnTime = 0.05f;
    public float TopClamp = 70.0f;
    public float BottomClamp = -30.0f;
    public float yaw, pitch;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            aiming = !aiming;
        }

        if (!aiming)
        {
            reticle.SetActive(false);
            thirdCamera.enabled = true;
            aimCamera.enabled = false;
        }
        else
        {
            reticle.SetActive(true);
            thirdCamera.enabled = false;
            aimCamera.enabled = true;
            CameraRotation();
        }
    }
    private void CameraRotation()
    {
        yaw += Input.GetAxis("Mouse X");
        pitch += -1 * Input.GetAxis("Mouse Y");

        // Cinemachine will follow this target
        cameraTarget.transform.rotation = Quaternion.Euler(pitch, yaw, 10.0f);

        transform.eulerAngles = cameraTarget.eulerAngles;
    }
}
