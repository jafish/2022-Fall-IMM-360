using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {
	private int _health;

	void Start() {
		_health = 5;
	}

	public void Hurt(int damage) {
		_health -= damage;
		Debug.Log("Health: " + _health);

		// 3. When the player’s health gets to zero, restart the scene
		// (hint: you’ll need to look up the SceneManager class in the Unity reference)
		if (_health <= 0) //why <= ??
        {
			SceneManager.LoadScene("Scene");
        }
	}
}
