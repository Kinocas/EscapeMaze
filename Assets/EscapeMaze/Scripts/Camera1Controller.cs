using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1Controller : MonoBehaviour
{
    private GameObject mainCamera;
    private GameObject playerObject;
    private Vector3 playerPos;
    private Vector3 playerBasePos;
    private Vector3 cameraPos;
    private Vector3 cameraForward;
    float dis;

    //　カメラのキャラクターからの相対値を指定
    private Vector3 basePos = new Vector3(0f, 1.5f, 0);

    public float rotateSpeed = 5.0f;

    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.gameObject;
        playerObject = GameObject.Find("unitychan");

        playerPos = playerObject.transform.position;
        playerBasePos = playerPos + basePos;
        cameraPos = transform.position;
        dis = Vector3.Distance(playerBasePos, cameraPos);
    }

    // Update is called once per frame
    void Update()
    { 
        cameraForward = transform.forward;
        transform.position += ((playerObject.transform.position - playerPos)
            - cameraForward * (dis- Vector3.Distance(playerBasePos, cameraPos))) ;
        
        playerPos = playerObject.transform.position;
        playerBasePos = playerPos + basePos;
        cameraPos = transform.position;

        rotateCamera();

        //　キャラクターとカメラの間に障害物があったら障害物の位置にカメラを移動させる
        if (Physics.Linecast(playerBasePos, transform.position, out hit))
        {
            transform.position = hit.point;
        }

    }

    private void rotateCamera()
    {
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, -Input.GetAxis("Mouse Y") * rotateSpeed, 0);
        mainCamera.transform.RotateAround((playerObject.transform.position + basePos), Vector3.up, angle.x);
        mainCamera.transform.RotateAround((playerObject.transform.position + basePos), transform.right, angle.y);
    }
}
