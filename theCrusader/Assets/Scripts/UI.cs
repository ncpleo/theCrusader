using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private TextWriter textWriter;
    private Text messageText;

    private void Awake()
    {
        messageText = transform.Find("message").GetComponent<Text>();

    }

    private void Start()
    {
        textWriter.AddWriter(messageText, "The capture of Jerusalem from Muslim control marked the culmination of the First Crusade (1095-1102), a military campaign orchestrated by Western rulers, the Pope, and the Byzantine Empire. Jerusalem fell on July 15, 1099, after a brief siege. Three weeks later, the Crusaders repelled the Muslim relief army, declaring the First Crusade a great success in the Western world. The Crusaders overcame these difficulties despite serious challenges such as logistical problems, famine, disease, powerful enemies and internal conflicts. However, the Crusaders continued to conduct several Crusades over the next two centuries in defense of the Holy Land.", .025f, true);
    }

}
