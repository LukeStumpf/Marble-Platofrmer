using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10.0f;
    [SerializeField]
    private float jumpForce = 20.0f;
    [SerializeField]
    private GameObject restartPosition;
    [SerializeField]
    private bool resetLevel = false;
    [SerializeField]
    private float trampolineForce = 500f;

    private float moveX;
    private float moveY;

    private Rigidbody rbd;

    private Vector3 moveDirection;

    private bool canJump = false;

    private void Start()
    {
        rbd = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        moveDirection = new Vector3(moveX, 0.0f, moveY);

        rbd.AddForce(moveDirection * moveSpeed);

        if (Input.GetButtonDown("Jump") && canJump == true)
        {
            rbd.AddForce(Vector3.up * jumpForce);
            canJump = false;
        }

    }
	private void OnCollisionEnter (Collision collision)
	{
		if(collision.gameObject.tag == "Floor")
		{
			canJump = true;
		}
	}
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Floor")
        {
            canJump = true;
        }

        if (collider.tag == "Reset")
        {
            if (resetLevel == false)
            {
                transform.position = restartPosition.transform.position;
                rbd.Sleep();
            }
            else
            {
                SceneManager.LoadScene(1);
            }
        }

        if (collider.tag == "Trampoline")
        {
            rbd.AddForce(Vector3.up * trampolineForce);
        }
         
    }

	private void OnTriggerStay (Collider collider)
	{
		if (collider.tag == "Checkpoint" && canJump == true)
		{
			restartPosition = collider.gameObject;
		} 
	}
}
