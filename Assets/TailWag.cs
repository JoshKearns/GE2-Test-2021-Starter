using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailWag : MonoBehaviour
{
    private float _amplitudeX = 10.0f;
    private float _omegaX = 1.0f;
    private float _index;
    
    // Update is called once per frame
    void Update()
    {
        _index += Time.deltaTime * 10;
        var x = _amplitudeX * Mathf.Cos (_omegaX * _index);
        
        transform.localRotation = Quaternion.Euler(20, x, 0);
    }
}
