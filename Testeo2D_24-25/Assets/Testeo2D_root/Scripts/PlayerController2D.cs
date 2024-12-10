using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //Librería para que funcione el New Input System

public class PlayerController2D : MonoBehaviour
{

    
    //Referncias generales
    [SerializeField] Rigidbody2D playerRB; //Ref al rigidbody del player
    [SerializeField] PlayerInput playerInput; //Ref al gesto del input del jugador


    [Header("Movement Parameters")]
    private Vector2 moveInput; //Almacén del Input del player
    public float speed;


    [Header("Jump Parameters")]
    public float jumpForce;
    [SerializeField] bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        //Autoreferenciar componentes: Nombre de variable = GetComponent()
        playerRB = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

    }

    // Update is called once per frame
    void Update()
    {
        

    }


    private void FixedUpdate()
    {
        Movement();

    }

    void Movement()
    {
        playerRB.velocity = new Vector3(moveInput.x * speed, playerRB.velocity.y, 0);
    }



    #region Input Events
    //Para crear un evento:
    //Se define PUBLIC sin tipo de dato (VOID) y con una referencia al Input (Callback.context)
    public void HandleMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void HandleJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }

    }


    #endregion




}
