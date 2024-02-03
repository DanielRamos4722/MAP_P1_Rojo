using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PantallaInicio : MonoBehaviour
{
    [SerializeField]
    private float speed;
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;       
    }
}
