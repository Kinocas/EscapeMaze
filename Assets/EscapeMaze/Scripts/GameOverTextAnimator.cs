using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameOverTextAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var defaultPosition = transform.localPosition;
        transform.localPosition = new Vector3(0, 500f);
        transform.DOLocalMove(defaultPosition, 3f)
            .OnComplete(() =>
            {
                transform.DOPunchScale(new Vector3(1.1f, 1.1f, 1.1f), 1f);
                transform.DOShakePosition(1.5f, 100f);
            });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
