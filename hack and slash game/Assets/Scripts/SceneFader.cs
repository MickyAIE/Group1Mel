using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{

    public Image img;//what you want the scene fader to look like i sugest a black screen
    public AnimationCurve curve;//how fast and or slow the scene fader works

    void Start()
    {
        StartCoroutine(FadeIn());//start fadeout turn screen black
    }

    public void FadeTo (string scene)
    {
        StartCoroutine(FadeOut(scene));//fade in to new scene turn screen normal from black
    }

    IEnumerator FadeIn ()//causes the screen to turn black(image)
    {
        float t = 1f;//t = time

        while (t > 0f)//while timer more then 0 do this
        {
            t -= Time.deltaTime;//count down using real time
            float a = curve.Evaluate(t);//use curvature thing to figure out how "fast" to do fadein
            img.color = new Color(0f, 0f, 0f, a);//make image black
            yield return 0;//return + something extra
        }
    }
    IEnumerator FadeOut(string scene)//causes the screen to remove image(black)
    {
        float t = 0f;

        while (t > 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

        SceneManager.LoadScene(scene);//load new scene

    }

}
