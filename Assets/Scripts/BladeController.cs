using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeController : MonoBehaviour
{
    new Rigidbody2D rigidbody;

    private void Awake() {
        
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos.z=10;
        rigidbody.position = Camera.main.ScreenToWorldPoint(mousePos);

    }
}
