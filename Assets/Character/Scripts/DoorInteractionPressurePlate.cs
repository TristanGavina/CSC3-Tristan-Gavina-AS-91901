using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractionPressurePlate : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObject;
    [SerializeField] private AudioSource doorOpenAudioSource = null;
    [SerializeField] private float openDelay = 0;
    [Space(10)]
    [SerializeField] private AudioSource doorCloseAudioSource = null;
    [SerializeField] private float closeDelay = 0.8f;
    private IDoor door;

    private void Awake()
    {
        door = doorGameObject.GetComponent<IDoor>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Objectweight>() != null)
        {
            // Object entered collider!
            door.OpenDoor();
            doorOpenAudioSource.PlayDelayed(openDelay);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.GetComponent<Objectweight>() != null)
        {
            //Object still on top of collider
            door.CloseDoor();
            doorCloseAudioSource.PlayDelayed(closeDelay);
        }
    }
}
