using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour {


    public string _sceneName = string.Empty;
    public Image HealthMeter;
    public float Health = 50f;
    private Rigidbody m_Rigidbody;
    private float regenTime = 0.1f;
    float Timer;

    // get a refrence to the Rigidbody, make a variable for the rigidbody
    // variable as a float for time till it starts to regen
    // variable for current count down time

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public void TakeDamage(float amnt)
    {
        Health -= amnt;
        HealthMeter.fillAmount = Health / 50;
        if (Health <= 0)
        {
            Application.LoadLevel(_sceneName);
        }
    }

    private void Update()
    {
       // Regenerate();
    }

    void Regenerate()
    {
        if (m_Rigidbody.velocity.magnitude < 1 && Timer < 0)
        {
            Health += 0.5f;
            Health = Mathf.Clamp(Health, 0f, 50f);
            HealthMeter.fillAmount = Health / 50;
            Timer = regenTime;
        }
        else
        {
            Timer -= Time.deltaTime;
        }
    }

    // make a function, eg void RegenHealth()
    /*
     * if statement to check the condition of if the rigidbody.velocity is < 1 and current count down time < 0 then
     * set the current count down time = time till start regen delay
     * Health += amount to give player
     * Health = mathf.clamp Health, minimum, maximum
     * else
     * current count down time -= time.deltatime
     */

}
