using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Timers;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    private GameObject triggeringNpc;
    private bool triggering;
    private bool stoppedTriggering;

    void Update()
    {

        if (stoppedTriggering){
            DialogueManager.Instance.EndDialogue();
            stoppedTriggering=false;
        }


        if (DialogueManager.Instance.started && Input.GetButtonDown("NextSentence"))
        {
            DialogueManager.Instance.DisplayNextSentence();
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
            stoppedTriggering = true;
            Debug.Log("Not triggering with "+triggeringNpc);            
            triggering = false;
            triggeringNpc = null;
        }
    }

}
