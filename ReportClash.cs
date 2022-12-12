using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportClash : MonoBehaviour
{
    public Queue<string> clashed_notes = new Queue<string>();

    SoundClash sound_clashes;
    public string current_note;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        foreach (Transform child in transform)
        {
            //clashed_notes.Enqueue("starts");
            //child is your child transform
            //Debug.Log(child.gameObject);
            sound_clashes = child.gameObject.GetComponent<SoundClash>();
            if (sound_clashes != null) { 
                //Debug.Log("currently clashing" + sound_clashe_note.GetComponent<SoundClash>().note_name);

            string note = sound_clashes.note_name;
            double soundon = sound_clashes.soundon;
                clashed_notes.Enqueue("#");
                //{
                //    Debug.Log("currently clashing" + name);
                if (soundon == 1)
                {

                    //Debug.Log("currently clashing" + note);
                    current_note = note;
                    clashed_notes.Enqueue(note);


                }
                //else {
                //    current_note = "#";

                //}


            }
            else
            {
                current_note = "#";

            }
        }
    }
}