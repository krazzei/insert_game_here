using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
[RequireComponent(typeof(PowerMeter))]
[RequireComponent(typeof(ArrowRotation))]
public class Whale : MonoBehaviour 
{
    [SerializeField]
    private float MinPower;
    [SerializeField]
    private float MaxPower;
	[SerializeField]
	private Sprite _roll;

    private float _maxMinPowerDiff;
    private ArrowRotation _hitDirectionScript;
    private PowerMeter _powerMeterScript;
    private Rigidbody2D _rigidbody;
    private Vector3 _direction;
    private float _power;
	private SpriteRenderer _spriteRenderer;
	private Animator _animator;

	private void Awake()
	{
        _hitDirectionScript = GetComponent<ArrowRotation>();
        _hitDirectionScript.OnDirectionPicked += OnDirectionPicked;

        _powerMeterScript = GetComponent<PowerMeter>();
        _powerMeterScript.OnPowerPicked += OnPowerPicked;

        _maxMinPowerDiff = MaxPower - MinPower;
        _rigidbody = GetComponent<Rigidbody2D>();
		_rigidbody.gravityScale = 0;
		_rigidbody.drag = 0.15f;

		_spriteRenderer = GetComponent<SpriteRenderer>();

		_animator = GetComponent<Animator>();
	}

	private void Start()
	{
        GetDirection();
	}

    private void GetDirection()
    {
        _hitDirectionScript.Begin();
    }

    private void OnDirectionPicked(Vector3 direction)
    {
        _direction = direction;
        _powerMeterScript.Begin();
    }

    private void OnPowerPicked(float power)
    {
        _power = power;
        _hitDirectionScript.Hide();
        _powerMeterScript.Hide();
        Launch(_direction * _power * _maxMinPowerDiff);
		CameraFollow.instance.Reset(transform.position);
		CameraFollow.instance.target = GetComponent<Transform>();
		_animator.SetBool("IsWorry", false);
		_spriteRenderer.sprite = _roll;
		LevelManager.instance.SwingPosidon();
    }

	public void Launch(Vector2 direction)
	{
        Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + new Vector3(direction.x, direction.y, gameObject.transform.position.z), Color.red, 10000f);
		_rigidbody.AddForce(direction, ForceMode2D.Impulse);
	}

    public void Push(Vector2 direction)
    {
        _rigidbody.AddForce(direction, ForceMode2D.Force);
    }

    public Vector2 Location()
    {
        return this.transform.position;
    }
}
