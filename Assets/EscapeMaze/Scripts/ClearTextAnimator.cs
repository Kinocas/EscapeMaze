using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ClearTextAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(new Vector3(2f, 2f, 2f), 3f)
            .OnComplete(() =>
            {
                transform.DOPunchScale(new Vector3(1.1f, 1.1f, 1.1f), 1f);
            });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
