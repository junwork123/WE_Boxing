using UnityEngine;
using System.Collections;


public class Margin : MonoBehaviour
{

#region Public Attributes
    /// <summary>
    /// Top margin from other bars
    /// </summary>
    public int Top;

    /// <summary>
    /// Right margin from other bars
    /// </summary>
    public int Right;

    /// <summary>
    /// Bottom margin from other bars
    /// </summary>
    public int Bottom;

    /// <summary>
    /// Left margin from other bars
    /// </summary>
    public int Left;

#endregion
//End Public Attributes


    /// <summary>
    /// Initialization Constructor for all side margins together.
    /// </summary>
    /// <param name="AllMargin">Set a margin for all of the sides.</param>
    public void SetMargin(int AllMargin)
    {
        this.Top = AllMargin;
        this.Right = AllMargin;
        this.Bottom = AllMargin;
        this.Left = AllMargin;
    }

    /// <summary>
    /// Initialization Constructor for vertical and horizontal margin.
    /// </summary>
    /// <param name="TopBottom">Top and Bottom margin.</param>
    /// <param name="LeftRight">Left and Right margin.</param>
    public void SetMargin(int TopBottom, int LeftRight)
    {
        this.Top = TopBottom;
        this.Right = LeftRight;
        this.Bottom = TopBottom;
        this.Left = LeftRight;
    }

    /// <summary>
    /// Initialization Constructor for all the margins separated.
    /// </summary>
    /// <param name="Top">Top margin.</param>
    /// <param name="Right">Right margin.</param>
    /// <param name="Bottom">Bottom margin.</param>
    /// <param name="Left">Left margin.</param>
    public void SetMargin(int Top, int Right, int Bottom, int Left)
    {
        this.Top = Top;
        this.Right = Right;
        this.Bottom = Bottom;
        this.Left = Left;
    }
}
