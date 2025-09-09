using IIDKQuest.Classes;
using UnityEngine;
using static IIDKQuest.Menu.Main;

namespace IIDKQuest
{
    internal class Settings
    {
        static Color ParseHex(string hex)
        {
            Color color;
            ColorUtility.TryParseHtmlString(hex, out color);
            return color;
        }

        public static ExtGradient backgroundColor = new ExtGradient
        {
            colors = GetSolidGradient(ParseHex("#0D0F1A"))
        };

        public static ExtGradient[] buttonColors = new ExtGradient[]
        {
            new ExtGradient { colors = GetSolidGradient(ParseHex("#263042")) },
            new ExtGradient { colors = GetSolidGradient(ParseHex("#3A6BFF")) }
        };

        public static Color[] textColors = new Color[]
        {
            Color.white,
            Color.white
        };

        public static Font currentFont = (Resources.GetBuiltinResource<Font>("Arial.ttf") as Font);

        public static bool fpsCounter = true;
        public static bool disconnectButton = true;
        public static bool rightHanded = false;
        public static bool disableNotifications = false;

        public static KeyCode keyboardButton = KeyCode.Q;

        public static Vector3 menuSize = new Vector3(0.1f, 1f, 1f);
        public static int buttonsPerPage = 6;

        public static void ChangeMenuTheme
(
    Color background,
    Color buttonColor1,
    Color buttonColor2,
    Color textColor1,
    Color textColor2,
    string fontName,
    int fontSize = 16,
    Color outlineColor = default
)
        {
            backgroundColor = new ExtGradient
            {
                isRainbow = false,
                colors = GetSolidGradient(background)
            };

            buttonColors = new ExtGradient[]
            {
        new ExtGradient
        {
            isRainbow = false,
            colors = GetSolidGradient(buttonColor1)
        },
        new ExtGradient
        {
            isRainbow = false,
            colors = GetSolidGradient(buttonColor2)
        }
            };

            textColors = new Color[]
            {
        textColor1,
        textColor2
            };

            RecreateMenu();

            if (outlineColor != default)
            {
                UpdateMenuOutlineColor(outlineColor);
            }
        }
    }
}
