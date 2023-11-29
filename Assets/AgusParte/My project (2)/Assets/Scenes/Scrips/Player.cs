using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private PlayerDash _playerDash;
    private Animator _animator;
    private AudioSource _audioSource; // Corregido a AudioSource

    public int _vida = 100;

    public AudioClip pasoSound;

    [Header("Movement")]
    [SerializeField] private float _speed = 4f;
    private float direction;
    public float Direction => direction;

    [Header("Jump")]
    [SerializeField] private int _nJumps = 1;
    private int _nJumpsValue;
    [SerializeField] private float _JumpForce = 4f;
    [SerializeField] private Transform _checkGround;
    [SerializeField] private float _raycastLength;
    [SerializeField] private LayerMask _groundLayer;
    private bool _isGrounded;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerDash = GetComponent<PlayerDash>();
        _animator = GetComponent<Animator>();
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.playOnAwake = false;
        _audioSource.clip = pasoSound;
    }

    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");

        if (!_playerDash.IsDashing)
        {
            Jump();
        }

        if (_isGrounded && Mathf.Abs(direction) > 0.1f)
        {
            PlayFootstepSound();
        }

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

        _animator.SetFloat("Speed", Mathf.Abs(direction));
    }

    private void Move()
    {
        _rb.velocity = new Vector2(direction * _speed, _rb.velocity.y);
        if (direction != 0 && _isGrounded && !_audioSource.isPlaying) // Corregido a _audioSource
        {
            _audioSource.PlayOneShot(pasoSound); // Corregido a _audioSource
        }
        else if (direction == 0 && _isGrounded && _audioSource.isPlaying)
        {
            _audioSource.Stop(); // Detener la reproducción si el personaje deja de caminar
        }
        if (direction < 0)
        {
            transform.localScale = new Vector2(-11, transform.localScale.y);
        }
        else if (direction > 0)
        {
            transform.localScale = new Vector2(11, transform.localScale.y);
        }
    }

    private void Jump()
    {
        _isGrounded = Physics2D.Raycast(_checkGround.position, Vector2.down, _raycastLength, _groundLayer);

        if (Input.GetButtonDown("Jump") && _nJumpsValue > 0)
        {
            _rb.velocity = Vector2.up * _JumpForce;
            _nJumpsValue--;
        }

        _animator.SetBool("IsGrounded", _isGrounded);
    }

    public void PlayerDamaged(int danio)
    {
        _vida -= danio;
        if (_vida <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void PlayFootstepSound()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(pasoSound);
        }
    }
}
