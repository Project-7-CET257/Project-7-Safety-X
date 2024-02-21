using UnityEngine;
using Random = UnityEngine.Random;

public class engineAudio : MonoBehaviour
{
    public AudioClip lowAccelClip;
    public AudioClip lowDecelClip;
    public AudioClip highAccelClip;
    public AudioClip highDecelClip;

    [Header("Tubro Sound")]
    public AudioClip Turbo;
    [Range(0,2)]public float turboVolume;

    [Header("Down-shift Sound")]
    public AudioClip downShift;
    [Range(0, 1)] public float downShiftVolume;

    [Header("Pitch")]
    [Range(0.5f,1)]public float Pitch = 1f;
    [Range(.5f,3)]public float lowPitchMin = 1f;
    [Range(2,7)]public float lowPitchMax = 6f;
    [Range(0,1)]public float highPitchMultiplier = 0.25f;
    
    private float accFade = 0;
    private float acceleration;
    private float maxRolloffDistance = 500;
    
    private AudioSource m_LowAccel;
    private AudioSource m_LowDecel;
    private AudioSource m_HighAccel;
    private AudioSource m_HighDecel;
    private AudioSource m_Turbo;
    private AudioSource m_downShift;

    private bool m_StartedSound;

    [HideInInspector]public float totalPower;
    [HideInInspector]public float engineRPM;
    [HideInInspector]public float maxRPM;
    [HideInInspector]public bool engineLerp;

    private GameObject audioObject;

    private void StartSound()
    {
        audioObject = new GameObject();
        audioObject.transform.parent = gameObject.transform;
        audioObject.transform.name = "audio";
        audioObject.transform.position = new Vector3(0,1,0);
        audioObject.transform.localPosition = new Vector3(0,1,0);
        audioObject.transform.localScale = new Vector3(1,1,1);

        m_HighAccel = SetUpEngineAudioSource(highAccelClip);
        m_LowAccel = SetUpEngineAudioSource(lowAccelClip);
        m_LowDecel = SetUpEngineAudioSource(lowDecelClip);
        m_HighDecel = SetUpEngineAudioSource(highDecelClip);

        if(Turbo != null)
            m_Turbo = SetUpEngineAudioSource(Turbo);

        if(downShift != null)
            m_downShift = setupDownShift(downShift);
       
        m_StartedSound = true;
    }
   
    private void StopSound()
    {
        foreach (var source in GetComponents<AudioSource>())
        {
            Destroy(source);
        }

        m_StartedSound = false;
    }

    private void Update()
    {
        float camDist = (Camera.main.transform.position - transform.position).sqrMagnitude;
                    
        accFade = Mathf.Lerp(accFade,Mathf.Abs( acceleration ), 20 * Time.deltaTime);

        if (m_StartedSound && camDist > maxRolloffDistance * maxRolloffDistance)
            StopSound();

        if (!m_StartedSound && camDist < maxRolloffDistance * maxRolloffDistance)
            StartSound();

        if (m_StartedSound)
        {            
            acceleration = (totalPower > 0 && !engineLerp) ? 1: 0;

            float pitch = ULerp(lowPitchMin, lowPitchMax, engineRPM / maxRPM);
            pitch = Mathf.Min(lowPitchMax, pitch);
            if (Turbo != null)
                m_Turbo.pitch = 0.76f + (engineRPM / maxRPM) /2;

            m_LowAccel.pitch = pitch * Pitch;
            m_LowDecel.pitch = pitch * Pitch;
            m_HighAccel.pitch = pitch * highPitchMultiplier * Pitch;
            m_HighDecel.pitch = pitch * highPitchMultiplier * Pitch;

            float decFade = 1 - accFade;
            float highFade = Mathf.InverseLerp(0.2f, 0.8f, engineRPM / maxRPM);
            float lowFade = 1 - highFade;
            
            highFade = 1 - ((1 - highFade) * (1 - highFade));
            lowFade = 1 - ((1 - lowFade) * (1 - lowFade));
            //accFade = 1 - ((1 - accFade) * (1 - accFade));
            decFade = 1 - ((1 - decFade) * (1 - decFade));
            m_LowAccel.volume = Mathf.Lerp(m_LowAccel.volume, lowFade*accFade, 7 * Time.deltaTime ); 
            m_LowDecel.volume = Mathf.Lerp(m_LowDecel.volume, lowFade*decFade, 30 * Time.deltaTime );
            m_HighAccel.volume = Mathf.Lerp(m_HighAccel.volume, highFade*accFade, 30 * Time.deltaTime );
            m_HighDecel.volume = Mathf.Lerp(m_HighDecel.volume, highFade*decFade, 30 * Time.deltaTime );
            
            if (Turbo != null)
                m_Turbo.volume = highFade * accFade  * turboVolume ;                
        }
    }

    private AudioSource SetUpEngineAudioSource(AudioClip clip)
    {
        AudioSource source = audioObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = 0;
        source.spatialBlend = 1;
        source.loop = true;
        source.dopplerLevel = 0;
        source.time = Random.Range(0f, clip.length);
        source.Play();
        source.minDistance = 5;
        source.reverbZoneMix = 0;
        source.maxDistance = maxRolloffDistance;
        return source;
    }

    private AudioSource setupDownShift(AudioClip clip)
    {
        AudioSource source = audioObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = downShiftVolume;
        source.spatialBlend = 1;
        source.loop = false;
        source.dopplerLevel = 0;
        source.time = Random.Range(0f, clip.length);
        //source.Play();
        source.minDistance = 5;
        source.maxDistance = maxRolloffDistance;
        source.playOnAwake = false;
        return source;
    }

    public void DownShift()
    {
        if (downShift != null)
            m_downShift.Play();
    }
   
    private  float ULerp(float from, float to, float value)
    {
        return (1.0f - value)*from + value*to;
    }    
}