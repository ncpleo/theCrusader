using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene32Controller : MonoBehaviour
{
    private CanvasGroup title, spaceGuide, Lmsg;
    private SpriteRenderer armyImg;
    private AudioSource audioSource;
    public AudioClip click, soldier;
    public int fadeIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        title = GameObject.Find("EventTitle_img").GetComponent<CanvasGroup>();
        spaceGuide = GameObject.Find("Guide_text").GetComponent<CanvasGroup>();
        Lmsg = GameObject.Find("Messagebox (1)").GetComponent<CanvasGroup>();
        armyImg = GameObject.Find("Army_img").GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(UIanim());
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIndex < 2) { 
            if (Input.GetMouseButtonDown(0))
            {
                audioSource.PlayOneShot(click);
                spaceGuide.alpha = 0;
                StartCoroutine(FadeIn(Lmsg, 1f));
            }
        }

        if (fadeIndex == 2) {
            //StopAllCoroutines();
            if (Input.GetMouseButtonDown(0)) {
                audioSource.PlayOneShot(click);
                Lmsg.alpha = 0;
                spaceGuide.alpha = 1;
                StartCoroutine(SpriteFadeIn(armyImg, 1f));
                audioSource.PlayOneShot(soldier);
                GameObject.Find("Army_img").GetComponent<BoxCollider>().enabled = true;
            }
        }

        if (fadeIndex == 4) {       //leader list
            if (Input.GetMouseButtonDown(0)) {
                SceneManager.LoadScene("3d_BattleScene");
            }
        }

       
    }

    IEnumerator UIanim()
    {
        yield return new WaitForSeconds(1);
        FadeInTitle();
        yield return new WaitForSeconds(2);
        spaceGuide.alpha = 1;   
    }

    public void FadeInTitle() {
        StartCoroutine(FadeIn(title, 1f));
    }

    public IEnumerator FadeIn(CanvasGroup img, float FadeTime)
    {
        float currentTime = 0;
        //float target = img.alpha;
        while (currentTime < FadeTime)
        {
            currentTime += Time.deltaTime;
            img.alpha = Mathf.Lerp(0, 1, currentTime / FadeTime);
            yield return null;
        }
        fadeIndex++;
        yield break;
    }

    IEnumerator SpriteFadeIn(SpriteRenderer img, float FadeTime)
    {
        Color c = img.color;
        float currentTime = 0;
        while (currentTime < FadeTime)
        {
            currentTime += Time.deltaTime;
            c.a += currentTime / FadeTime;
            img.color = c;
            if (c.a >= 1)
                c.a = 1f;
            yield return null;
        }
        fadeIndex++;
        yield break;
    }
}
