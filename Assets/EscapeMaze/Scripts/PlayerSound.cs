using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public float soundDelta = 9.587f;
    public float time = 0f;

    private PlayerController playerController;
    private AudioSource audioSource;
    private Vector3 moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        //足音のサウンドを追加
        audioSource = GetComponent<AudioSource>();
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //キャラクターの移動速度を取得
        moveVelocity = playerController.moveVelocity;
        //動き出したら足音を再生
        if (moveVelocity.magnitude > 0)
        {
            if (time == 0)
            {
                audioSource.Play();
            }
            time += Time.deltaTime;
            if (time >= soundDelta)
            {
                time = 0;
            }
        }
        else
        {
            audioSource.Stop();
            time = 0;
        }
    }
}
