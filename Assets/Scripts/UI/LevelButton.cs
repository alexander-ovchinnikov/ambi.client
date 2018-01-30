using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Text _text;

    public Button Button
    {
        get { return _button; }
    }

    public Text Text
    {
        get { return _text; }
    }
}