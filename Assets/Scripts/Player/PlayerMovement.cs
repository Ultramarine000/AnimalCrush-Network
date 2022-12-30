using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 inputMovement;
    float moveSpeed = 10f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        Vector3 movement = new Vector3(inputMovement.x, 0, inputMovement.y) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
    private void OnMove(InputValue value)
    {
        inputMovement = value.Get<Vector2>();
        //Debug.Log("Moving");
    }
    private void OnJumpA()
    {
        transform.Translate(transform.up);
        //Debug.Log("Jumping");
    }
    private void OnCrunchB()
    {
        transform.Translate(-transform.up);
        //Debug.Log("Jumping");
    }
}
