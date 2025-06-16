using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shakeshake : MonoBehaviour
{
    public CameraShake shake;

    public void doit()
    {
        shake.Shake( 0.25f, 0.1f );
    }
}
