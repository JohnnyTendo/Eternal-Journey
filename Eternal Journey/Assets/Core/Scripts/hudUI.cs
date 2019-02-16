using UnityEngine;
using UnityEngine.UI;

public class hudUI : MonoBehaviour
{

    public static hudUI instance;
    #region singleton
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More then one instance of HudUI found!");
            return;
        }
        instance = this;
    }
    #endregion

    public GameObject popUpMessage;
    public Text popUpText;

    public void PostMessage(string messageText)
    {
        popUpMessage.SetActive(!popUpMessage.activeSelf);
        popUpText.text = messageText;
        Invoke("DeactivateMessage", 10f);
    }

    // Update is called once per frame
    public void DeactivateMessage()
    {
        popUpMessage.SetActive(!popUpMessage.activeSelf);
    }
}
