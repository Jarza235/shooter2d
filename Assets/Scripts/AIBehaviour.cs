using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviour : HumanBehaviour {

	private float inputX;
	private float inputY;
	private float inputXTimer = 3f;
	private float inputYTimer = 3f;

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
	}

    public void DealDamage(float damageAmount)
    {
        
        if (armor > 0)
        {
            if (damageAmount > armor)
            {
                health -= (damageAmount - armor);
                armor = 0;
            }

            else
            {
                armor -= damageAmount;
            }
        }

        else if (health > 0)
        {
            health -= damageAmount;
        }

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Dead");
    }
}
