using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AudioClipSet", menuName = "ScriptableObjects/Audio Clip Set")]
public class AudioClipSet : ScriptableObject
{
    public List<AudioClip> clipList;
    int lastIndex, newIndex;

    public AudioClip GetRandom()
    {
        newIndex = Random.Range(0, clipList.Count);
        //Only check for repeats if there are more than two sounds. 
        //One sound, there's no point in checking.
        //Two sounds, it'll just flip-flop between them.
        //Three, they'll be a bit chaotic, so no repeats are necessary.
        if (clipList.Count > 2)
        {
            //Check if new selected sound clip is the same as the last one.
            while(newIndex == lastIndex)
            {
                newIndex = Random.Range(0, clipList.Count);
            }
            lastIndex = newIndex;
        }
        return clipList[newIndex];
    }
}
