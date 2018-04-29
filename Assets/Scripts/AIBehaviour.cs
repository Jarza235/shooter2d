using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviour : HumanBehaviour {

	private float inputX;
	private float inputY;
	private float inputXTimer = 3f;
	private float inputYTimer = 3f;

	private float shootingTimer = 0f;

	void GetInput()
	{
		inputXTimer -= Time.deltaTime;
		inputYTimer -= Time.deltaTime;

		if(inputXTimer <= 0f) {
			float randomNumber = Random.Range(0f, 1f);
			if(randomNumber < 0.33f) {
				inputX = -1f;
			}
			else if(randomNumber < 0.66f) {
				inputX = 0f;
			}
			else {
				inputX = 1f;
			}
			inputXTimer = Random.Range(2f, 8f);
		}

		if(inputYTimer <= 0f) {
			float randomNumber = Random.Range(0f, 1f);
			if(randomNumber < 0.33f) {
				inputY = -1f;
			}
			else if(randomNumber < 0.66f) {
				inputY = 0f;
			}
			else {
				inputY = 1f;
			}
			inputYTimer = Random.Range(2f, 8f);
		}

		input.x = inputX;
		input.y = inputY;
	}

	void Update() {
		GetInput();
		CalculateDirection();
		Rotate();
		Move();
		ToggleShooting();
	}

	void ToggleShooting() {
		shootingTimer += Time.deltaTime;

		if(shootingTimer > 5f && !theGun.isFiring) {
			theGun.ToggleFire(true);
			//Debug.Log("AI shooting");
		}
		else if(shootingTimer > 10f && theGun.isFiring) {
			theGun.ToggleFire(false);
			shootingTimer = 0f;
			SwitchWeapon();
		}
	}

	protected override void SwitchWeapon() {
		if(selectedWeapon == 0) {
			selectedWeapon = 1;
		}
		else if(selectedWeapon == 1) {
			selectedWeapon = 0;
		}
		SelectWeapon();
	}

	protected override void Die() {
		Destroy(gameObject);
	}
    
}
