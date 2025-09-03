using UnityEngine;

public class ApplySolidColor : MonoBehaviour
{
    [Header("Target Renderer")]
    public Renderer targetRenderer;

    [Header("RGBA (0-255)")]
    [Range(0,255)] public int r = 255;
    [Range(0,255)] public int g = 255;
    [Range(0,255)] public int b = 255;
    [Range(0,255)] public int a = 255;

    [Header("Shader Color Property (URP: _BaseColor)")]
    public string colorProperty = "_BaseColor";

    void Reset()
    {
        targetRenderer = GetComponent<Renderer>();
    }

    void Awake()
    {
        if (targetRenderer == null) targetRenderer = GetComponent<Renderer>();
        if (targetRenderer == null) return;

        // 머티리얼 인스턴스화 후 정확한 0-255 색 적용
        var mat = targetRenderer.material;
        Color32 c32 = new Color32((byte)r, (byte)g, (byte)b, (byte)a);
        if (mat.HasProperty(colorProperty))
        {
            mat.SetColor(colorProperty, (Color)c32);
        }
        else
        {
            // 일반 color 속성도 시도
            if (mat.HasProperty("_Color"))
                mat.SetColor("_Color", (Color)c32);
        }
    }
}
