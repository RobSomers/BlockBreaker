using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager LevelManager;

	void OnTriggerEnter2D (Collider2D trigger)
    {
        LevelManager = GameObject.FindObjectOfType<LevelManager>();
        LevelManager.LoadLevel("Lose");
    }

}
