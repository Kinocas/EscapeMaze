using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundLight : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, -12) * Time.deltaTime);
    }
}
