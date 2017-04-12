using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour {

	public Image BlackCover;
	public Image BloodBlur;
	public Text HPText;

	void Start(){
		BlackCover.color = Color.black;
		DOTween.To (() => BlackCover.color, (x) => BlackCover.color = x, new Color (0, 0, 0, 0), 1f);
	}

	Tweener tweenAnimation;

	public void PlayHitAnimation(){
		if (tweenAnimation != null)
			tweenAnimation.Kill ();

		BloodBlur.color = Color.white;
		tweenAnimation = DOTween.To (() => BloodBlur.color, (x) => BloodBlur.color = x, new Color (1, 1, 1, 0), 0.5f);
	}

	public void PlayDiedAnimation(){
		BloodBlur.color = Color.white;
		DOTween.To (() => BlackCover.color, (x) => BlackCover.color = x, new Color (0, 0, 0, 1), 1f).
		SetDelay (3).OnComplete (() => {
			DOTween.To (() => BloodBlur.color, (x) => BloodBlur.color = x, new Color (1, 1, 1, 0), 0.5f).SetDelay (3).OnComplete (() => {
				SceneManager.LoadScene ("Main");
			});
		});
	}

	public void SetHP(int hp){
		HPText.text = "HP : " + hp;
	}
}
