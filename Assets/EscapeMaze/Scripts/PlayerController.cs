using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpPower = 3f;

    

    public Vector3 moveVelocity;
    private CharacterController characterController;
    private Animator animator;
    

    float inputHorizontal;
    float inputVertical;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //キーの入力
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        //移動するスピードの計算
        moveVelocity.x = moveForward.x * moveSpeed;
        moveVelocity.z = moveForward.z * moveSpeed;

        characterController.Move(moveVelocity * Time.deltaTime);
        animator.SetFloat("MoveSpeed", new Vector3(moveVelocity.x, 0, moveVelocity.z).magnitude);

        //動き出したら処理を実行する
        if (moveForward != Vector3.zero)
        {
            this.transform.LookAt(this.transform.position + moveForward);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("ClearScene");
        }
    }

}
