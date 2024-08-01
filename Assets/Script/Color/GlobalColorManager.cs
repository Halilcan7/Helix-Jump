using UnityEngine;

public static class GlobalColorManager
{
    public static Color newColor = new Color(1f, 0.7660394f, 0.3537736f);

    public static void SetColor(Color color)
    {
        newColor = color;
    }

    public static Color GetColor()
    {
        return newColor;
    }

    public static Color HexToColor(string hex)
    {
        // HEX kodunu RGB bileşenlerine ayırma
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

        // Yeni rengi oluşturma
        return new Color32(r, g, b, 255);
    }
}
