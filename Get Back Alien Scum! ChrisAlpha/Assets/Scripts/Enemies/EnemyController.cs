using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	[Header("References")]
	public GameController _gc;
	public GameObject _player;
	public Player _playerCtrl;

	[Header("Enemy Settings")]
	[SerializeField] private int _scoreWorth;
	[SerializeField] protected float _health;

	[Header("Other Enemy Effects")]
	public GameObject deathEffect;

	//Other
	private bool _scoreGiven;

	void Update()
	{
		// Damages player if outside of world space
		Vector2 minMoveLimit = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		if(transform.position.y < minMoveLimit.y) 
		{
			DamagePlayer ();
		}
	}

	//Destroys enemy if shot by player bullet, increases score
	void OnCollisionEnter2D(Collision2D collider) 
	{
		//Debug.Log (gameObject + " hit by " + collider.gameObject.name);
		if (_scoreGiven == false) 
		{
			if (collider.gameObject.tag == "Bullet")
			{
				print("collision");
				DamageSelf();
			}
		}
	}

	// Enemy takes damage
	void DamageSelf()
	{
		_health--;

		//print (_health);
		if(_health <= 0)
		{
			Die();
		}
	}

	// Assign score to player and instantiate death effect
	protected virtual void Die()
	{
		_gc.myScore += _scoreWorth;
		_scoreGiven = true; // Uses bool to ensure score is not given twice (for each player bullet)

		Debug.Log ("Score: " + _gc.myScore);

		Instantiate(deathEffect, gameObject.transform.position, gameObject.transform.rotation);
		Destroy(gameObject);
	}

	// Damages player
	void DamagePlayer()
	{
		_gc.myHealth += -1;

		_playerCtrl.TakeDamage ();

		Destroy (gameObject);
	}
}