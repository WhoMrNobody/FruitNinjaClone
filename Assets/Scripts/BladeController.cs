using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeController : MonoBehaviour
{   
    public float minVelocity = 0.1f;
    new Rigidbody2D _rigidbody;

    private Vector3 _lastMousePos;
    private Vector3 _mouseVelocity;
    private Collider2D _collider2D;

    private void Awake() {
        
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<CircleCollider2D>();

    }

    void FixedUpdate()
    {
        _collider2D.enabled = IsMouseMove();
        SetBladeToMouse();
    }

    void SetBladeToMouse(){

        var mousePos = Input.mousePosition;
        mousePos.z=10;
        _rigidbody.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private bool IsMouseMove(){

        Vector3 currentPos = transform.position;
        float traveled = (_lastMousePos - currentPos).magnitude;

        _lastMousePos = currentPos;

        if(traveled > minVelocity){

            return true;

        }else{

            return false;
        }
    }
}
