using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrisbeeController : MonoBehaviour
{
    public int playerOneScore;
    public int playerTwoScore;
    public bool shouldScorePoint = true;
    Vector3 identityPos;
    Quaternion identityRot;
    public bool hasMadePoints;
    public bool hasBeenTouched;

    public GamePlayer catcherPlayer;
    public GamePlayer pitcherPlayer;
    // Use this for initialization
    void Start()
    {
        identityPos = transform.position;
        identityRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            transform.rotation = identityRot;
            transform.position = identityPos; shouldScorePoint = !shouldScorePoint; 
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            shouldScorePoint = !shouldScorePoint;
        }

    }

    //ON GRABBED
    //afferrare frisbee fa guadagnare un punto al tiratore
    //MAKE PLAYER GRABBED THE PICHER IF NOT 
    //ADD ZERO POINTS
    
        //ONUNGRABBED
    //shouldScorePoint
    //

  

    
    //Uscendo dalla zona di gioco
    private void OnCollisionExit(Collision collision)
    {   //Se la collisione in uscita non è la Zona "PlayerSpace" non mi interessa, così come se non si è in fase di gioco
        if (collision.gameObject.layer != 10 || !shouldScorePoint) return;
        //Se il tiro è fuori dalla zona "PlayerSpace" allora il punto va al catcher, se lo stesso non ha toccato il frisbee
        if (!hasMadePoints || hasBeenTouched) { catcherPlayer.score++; return; }
        //Se il tiro è fuori alla zona 1 punto in più (oltre a quelli dati dai points) vanno al catcher se riesce a ricevere
        if (hasMadePoints) { catcherPlayer.score++; return; }
        //Se il tiro è fuori dalla zona il punto va a chi tira se il catcher tenta e fallisce nel recupero
        if (!hasMadePoints || hasBeenTouched) { pitcherPlayer.score++; return; }

    }
    //Triggerando sui ScorePoints
    void OnTriggerEnter(Collider collider)
    {   
        if (collider.transform.parent != catcherPlayer.transform || collider.gameObject.layer != 11 || !shouldScorePoint || !collider.GetComponent<ScorePoints>().isActive) return;
        //Debug.Log(new String("Colliso con {0}! Punteggio per il {1} = {2}", collider.transform.name, collider.transform.parent.name, playerOneScore));

        StartCoroutine(ScorePoints());
        hasMadePoints = true;
        catcherPlayer.score++;


        GameObject collidedGO = collider.gameObject;
    }



    private IEnumerator ScorePoints()
    {   
        float i = 0;
        while (i < 1)
        {
            shouldScorePoint = true;
            i = i + Time.deltaTime;
            yield return null;
        }
        shouldScorePoint = false;


    }
}
