using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public GameObject _player, deathEffect;
	public GameController _gc;

	[SerializeField] private int _scoreWorth;
	[SerializeField] private float _health;

	private bool _scoreGiven;

	//Destroys enemy if shot by player bullet, increases score
	void OnCollisionEnter2D(Collision2D collider) 
	{
		//Debug.Log (gameObject + " hit by " + collider.gameObject.name);
		if (_scoreGiven == false) 
		{
			if (collider.gameObject.tag == "Bullet") 
			{
				Damage();
			}
		}
	}

	void Damage()
	{
		_health--;
		if(_health <= 0)
		{
			Die();
		}
	}

	//Assign score to player and instantiate death effect
	void Die()
	{
		_gc.myScore += _scoreWorth;
		_scoreGiven = true; //Uses bool to ensure score is not given twice (for each player bullet)
		Debug.Log ("Score " + _gc.myScore);
		Instantiate (deathEffect, gameObject.transform.position, gameObject.transform.rotation);
		Destroy (gameObject);
	}
}