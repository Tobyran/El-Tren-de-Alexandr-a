using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMechanics : MonoBehaviour
{
    //Mechanics area
    [SerializeField] private CapsuleCollider charCollider;
    private bool isInteracting, analizable, pickable, pushable, talkable;

    //Mechanics scripts
    private Analize analize;

    //Input area
    private ThirdPersonActionsAssets playerActionsAssets;
    private InputAction interact;

    private void Awake()
    {
        charCollider = GetComponentInParent<CapsuleCollider>();
        playerActionsAssets = new ThirdPersonActionsAssets();

        analize = gameObject.AddComponent<Analize>();
    }

    private void OnEnable()
    {
        interact = playerActionsAssets.Player.Interact;
        playerActionsAssets.Player.Enable();
    }

    private void OnDisable()
    {
        playerActionsAssets.Player.Disable();
    }

    private void Update()
    {
        if (playerActionsAssets.Player.Interact.triggered && isInteracting)
        {
            if (analizable)
            {
                analize.GoToAnalize();

            }
            else if (pickable)
            {

            }
            else if (pushable)
            {

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Analizable"))
        {
            isInteracting = true;
            analizable = true;
        }
        else if (other.gameObject.CompareTag("Pickable"))
        {
            isInteracting = true;
            pickable = true;
        }
        else if (other.gameObject.CompareTag("Pushable"))
        {
            isInteracting = true;
            pushable = true;
        }
        else if (other.gameObject.CompareTag("Talkable"))
        {
            isInteracting = true;
            talkable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isInteracting = false;
        analizable = false;
        pickable = false;
        pushable = false;
        talkable = false;
    }
}