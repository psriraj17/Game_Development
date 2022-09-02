using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CinemachineFreeLook thirdCam;
    public CharacterController controller;
    public Transform camera;
    public Animator animator;
    public float jumpHeight;
    public bool grounded;
    public float speed;
    public bool jumping;
    public float height;
    public float horizontal;
    public float vertical;
    public float rotationVelocity;
    public float turnTime = 0.05f;
    [SerializeField] float groundedRadius;
    [SerializeField] LayerMask groundLayers;
    // Start is called before the first frame update
    void OnValidate()
    {
        camera = Camera.main.transform;
        controller = GetComponent<CharacterController>();
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        grounded = Physics.CheckSphere(spherePosition, groundedRadius, groundLayers, QueryTriggerInteraction.Ignore);

        animator.SetBool("Grounded", grounded);
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        animator.SetFloat("WalkX", horizontal);
        animator.SetFloat("WalkY", vertical);
     
        if (Input.GetButtonUp("Jump") && grounded)
        {
            height = jumpHeight;
            animator.SetTrigger("Jump");
        }
        height -= 10f * Time.deltaTime;
        if (grounded)
            if (height < 0)
                height = -2;

    }

    private void FixedUpdate()
    {
        var jumpDirection = new Vector3(0, height, 0);
        var cameraForward = Vector3.Scale(camera.forward, new Vector3(1, 0, 1)).normalized;
        var direction = vertical * cameraForward + horizontal * camera.right;
        controller.Move(direction * speed * Time.deltaTime + jumpDirection * Time.deltaTime);

        if (direction.magnitude > 0 && thirdCam.enabled)
        {
            var degrees = Mathf.Atan2(direction.z, direction.x);
            var angle = 90- degrees * Mathf.Rad2Deg;
            var rotationAngle = Smooth(angle);
            transform.eulerAngles = Vector3.up * (rotationAngle);

            //transform.rotation = Quaternion.LookRotation(new Vector3(horizontal, 0, vertical));
        }
    }

    private float Smooth(float angle)
    {
        return Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref rotationVelocity, turnTime);
    }
}
