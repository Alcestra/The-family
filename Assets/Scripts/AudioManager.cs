using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioManager Instance;

    public AudioSource [] AMBX;
    public AudioSource [] SFX;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    private void Update()
    {
        PubSounds();
        BrewerySounds();
        StopSound();
    }


    void PubSounds()
    {

    }


    void BrewerySounds()
    {

    }

    void StopSound()
    {

    }

}
