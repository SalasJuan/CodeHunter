using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //VARIBLES Y CONDICIONALES

    private Rigidbody2D _rb;
    private PlayerDash _playerDash;

    //MOVIMIENTO DEL PLAYER

    [Header("Movement")]
    // el "SerializeField" nos permite ver las cosas desde el inspector en unity y poder modificarlo siendo una variable privado. sin tambien tener que
    // Modificar el codigo a cada rato y iniciarlo luego cada vez que se tenga que iniciar y demas
    [SerializeField] private float _speed = 4f;
    private float direction;
    // aca en el Direction = direction lo que hace es que tenga los mismos valores que direction que esta en privado y poder utilizarlo en player dash.
    public float Direction => direction;

    // PARTES PARA HACER O MODIFICAR EL SALTO DEL PERSONAJE
    [Header("Jump")]

    //aca vamos a guardar el numero de saltos que querramos hacer
    [SerializeField] private int _nJumps = 1;

    //En esta variable guardamos la cantidad de saltos
    private int _nJumpsValue;


    [SerializeField] private float _JumpForce = 4f;

    // "CheckGround" va a dectectar si estamos en el suelo o no.
    [SerializeField] private Transform _checkGround;
    [SerializeField] private float _raycastLength;
    [SerializeField] private LayerMask _groundLayer;

    //esta variable nos va a decir si es verdadero si estamos en el suelo que sea verdadero y sino que sea falso
    private bool _isGrounded;



    // el awake es cuando queres inicializar un objeto podes crear la variable awake
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        _playerDash = GetComponent<PlayerDash>();
    }
   
    
     void Update()
    {
        // Este no va a dar 3 valores si precionamos derecha nos da 1 si vamos izquierda -1 y si no apretamos 0
        direction = Input.GetAxisRaw("Horizontal");
        // aca nos indica que cuando IsDashing es "false" indica o nos deja saltar 
        if (!_playerDash.IsDashing)
        {
            Jump();

        }
        // aca es cada vez que "_isGrounded sea verdadero este mismo se resetee el contador de saltos.
        if (_isGrounded)
        {
            _nJumpsValue = _nJumps;
        }


        // aca es cada vez que toque el suelo se resetee nuestro contador de saltos extra y que no se quede en 0 para siempre
        if (_isGrounded)
        {
            _nJumpsValue = _nJumps;
        }
    }

    private void FixedUpdate()
    {
        if (!_playerDash.IsDashing)
        {
            Move();
        }
    }
    private void Move()
    {
        _rb.velocity = new Vector2(direction * _speed, _rb.velocity.y);
    }

    private void Jump() 
    {
        //"checkGround.position" sera nuestra posicion determinada que vaya hacia abajo con una longitud determinada ("raycast") y verifica si toca un ground layer

        _isGrounded = Physics2D.Raycast(_checkGround.position, Vector2.down, _raycastLength, _groundLayer);
        

        if (Input.GetButtonDown("Jump") && _nJumpsValue > 0)
        {
            _rb.velocity = Vector2.up * _JumpForce;
            _nJumpsValue--;
        }

    }

}
