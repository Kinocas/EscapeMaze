using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1Controller : MonoBehaviour
{
    private GameObject mainCamera;
    private GameObject playerObject;
    private Vector3 playerPos;

    public float rotateSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.gameObject;
        playerObject = GameObject.Find("unitychan");
        playerPos = playerObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += playerObject.transform.position - playerPos;
        playerPos = playerObject.transform.position;
        rotateCamera();
    }

    private void rotateCamera()
    {
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, -Input.GetAxis("Mouse Y") * rotateSpeed, 0);
        mainCamera.transform.RotateAround(playerObject.transform.position, Vector3.up, angle.x);
        mainCamera.transform.RotateAround(playerObject.transform.position, transform.right, angle.y);
    }
}
