using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpPower = 3f;

    float vx = 0;
    float vz = 0;

    private Vector3 _moveVelocity;
    private CharacterController _characterController;
    private Animator animator;

    float inputHorizontal;
    float inputVertical;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        _moveVelocity.x = moveForward.x * moveSpeed;
        _moveVelocity.z = moveForward.z * moveSpeed;

        _characterController.Move(_moveVelocity * Time.deltaTime);
        animator.SetFloat("MoveSpeed", new Vector3(_moveVelocity.x, 0, _moveVelocity.z).magnitude);
        if (moveForward != Vector3.zero)
        {
            this.transform.LookAt(this.transform.position +moveForward);
        }
    }
}
