using UnityEngine;
using TMPro;

public class TMPVertexColor : MonoBehaviour
{
    private TMP_Text tmpText;

    void Start()
    {
        tmpText = GetComponent<TMP_Text>();
        tmpText.ForceMeshUpdate();
    }

    public void SetAllVerticesRed()
    {
        TMP_TextInfo textInfo = tmpText.textInfo;
        Color32 redColor = new Color32(244, 27, 0, 255);

        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            Color32[] vertexColors = textInfo.meshInfo[i].colors32;
            for (int j = 0; j < vertexColors.Length; j++)
            {
                vertexColors[j] = redColor;
            }
        }

        tmpText.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
    }

    public void SetAllVerticesGreen()
    {
        TMP_TextInfo textInfo = tmpText.textInfo;
        Color32 greenColor = new Color32(0, 233, 59, 255);

        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            Color32[] vertexColors = textInfo.meshInfo[i].colors32;
            for (int j = 0; j < vertexColors.Length; j++)
            {
                vertexColors[j] = greenColor;
            }
        }

        tmpText.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
    }
}
