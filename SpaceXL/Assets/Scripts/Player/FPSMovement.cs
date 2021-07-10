using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    #region Variables
    private float baseFOV;
    private float sprintFOVModifier = 1.25f;
    private float movementCounter;
    private float idleCounter;

    public float speed = 6.0f;
    public float speedModifiler = 25.0f;
    public float jumpForce = 1f;
    public float gravity = -9.81f;

    private CharacterController chController;
    private Vector3 weaponOrigin;
    private Vector3 targetWeaponBobPosition;

    public Transform weapon;
    public Camera Cam;
    public Camera WeaponCam;
    public Vector3 playerVelocity;
    #endregion

    #region Callbacks
    private void Start()
    {
        weaponOrigin = weapon.localPosition;
        baseFOV = Cam.fieldOfView;
        chController = GetComponent<CharacterController>();
        if (chController == null)
            Debug.Log("CharacterController is NULL");
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");

        bool isGrounded = chController.isGrounded;
        bool isJumping = Input.GetKey(KeyCode.Space);
        bool isSprinting = Input.GetKey(KeyCode.LeftShift) && deltaZ > 0 && !isJumping;

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        float currentSpeed = speed;
        if (isSprinting)
            currentSpeed *= speedModifiler;

        movement = transform.TransformDirection(movement);
        chController.Move(movement * currentSpeed * Time.deltaTime);

        if (isJumping && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpForce * -3.0f * gravity);
        }
        playerVelocity.y += gravity * Time.deltaTime;

        if (isSprinting)
        {
            Cam.fieldOfView = Mathf.Lerp(Cam.fieldOfView, baseFOV * sprintFOVModifier, Time.deltaTime * 8f);
            WeaponCam.fieldOfView = Mathf.Lerp(Cam.fieldOfView, baseFOV * sprintFOVModifier, Time.deltaTime * 8f);
        }

        else
        {
            Cam.fieldOfView = Mathf.Lerp(Cam.fieldOfView, baseFOV, Time.deltaTime * 8f);
            WeaponCam.fieldOfView = Mathf.Lerp(Cam.fieldOfView, baseFOV, Time.deltaTime * 8f);
        }
        chController.Move(playerVelocity * Time.deltaTime);

        #region Sway
        if (deltaX == 0 && deltaZ == 0)
        {
            HeadBob(idleCounter, 0.02f, 0.02f);
            idleCounter += Time.deltaTime;
            weapon.localPosition = Vector3.Lerp(weapon.localPosition, targetWeaponBobPosition, Time.deltaTime * 1.2f);
        }
        else if (!isSprinting)
        {
            HeadBob(movementCounter, 0.04f, 0.04f);
            movementCounter += Time.deltaTime * 3.3f;
            weapon.localPosition = Vector3.Lerp(weapon.localPosition, targetWeaponBobPosition, Time.deltaTime * 5f);
        }
        else 
        {
            HeadBob(movementCounter, 0.15f, 0.10f);
            movementCounter += Time.deltaTime * 15f;
            weapon.localPosition = Vector3.Lerp(weapon.localPosition, targetWeaponBobPosition, Time.deltaTime * 7f);
        }
        #endregion
    }
    #endregion

    #region Private Methods
    void HeadBob(float t, float p_x_intensity, float p_y_intensity)
    {
        targetWeaponBobPosition = weaponOrigin + new Vector3(Mathf.Cos(t) * p_x_intensity, Mathf.Sin(t*2) * p_y_intensity, 0);
    }
    #endregion
}
