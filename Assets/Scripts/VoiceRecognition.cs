using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using UnityEngine.XR.Interaction.Toolkit;
using Random = UnityEngine.Random;

public class VoiceRecognition : MonoBehaviour
{
    [SerializeField]
    private string[] commands;

    private KeywordRecognizer m_recognizer;
    public TextMeshProUGUI text;
    private Varita _varita;



    // Start is called before the first frame update
    void Start()
    {
        _varita = GetComponent<Varita>();
        m_recognizer = new KeywordRecognizer(commands);
        m_recognizer.OnPhraseRecognized += OnPhraseRecognized;
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log(args.text);
        switch (args.text)
        {
            case "Lumos":
                _varita.Lumos(true);
                text.text = args.text;
                break;
            case "Nox":
                _varita.Lumos(false);
                text.text = args.text;
                break;
            case "Flipendo":
                _varita.Flipendo();
                text.text = "Flipendo";
                break;
        }
    }

    public void Stop(bool orden)
    {
        if (orden)
        {
            m_recognizer.Stop();
        }
        else
        {
            m_recognizer.Start();
        }
    }
}
