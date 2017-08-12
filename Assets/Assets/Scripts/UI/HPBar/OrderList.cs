using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum OrderStyle
{
    TopDown,
    LeftToRight
}

public class OrderList
{

#region Public Attributes

    /// <summary>
    /// Hold Separate Relative Positioned bars and Absolute Position bars.
    /// </summary>
    public List<MonoTexture> OrderListBars = new List<MonoTexture>();

    /// <summary>
    /// Determine the float style of the list. e.g. Left-To-Right or Top-Down.
    /// </summary>
    public OrderStyle OrderStyle;

    /// <summary>
    /// Determine whether the list is docked at the right bound.
    /// </summary>
    public bool InvertX = false;

    /// <summary>
    /// Determine whether the list is docked at the bottom bound;
    /// </summary>
    public bool InvertY = false;

    /// <summary>
    /// Determine whether the list is centralized to X-Axis,
    /// regarding a starting point.
    /// </summary>
    public bool CenterX = false;

    /// <summary>
    /// Determine whether the list is centralized to Y-Axis,
    /// regarding a starting point.
    /// </summary>
    public bool CenterY = false;

    /// <summary>
    /// Get the total width of all the controls contained in the list.
    /// </summary>
    public int TotalWidth
    {
        get
        {
            int width = 0;
            //If the List has a top-down float,
            //then the widest control equals to the TotalWidth
            if (this.OrderStyle == OrderStyle.TopDown)
            {
                foreach (MonoTexture bar in OrderListBars)
                {
                    if (bar.TotalWidth > width)
                        width = bar.TotalWidth;
                }
            }
            //If the List has a left-to-right float,
            //then add all controls' widths.
            else if (this.OrderStyle == OrderStyle.LeftToRight)
            {
                foreach (MonoTexture bar in OrderListBars)
                {
                    width += bar.TotalWidth;
                }
            }
            return width;
        }
    }

    /// <summary>
    /// Get the total height of all the controls contained in the list.
    /// </summary>
    public int TotalHeight
    {
        get
        {
            int height = 0;

            //If the List has a left-to-right float,
            //then the highest control equals to the TotalHeight
            if (this.OrderStyle == OrderStyle.LeftToRight)
            {
                foreach (MonoTexture bar in OrderListBars)
                {
                    if (bar.TotalHeight > height)
                        height = bar.TotalHeight;
                }
            }
            //If the List has a top-down float,
            //then add all controls' heights.
            else if (this.OrderStyle == OrderStyle.TopDown)
            {
                foreach (MonoTexture bar in OrderListBars)
                {
                    height += bar.TotalHeight;
                }
            }
            return height;
        }
    }

#endregion
//End Public Attributes

    /// <summary>
    /// A basic Constractor of the class
    /// </summary>
    public OrderList()
    { }

    /// <summary>
    /// Place the List according to a starting position
    /// </summary>
    /// <param name="StartingPoint">A relative starting point to place the ordered list</param>
    public void Draw(Vector2 StartingPoint)
    {
        if (this.OrderStyle == OrderStyle.LeftToRight)
        {
            PlaceListLeftToRight(StartingPoint);
        }
        else if (this.OrderStyle == OrderStyle.TopDown)
        {
            PlaceListTopDown(StartingPoint);
        }
    }

#region Private Methods

    /// <summary>
    /// Place a list in a left-to-right style, relative to other bars and a starting position
    /// </summary>
    /// <param name="StartingPoint">A relative starting point to place the ordered list</param>
    private void PlaceListLeftToRight(Vector2 StartingPoint)
    {
        float x = StartingPoint.x;

        //If List is docked to right
        if (InvertX)
        {
            x = StartingPoint.x - this.TotalWidth;
        }

        //If List must be centered to starting position X
        if (CenterX)
        {
            x -= this.TotalWidth / 2;
        }

        for (int i = 0; i < OrderListBars.Count; i++)
        {
            float y = 0;

            //If List is docked to bottom
            if (InvertY)
            {
                y = StartingPoint.y + OrderListBars[i].Margin.Top - OrderListBars[i].Margin.Bottom - OrderListBars[i].TotalHeight;
            }
            else
            {
                y = StartingPoint.y + OrderListBars[i].Margin.Top - OrderListBars[i].Margin.Bottom;
            }

            //If List must be centered to starting position Y
            if (CenterY)
            {
                y -= this.OrderListBars[i].TotalHeight / 2;
            }

            if (i == 0)
            {
                x += OrderListBars[i].Margin.Left - OrderListBars[i].Margin.Right;
            }
            else
            {
                x += OrderListBars[i - 1].Width + OrderListBars[i - 1].Margin.Right + OrderListBars[i].Margin.Left - OrderListBars[i].Margin.Right;
            }

            //Place a bar accordingly to each other
            OrderListBars[i].PosX = (int)x;
            OrderListBars[i].PosY = (int)y;
        }
    }

    /// <summary>
    /// Place a list in a top-down style, relative to other bars and a starting position
    /// </summary>
    /// <param name="StartingPoint">A relative starting point to place the ordered list</param>
    private void PlaceListTopDown(Vector2 StartingPoint)
    {
        float y = StartingPoint.y;

        //If List is docked to bottom
        if (InvertY)
        {
            y = StartingPoint.y - this.TotalHeight;
        }

        //If List must be centered to starting position Y
        if (CenterY)
        {
            y -= this.TotalHeight / 2;
        }

        float x = 0;
        for (int i = 0; i < OrderListBars.Count; i++)
        {
            //if List is docked to right
            if (InvertX)
            {
                //Position from right bound
                x = StartingPoint.x + OrderListBars[i].Margin.Left - OrderListBars[i].Margin.Right - OrderListBars[i].Width;

                //If List must be centered to starting position X
                if (CenterX)
                {
                    x += OrderListBars[i].Width/2;
                } 
            }
            else
            {
                //Position from left bound
                x = StartingPoint.x + OrderListBars[i].Margin.Left - OrderListBars[i].Margin.Right;

                //If List must be centered to starting position X
                if (CenterX)
                {
                    x -= OrderListBars[i].Width / 2;
                } 
            }

            if (i == 0)
            {
                y += OrderListBars[i].Margin.Top;
            }
            else
            {
                y += OrderListBars[i - 1].Margin.Bottom + OrderListBars[i -1].Height + OrderListBars[i].Margin.Top;
            }

            //Place a bar accordingly to each other
            OrderListBars[i].PosX = (int)x;
            OrderListBars[i].PosY = (int)y;
        }
        
    }

#endregion
//End Private Methods
}
