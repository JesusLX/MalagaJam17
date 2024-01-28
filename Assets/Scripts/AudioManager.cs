using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private FMOD.Studio.EventInstance snapshot;
    private FMOD.Studio.EventInstance musicInstance1;
    private FMOD.Studio.EventInstance musicInstance2;
    private FMOD.Studio.EventInstance musicInstance3;
    bool music3isplaying = false;



    private void Start()
    {
        musicInstance1 = FMODUnity.RuntimeManager.CreateInstance("event:/MUSIC/Menu_Theme");
        musicInstance2 = FMODUnity.RuntimeManager.CreateInstance("event:/MUSIC/Drawing_Theme");
        musicInstance3 = FMODUnity.RuntimeManager.CreateInstance("event:/MUSIC/Fight_Theme");
        snapshot = FMODUnity.RuntimeManager.CreateInstance("snapshot:/FINALHIT");
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    //FMOD.Studio.EventInstance snapshot;
    public void PlayOneShot(string soundEvent)
    {

        FMODUnity.RuntimeManager.PlayOneShot(soundEvent);
    }

    public void PlayMusic()
    {
        if (music3isplaying == true)
        {
            musicInstance3.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            music3isplaying = false;
        }
        musicInstance1.start();
    }

    public void PlayMusic2()
    {
        musicInstance1.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        musicInstance2.start();
    }

    public void PlayMusic3()
    {
        musicInstance2.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        musicInstance3.start();
        music3isplaying = true;
    }


    public void ActivateSnapshot()
    {
        snapshot.start();
        Debug.Log("esto está activándose");
    }

    public void DisableSnapshot()
    {
        snapshot.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        snapshot.release();
        Debug.Log("esto funciona");
    }

    public void Music2Parameter(int value)
    {
        musicInstance2.setParameterByName("DrawingThemeParameter", value);
    }

    public void Music3Parameter(int value)
    {
        musicInstance3.setParameterByName("FightThemeParameter", value);
    }



}






