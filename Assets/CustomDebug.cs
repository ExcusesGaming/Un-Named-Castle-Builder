using UnityEngine;
using Excuses.Libraries.UI;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class CustomDebug : MonoBehaviour
{
    public static CustomDebug Instance;
    public Sprite BackgroundSprite;
    public Color32 BackgroundColor;
    UIScrollMenu newBackground;

    public Color32 ErrorColor;
    public Color32 ActionColor;
    public Color32 NoteColor;

    public List<string> DebugLogs = new List<string>();

    public void Awake()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        newBackground = new UIScrollMenu(ExcusesUIMaster.Instance, FindAnyObjectByType<Canvas>().gameObject, "Debug Menu")
            .setSprites(new SpriteData(BackgroundSprite, BackgroundColor), new SpriteData(BackgroundSprite, BackgroundColor), new SpriteData(BackgroundSprite, BackgroundColor))
            .setAnchor(new Vector2(0, 0))
            .setPosition(10, 10)
            .setSize(ExcusesUIMaster.ScaleType.Default, new Vector2(Screen.width / 4, Screen.height / 2))
            .setLayoutType(ExcusesUIMaster.LayoutType.Vertical, new LayoutData(new Vector4(4,4,4,4), 12), TextAnchor.LowerCenter)
            .setContentSize(ContentSizeFitter.FitMode.Unconstrained, ContentSizeFitter.FitMode.MinSize)
            .setScrollSensitivity(30)
            .setScrollContraints(false, true)
            .setScrollType(ScrollRect.MovementType.Clamped)
            .setScrollbarsInvisible();

        newBackground.scrollMenu.imageOBJ.SetActive(false);
    }

    public void Log(string message, string origin, int line, Color32 messageColor, float height)
    {
        UIText newLog = new UIText(ExcusesUIMaster.Instance, newBackground.contentOBJ, "Debug Menu Text")
            .setSize(ExcusesUIMaster.ScaleType.ExpandX, new Vector2(0, height), new Vector2(10, 0))
            .setText(new TextData(message + " (" + origin + ": Line: " + line.ToString() +  ")", 14, messageColor, TextAlignmentOptions.Left))
            .setMultiLine();
        DebugLogs.Add(message + " (" + origin + ")");
        newBackground.scrollMenuData.velocity = new Vector2(0, 1000);
    }

    public void ToggleDebugMenu()
    {
        newBackground.scrollMenu.imageOBJ.SetActive(!newBackground.scrollMenu.imageOBJ.activeSelf);
    }
}
