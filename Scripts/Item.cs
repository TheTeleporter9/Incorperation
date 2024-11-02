using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{   
    public Tile tile;

    private int movementRotationCounter = 0;
    private Vector3[] movementRotations = {
        new Vector3(0, 0.05f, 0),   // Up (0)
        new Vector3(0, -0.05f, 0),  // Down (1)
        new Vector3(0.05f, 0, 0),   // Right (2)
        new Vector3(-0.05f, 0, 0)   // Left (3)
    };

    private void Start() {
        this.transform.position += new Vector3(0, 1, 0);
    }

    private void Update() {
        safety(); // Ensure the counter is valid
        movement(); // Move the item continuously
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Tile")) {
            tile.getTileRotation(); // Update tile rotation
            changeMovementDir(); // Change direction based on tile's rotation
        }
    }

    private void changeMovementDir() {
        movementRotationCounter = tile.rotationCounter; // Set direction based on tile's rotation
        RotateItem(); // Rotate the GameObject visually
    }

    private void RotateItem() {
        switch (movementRotationCounter) {
            case 0: // Up
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 1: // Down
                transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            case 2: // Right
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            case 3: // Left
                transform.rotation = Quaternion.Euler(0, 0, 270);
                break;
        }
    }

    private void safety() {
        if (movementRotationCounter < 0 || movementRotationCounter >= movementRotations.Length) {
            movementRotationCounter = 0; // Reset if out of bounds
        }
    }

    private void movement() {
        this.transform.position += movementRotations[movementRotationCounter];
    }
}
