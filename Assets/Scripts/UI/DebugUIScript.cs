using UnityEngine;
using TMPro;

public class DebugUIScript : MonoBehaviour
{
    public static DebugUIScript Instance { get; private set; }

    [SerializeField]
    TextMeshProUGUI TextPro = null;

    void Start()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public void SetText(string text)
    {
        TextPro.text = text;
    }
}
