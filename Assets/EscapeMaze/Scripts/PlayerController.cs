using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3;
    public float jumpPower = 3;

    float vx = 0;
    float vz = 0;

    private Vector3 _moveVelocity;
    private CharacterController _characterController;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveVelocity.x = Input.GetAxis("Horizontal") * moveSpeed;
        _moveVelocity.z = Input.GetAxis("Vertical") * moveSpeed;
        this.transform.LookAt(this.transform.position+new Vector3(_moveVelocity.x,0,_moveVelocity.z));
        _characterController.Move(_moveVelocity * Time.deltaTime);
        animator.SetFloat("MoveSpeed", new Vector3(_moveVelocity.x, 0, _moveVelocity.z).magnitude);
    }
}
