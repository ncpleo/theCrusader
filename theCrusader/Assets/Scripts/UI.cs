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
        textWriter.AddWriter(messageText, "The First Crusade was the only one to achieve its goal. Christian forces successfully captured Jerusalem on July 15, 1099. It marked the church¡¦s successful attempt to reclaim Jerusalem from the Muslims, driven by religious fervor and geopolitical concerns.", .025f, true);
    }

}
