using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private GameObject triggeringNpc;
    private bool triggering;

    void Update()
    {
        if (triggering){

        }

        if (Input.GetButtonDown("Interact") && triggeringNpc){
            DialogueManager.Instance.StartDialogue(dialogue);
        }

    }

    void OnTriggerEnter2D(Collider2D other){
        
        if (other.tag == "Player"){
            triggering = true;
            triggeringNpc = other.gameObject;
            Debug.Log("Triggered by "+triggeringNpc);            
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.tag == "Player"){
            Debug.Log("Not triggering with "+triggeringNpc);            
            triggering = false;
            triggeringNpc = null;
        }
    }

}
