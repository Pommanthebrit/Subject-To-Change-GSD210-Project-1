using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Author: David Geurts


public class BugController : EnemyController 
{
	[Header("Movement Settings")]

	[Tooltip("Impacts movement speed marginally")] 
	[SerializeField] private float _movementSpeed;

	[Tooltip("Impacts movment speed greatly")] 
	[SerializeField] private float _movementSpeedBooster;

	[Tooltip("Changes to this variable impact how fast a bug turns towards the next target location")]
	[SerializeField] private float _turnSpeed;

	[Tooltip("In seconds how long the bug will remain stationary for")]
	[SerializeField] private float _stillTime;



	[Header("Target Settings")]

	[Tooltip("The radius of the possible target location from the hive")]
	[SerializeField] private float _targetSelectionRange;

	[Tooltip("In seconds how long movement lasts for until stationary mode")]
	[SerializeField] private float _targetChangeTime;

	[Tooltip("In unity units how far from hive along y-axis should the targets be selected. Used to account for hive movement (should be fixed at later date)")]
	[SerializeField] private float _targetCorrection;

	[Header("Hive References")]
	public EnemyHiveController _hiveCtrl;
	public Transform _hiveTransform;

	private bool _still;
	private Vector3 _targetPosition;
	private Vector3 _vectorToTarget;
	private Quaternion _angleToTargetQuat;
	private Rigidbody2D _rb;

	void Start()
	{
		_rb = GetComponent<Rigidbody2D>();

		StartCoroutine("TargetChanging");

		_hiveCtrl = _hiveCtrl.GetComponent<EnemyHiveController>();
//		_rb.velocity = new Vector2(_rb.velocity.x + _hiveCtrl._rb.velocity.x, _rb.velocity.y + _hiveCtrl._rb.velocity.y);
	}

	void FixedUpdate()
	{
//		_rb.velocity = new Vector2(_rb.velocity.x -  _hiveCtrl._rb.velocity.x, _rb.velocity.y - _hiveCtrl._rb.velocity.y);
		if(!_still)
		{
			// Distance from target
			float xDis = transform.position.x - _targetPosition.x;
			float yDis = transform.position.y - _targetPosition.y;
			float totalDis = Mathf.Sqrt((xDis * xDis) + (yDis * yDis));

			// Moves bug forwards with force relative to the distance from target
			_rb.AddForce(transform.right * Mathf.Lerp(transform.position.x, totalDis, Time.deltaTime * _movementSpeed) * _movementSpeedBooster, ForceMode2D.Force);

			// Rotates bug to target rotation over time
			transform.rotation = Quaternion.Slerp(this.transform.rotation, _angleToTargetQuat, Time.deltaTime * _turnSpeed);
		}
		else
		{
			_rb.velocity = new Vector2(_hiveCtrl._rb.velocity.x, _hiveCtrl._rb.velocity.y);
		}

//		_rb.velocity = new Vector2(_rb.velocity.x + _hiveCtrl._rb.velocity.x, _rb.velocity.y + _hiveCtrl._rb.velocity.y);
	}

	IEnumerator TargetChanging()
	{
		while(true)
		{
			// Stops all movement
			_rb.velocity = new Vector2(_hiveCtrl._rb.velocity.x, _hiveCtrl._rb.velocity.y);
			_still = true;
			yield return new WaitForSeconds(_stillTime);

			// Enables movement
			_still = false;

			// Selects new target within range
			float newX = Random.Range(_hiveTransform.position.x - _targetSelectionRange, _hiveTransform.position.x + _targetSelectionRange);
			float newY = Random.Range(_hiveTransform.position.y - _targetSelectionRange, _hiveTransform.position.y + _targetSelectionRange) + _targetCorrection;
			_targetPosition = new Vector3(newX, newY, 0);

			// Gets the target rotation
			_vectorToTarget = _targetPosition - this.transform.position;
			float _angleToTargetDeg = Mathf.Atan2(_vectorToTarget.y, _vectorToTarget.x) * Mathf.Rad2Deg;
			_angleToTargetQuat = Quaternion.AngleAxis(_angleToTargetDeg, Vector3.forward);

			yield return new WaitForSeconds(_targetChangeTime);
		}
	}

	protected override void Die ()
	{
		_hiveCtrl.BugAmount--;
		base.Die ();
	}


}
