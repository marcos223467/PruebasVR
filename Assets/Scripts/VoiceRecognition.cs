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



    // Start is called before the first frame update
    void Start()
    {
        m_recognizer = new KeywordRecognizer(commands);
        m_recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_recognizer.Start();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log(args.text);
        text.text = args.text;
    }
}
