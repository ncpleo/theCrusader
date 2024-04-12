using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private CanvasGroup title, spaceGuide, playerImg, msg, Lmsg;
    private Animator msgAnim;
    private UnityEngine.UI.Text LmsgText;
    private SpriteRenderer armyImg;
    private AudioSource audioSource;
    public AudioClip click, soldier;
    public int fadeIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        title = GameObject.Find("EventTitle_img").GetComponent<CanvasGroup>();
        spaceGuide = GameObject.Find("Guide_text").GetComponent<CanvasGroup>();
        playerImg = GameObject.Find("Player_Image").GetComponent<CanvasGroup>();
        msg = GameObject.Find("Messagebox").GetComponent<CanvasGroup>();
        Lmsg = GameObject.Find("Messagebox (1)").GetComponent<CanvasGroup>();
        LmsgText = GameObject.Find("message_text (1)").GetComponent<UnityEngine.UI.Text>();
        msgAnim = GameObject.Find("Canvas").GetComponent<Animator>();
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
                StartCoroutine(FadeIn(playerImg, 1f));
            }
        }

        if (fadeIndex == 2) {
            msgAnim.SetTrigger("inFrame");
            if (Input.GetMouseButtonDown(0)) {
                audioSource.PlayOneShot(click);
                playerImg.alpha = 0;
                msg.alpha = 0;
                StartCoroutine(SpriteFadeIn(armyImg, 1f));
                audioSource.PlayOneShot(soldier);
            }
        }

        if (fadeIndex == 3) {
            StartCoroutine(FadeIn(Lmsg, 1f));
        }

        if (fadeIndex == 4) {
            StopAllCoroutines();
            if (Input.GetMouseButtonDown(0)) {
                audioSource.PlayOneShot(click);
                if (LmsgText.text.StartsWith("In 1095,"))
                    LmsgText.text = "This appeal led to Pope Urban II initiating the Crusades at the Council of Clermont in September 1095. In response to the call,   the First Crusade convened in Constantinople during the autumn   of 1096. 																								¡¿";
                else { 
                    Lmsg.alpha = 0;
                    spaceGuide.alpha = 1;
                    GameObject.Find("Army_img").GetComponent<BoxCollider>().enabled = true;
                }

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

    IEnumerator FadeIn(CanvasGroup img, float FadeTime)
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
