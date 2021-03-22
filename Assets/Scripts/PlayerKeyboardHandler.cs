using System;
using UnityEngine;

public class PlayerKeyboardHandler : MonoBehaviour
{
    private float acceleration = 3;
    private Rigidbody2D rigidBodyComponent;

    private void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var v = Input.GetAxis("Vertical"); // Возвращают от -1 до 1
        var h = Input.GetAxis("Horizontal");
        var movementVector = new Vector2(h, v);

        // Другой вариант. Но тогда нет промежуточных поворотов и не работает джойстик.
        // var w = Input.GetKey(KeyCode.W) ? 1 : 0;
        // var s = Input.GetKey(KeyCode.S) ? -1 : 0;
        // var a = Input.GetKey(KeyCode.A) ? 1 : 0;
        // var d = Input.GetKey(KeyCode.D) ? -1 : 0;
        // var movementVector = new Vector2(-(a + d), w + s);

        if (movementVector.magnitude > Mathf.Epsilon)
        {
            rigidBodyComponent.velocity = movementVector * acceleration;
            
            var angle = new Vector3(0 ,0, movementVector.GetAngle());
            transform.rotation = Quaternion.Euler(angle);
        }
        
        // Другой вариант, без Rigidbody2D.
        // Указываются абсолютные координаты, а не смещение.
        // Перемещение происходит мгновенно, в отличие от скорости.
        // В Rigidbody2D выберите Body Type Kinematic, чтобы не действовала гравитация.
        // transform.position = new Vector3(...)
    }
}
