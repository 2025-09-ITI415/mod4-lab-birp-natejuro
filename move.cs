using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 3f;
    private CharacterController controller;

    void Start() {
        controller = GetComponent<CharacterController>();
    }

    void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0, vertical);
        if(move.magnitude > 1f) move.Normalize();

        controller.SimpleMove(move*speed);
    }
}