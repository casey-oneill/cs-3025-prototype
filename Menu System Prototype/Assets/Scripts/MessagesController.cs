using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagesController : MonoBehaviour
{

    public Text message;

    public void UpdateMessage(string message)
    {
        this.message.text = message;
    }
}
