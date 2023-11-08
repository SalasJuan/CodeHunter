using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Player _player;
    private float _baseGravity;
    private float _nivelZoomInicial;
    public CinemachineVirtualCamera _camera;
    public float _nivelZoomMaximo;

    [Header("Dash")]
    // Este script va a controlar el tiempo que va a durar nuestro dash
    [SerializeField] private float _dashingTime = 0.2f;

    // Esta es la fuerza del dash
    [SerializeField] private float _dashForce = 20f;

    // Aca le vamos a colocar un cult down al dash de cuanto tiempo va a tardar para volver a utilizarlo
    [SerializeField] private float _timeCanDash = 1f;

    // aca nos va a indicar si el player se esta desplazando o no
    private bool _isDashing;

    // y aca que nos indique si podemos dashear o no
    private bool _canDash = true;

    public bool IsDashing => _isDashing;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
        _nivelZoomInicial = _camera.m_Lens.OrthographicSize;
        _baseGravity = _rb.gravityScale;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());
        }        

        if(_isDashing)
        {
            StartCoroutine(CameraZoom());
        }
    }
    private IEnumerator Dash()
    {
        if (_player.Direction != 0 && _canDash)
        {
            _isDashing = true;
            _canDash = false;
            // lo ponemos en cero para que nuestro personaje al dashear no se vaya para abajo y que sea todo recto
            _rb.gravityScale = 0f;
            _rb.velocity = new Vector2(_player.Direction * _dashForce, 0f);
            // Esto nos permite esperar el tiempo en segundos que le indiquemos
            yield return new WaitForSeconds(_dashingTime);
            // despues de que termine tenemos que indicar que no esta dasheando
            _isDashing = false;
            _rb.gravityScale = _baseGravity;
            yield return new WaitForSeconds(_timeCanDash);
            _canDash = true;
        }
    }
    private IEnumerator CameraZoom()
    {
        float tiempo = MathF.Abs(_dashingTime / (_nivelZoomMaximo - _nivelZoomInicial / 0.10f));

        for(float i = _nivelZoomInicial; i <= _nivelZoomMaximo; i += 0.10f)
        {
            _camera.m_Lens.OrthographicSize = i;
            yield return new WaitForSeconds(tiempo);
        }
        for(float i = _nivelZoomMaximo; i >= _nivelZoomInicial; i -= 0.10f)
        {
            _camera.m_Lens.OrthographicSize = i;
            yield return new WaitForSeconds(tiempo);
        }        
    }
}