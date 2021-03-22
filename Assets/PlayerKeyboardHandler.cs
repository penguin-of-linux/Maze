using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardHandler : MonoBehaviour
{
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        var w = Input.GetKey(KeyCode.W) ? 1 : 0;
        var s = Input.GetKey(KeyCode.S) ? -1 : 0;
        var a = Input.GetKey(KeyCode.A) ? 1 : 0;
        var d = Input.GetKey(KeyCode.D) ? -1 : 0;
        
        // transform.position = new Vector3(...)
        // или
        // rigidBodyComponent.velocity = new Vector2(...)
        
        var movementVector = new Vector2(w + s, a + d);
        if (movementVector.magnitude > 0.1f)
        {
            movementVector = GetDirection(90 + movementVector.GetAngleFromCathetuses()).normalized;
            var angle = new Vector3(0 ,0, movementVector.GetAngleFromCathetuses());
        
            rigidBodyComponent.velocity = movementVector * accelerate;
            transform.rotation = Quaternion.Euler(angle);
        }
    }
    private Vector2 GetDirection(float angle)
    {
        var x = 1 * Mathf.Cos(angle * Mathf.Deg2Rad);
        var y = 1 * Mathf.Sin(angle * Mathf.Deg2Rad);

        return new Vector2(x, y).normalized;
    }

    private float accelerate = 3;
    private Rigidbody2D rigidBodyComponent;
}
