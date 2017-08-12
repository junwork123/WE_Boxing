using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Margin))]
public class MonoTexture : MonoBehaviour
{
    [SerializeField]
    private int width = 150;
    [SerializeField]
    private int height = 80;

    public void InitializeBar()
    {
        this.Margin = this.GetComponent<Margin>();
    }

#region Public Attributes

    /// <summary>
    /// The outline bar look.
    /// </summary>
    public Texture2D OutlineTexture;

    /// <summary>
    /// Get margins for this component.
    /// </summary>
    public Margin Margin { get; set; }

    /// <summary>
    /// Z-Index is used to layer appropriate between multiple GUITextures
    /// </summary>
    public int Zindex = 0;

    /// <summary>
    /// Set the order of each bar, when multiple bars/items are displayed within the same area (DockStyle), 
    /// </summary>
    //public int FloatIndex;

    /// <summary>
    /// The width of the component.
    /// </summary>
    public int Width
    {
        get { return width; }
        set
        {
            //Prevent updating all the time from editor extension
            //Editor update the value in every frame and so aspect ratio resize is bugging.
            if (value != width)
            {
                width = value;
                if (KeepAspectRatio && OutlineTexture != null)
                {
                    height = width * OutlineTexture.height / OutlineTexture.width;
                }
            }
        }
    }

    /// <summary>
    /// The height of the component.
    /// </summary>
    public int Height
    {
        get { return height; }
        set
        {
            //Prevent updating all the time from editor extension
            //Editor update the value in every frame and so aspect ratio resize is bugging.
            if (value != height)
            {
                height = value;
                if (KeepAspectRatio && OutlineTexture != null)
                {
                    width = height * OutlineTexture.width / OutlineTexture.height;
                }
            }
        }
    }

    /// <summary>
    /// Keep the aspect ratio of the texture.
    /// </summary>
    public bool KeepAspectRatio = true;

    public int PosX = Screen.width;
    public int PosY = Screen.height;

    /// <summary>
    /// Get the total height of the component, including its margin (top, bottom).
    /// </summary>
    public int TotalHeight
    {
        get { return Height + Margin.Top + Margin.Bottom; }
    }

    /// <summary>
    /// Get the total width of the component, including its margin (left, right).
    /// </summary>
    public int TotalWidth
    {
        get { return Width + Margin.Left + Margin.Right; }
    }

    void OnGUI()
    {
        GUI.depth = -Zindex;
        GUI.BeginGroup(new Rect(this.PosX, this.PosY, this.Width, this.Height), this.OutlineTexture);
        GUI.EndGroup();
    }

#endregion
//End Public Attributes

}
