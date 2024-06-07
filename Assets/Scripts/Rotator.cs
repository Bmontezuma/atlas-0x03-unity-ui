using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    void Update()
    {
        // Rotate the object around its x-axis at 45 degrees per second
        transform.Rotate(45 * Time.deltaTime, 0, 0);
    }
}
