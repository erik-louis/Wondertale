using UnityEngine;

[System.Serializable]

public class DialogueLine
{
    public Speaker speakerLeft;
    public Speaker speakerRight;
    [TextArea]
    public string dialogue;
}
