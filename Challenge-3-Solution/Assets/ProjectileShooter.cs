using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;

    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //  2. Your player can fire already by pressing the left mouse button.
        //  Add the ability to press the right mouse button to fire a projectile
        //  (similar to the one fired at the player by the enemy)
        if (Input.GetMouseButtonDown(1))
        {
            // If I press the right mouse key, I want to instantiate a prefab,
            // add force to its Rigidbody in a forward direction from the camera
          
            // Instantiate our projectile at that point. To start, we'll just use
            // the existing fireball
            GameObject fireball = Instantiate(projectile, _camera.transform.position + _camera.transform.forward, Quaternion.identity);
            fireball.GetComponent<Rigidbody>().AddForce(_camera.transform.forward * 10, ForceMode.Impulse);
        }
    }
}
