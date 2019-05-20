using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(playerMovement))]
public class playerInput : MonoBehaviour
{

    playerMovement player;
    BoxCollider2D myBodyCollider;

    void Start()
    {
        myBodyCollider = GetComponent<BoxCollider2D>();
        player = GetComponent<playerMovement>();
    }

    void Update()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float controlThrowJump = CrossPlatformInputManager.GetAxis("Jump");
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            //Debug.Log("Player is Touching Ground");
            FindObjectOfType<AudioManager>().Play("PlayerJump");
            //Debug.Log("Jump Is Pressed");
            //FindObjectOfType<AudioManager>().Play("PlayerJump");
            //if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        }
        //FindObjectOfType<AudioManager>().Play("PlayerJump");
        Vector2 directionalInput = new Vector2(controlThrow, controlThrowJump);
        player.SetDirectionalInput(directionalInput);

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {   
            //FindObjectOfType<AudioManager>().Play("PlayerJump");
            player.OnJumpInputDown();
        }
        if (CrossPlatformInputManager.GetButtonUp("Jump"))
        {
            player.OnJumpInputUp();
        }
    }
}
