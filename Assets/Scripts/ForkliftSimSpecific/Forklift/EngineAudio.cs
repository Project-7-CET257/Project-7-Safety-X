using UnityEngine;

public class EngineAudio : MonoBehaviour
{
    public AudioSource engineSource;
    public int gearShiftLength;
    public float pitchBoost, pitchRange;

    private Rigidbody RB;
    private float temp1;
    private int temp2;

    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float speed = RB.velocity.magnitude;
        temp1 = speed / gearShiftLength;
        temp2 = (int)temp1;

        float difference = temp1 - temp2;

        engineSource.pitch = Mathf.Lerp(engineSource.pitch, (pitchRange * difference) + pitchBoost, 0.01f);
    }
}