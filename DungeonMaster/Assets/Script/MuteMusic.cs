using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteMusic : MonoBehaviour
{
    public void MusicMute(bool muted)
    {
        
        if (muted == true)
        {
            AudioListener.pause = true;
        }
        else
        {
            
            AudioListener.pause = false;
        }
    }

    
}
