/*
 * Author(s): Niklaas Cotta
 * Last updated: 04/22/22
 * Controller for Player 1 game object.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public CharacterController characterController;

    public float speed = 5.0f;

    private Vector3 direction;
    private float horizontal;
    private float vertical;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            characterController.Move(direction * speed * Time.deltaTime);
        }
    }
}