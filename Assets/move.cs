using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 3f;
    private CharacterController controller;

    public Transform cameraTransform;

    void Start() {
        controller = GetComponent<CharacterController>();
    }

    void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 camForward = cameraTransform.forward;
        camForward.y = 0;
        camForward.Normalize();

        Vector3 camRight = cameraTransform.right;
        camRight.y = 0;
        camRight.Normalize();

        Vector3 move = camForward * vertical + camRight * horizontal;
        if(move.magnitude > 1f) move.Normalize();

        controller.SimpleMove(move*speed);

        if (move.magnitude > 0.1f) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), 0.1f);
        }
    }
}