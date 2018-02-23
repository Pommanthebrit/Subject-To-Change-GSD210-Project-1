using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour {

	public GameController _gc;

	SpriteRenderer mySpriteRenderer;
	public Sprite HP4, HP3, HP2, HP1, HP0;

	void Start () {
		mySpriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	void Update () {
		switch (_gc.myHealth) {
		case 4:
			mySpriteRenderer.sprite = HP4;
			break;
		case 3:
			mySpriteRenderer.sprite = HP3;
			break;
		case 2:
			mySpriteRenderer.sprite = HP2;
			break;
		case 1:
			mySpriteRenderer.sprite = HP1;
			break;
		case 0:
			mySpriteRenderer.sprite = HP0;
			break;
		default:
			break;
		}
	}
}