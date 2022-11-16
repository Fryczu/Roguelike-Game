using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Health variables
    [SerializeField] float health, maxHealth = 5f;

    //Moving variables
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;

    //Shooting variables
    private Vector2 mousePosition;
    public Camera sceneCamera;

    //Refference to weapon
    public Weapon weapon;
    
    void Start() {
        health = maxHealth;
    }

    void Update()
    {
        //Processing Inputs
        ProcessInputs();
    }

    void FixedUpdate() 
    {
        //Physics Calculations
        Move();
    }
    
    //Movement functions
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        //Getting angle of the mouse position
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        
        //When we press left mouse button weapon will shoot bullet prefab
        if(Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            weapon.Reload();
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        Debug.Log("You have only " + health + " lives left!");

        if(health <= 0)
        {
            Debug.Log("YOU LOST!");
            Destroy(gameObject);
        }
    }
    
    void Move() 
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        //Rotating player to match mousePosition
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

}
