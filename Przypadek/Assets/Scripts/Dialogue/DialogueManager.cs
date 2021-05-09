using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    protected DialogueManager(){}

    public bool started;

    public Text nameText;
    public Text dialogueText;

    public Animator animator;
    
    private Queue<string> sentences=new Queue<string>();

    void Start()
    {
       sentences = new Queue<string>(); 
    }

    public void StartDialogue(Dialogue dialogue){
        animator.SetBool("IsOpen",true);
        started=true;
        Debug.Log("Starting conversation with "+ dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

   public void DisplayNextSentence(){

       StartCoroutine(takeTime());
       if (sentences.Count == 0){
           EndDialogue();
           return;
       }
       string sentence = sentences.Dequeue();
       dialogueText.text = sentence;
       Debug.Log(sentence);
       
   }

   public void EndDialogue(){
       Debug.Log("End of conversation");
       animator.SetBool("IsOpen",false);
       started = false;
   } 

   IEnumerator takeTime(){
       yield return new WaitForSeconds(5);
   }

}
