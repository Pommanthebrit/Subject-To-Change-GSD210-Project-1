using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: David Geurts



[RequireComponent(typeof(Rigidbody2D))]
public class EnemyHiveController : EnemyController {

	public Rigidbody2D _rb;
	[SerializeField] private int _bugAmount;

	[SerializeField] private float _movementSpeed;
	[SerializeField] private GameObject _bugPrefab;

	public int BugAmount
	{
		get{return _bugAmount;}

		set
		{
			_bugAmount = value;
			if(_bugAmount <= 0)
			{
				Die();
			}
		}
	}


	void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();
	}

	void Start()
	{
		for(int index = 0; index < _bugAmount; index++)
		{
			BugController newBug = Instantiate(_bugPrefab, this.transform).GetComponent<BugController>();
			newBug._hiveCtrl = this;
			newBug._hiveTransform = this.transform;
			newBug._gc = this._gc;
			newBug._player = this._player;
			newBug._playerCtrl = this._playerCtrl;
		}
	}

	void FixedUpdate()
	{
		_rb.velocity = new Vector2(0, -_movementSpeed);
	}



	void Update()
	{
		
	}
}
