using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// DockStyle defines the section/area that each item is positioned.
/// </summary>
public enum DockStyle
{
    TopLeft = 0,
    TopCenter = 1,
    TopRight = 2,
    MiddleLeft = 3,
    MiddleCenter = 4,
    MiddleRight = 5,
    BottomLeft = 6,
    BottomCenter = 7,
    BottomRight = 8
}

public class MonoDockList : MonoBehaviour
{

#region Dock Positions

    /*
     *  Top Layer Dock Positions.
     */
    //Top left point of screen.
    private Vector2 TopLeftPos = new Vector2(0, 0);

    //Top center point of screen.
    private Vector2 TopCenterPos = new Vector2(Screen.width / 2, 0);

    //Top right position of screen.
    private Vector2 TopRightPos = new Vector2(Screen.width, 0);

    /*
     *  Middle Layer Dock Positions.
     */
    //Center left position of screen.
    private Vector2 MiddleLeftPos = new Vector2(0, Screen.height / 2);

    //Center of position screen.
    private Vector2 MiddleCenterPos = new Vector2(Screen.width / 2, Screen.height / 2);

    //Center right position of screen.
    private Vector2 MiddleRightPos = new Vector2(Screen.width, Screen.height / 2);

    /*
     *  Middle Layer Dock Positions.
     */
    //Bottom left position of screen.
    private Vector2 BottomLeftPos = new Vector2(0, Screen.height);

    //Bottom center position of screen.
    private Vector2 BottomCenterPos = new Vector2(Screen.width / 2, Screen.height);

    //Bototm right position of screen.
    private Vector2 BottomRightPos = new Vector2(Screen.width, Screen.height);

#endregion
//End Dock Positions

    public DockStyle DockStyle = DockStyle.TopLeft;

    public OrderStyle OrderStyle = OrderStyle.LeftToRight;
    
    /// <summary>
    /// The Entry Point for the Area.
    /// </summary>
    private Vector2 StartingPoint = Vector2.zero;

    private OrderList FloatList = new OrderList();

    public void Awake()
    {
        Update();
    }

    /// <summary>
    /// Find any new children.
    /// </summary>
    private void GetChildren()
    {
        foreach (Transform child in this.gameObject.transform)
        {
            MonoTexture monoTexture = child.gameObject.GetComponent<MonoTexture>();
            if (monoTexture != null)
            {
                AddNewBar(monoTexture);
            }
        }
    }

    /// <summary>
    /// Remove any object in list, where its not our child anymore.
    /// </summary>
    private void ClearMissingChildren()
    {
        //Create a list to hold the children that gonna be removed.
        List<MonoTexture> barsToRemove = new List<MonoTexture>();

        //Iterate through all children to check if some is missing.
        foreach (MonoTexture bar in FloatList.OrderListBars)
        {
            if (bar.transform.parent != this.gameObject.transform)
            {
                barsToRemove.Add(bar);
            }
        }

        //Finally, remove any missing children.
        foreach (MonoTexture barToRemove in barsToRemove)
        {
            FloatList.OrderListBars.Remove(barToRemove);
        }
    }

    /// <summary>
    /// Position current list relative to DockStyle
    /// </summary>
    private void PositionListToDockPoint()
    {
        /*
         *  Top Layer Dock Positions.
         */
        TopLeftPos = new Vector2(0, 0);
        TopCenterPos = new Vector2(Screen.width / 2, 0);
        TopRightPos = new Vector2(Screen.width, 0);

        /*
         *  Middle Layer Dock Positions.
         */
        MiddleLeftPos = new Vector2(0, Screen.height / 2);
        MiddleCenterPos = new Vector2(Screen.width / 2, Screen.height / 2);
        MiddleRightPos = new Vector2(Screen.width, Screen.height / 2);

        /*
         *  Middle Layer Dock Positions.
         */
        BottomLeftPos = new Vector2(0, Screen.height);
        BottomCenterPos = new Vector2(Screen.width / 2, Screen.height);
        BottomRightPos = new Vector2(Screen.width, Screen.height);


        if (this.DockStyle == DockStyle.TopLeft)
        {
            FloatList.CenterX = false;
            FloatList.CenterY = false;
            FloatList.InvertX = false;
            FloatList.InvertY = false;
            this.StartingPoint = TopLeftPos;
        }
        else if (this.DockStyle == DockStyle.TopCenter)
        {
            FloatList.CenterX = true;
            FloatList.CenterY = false;
            FloatList.InvertX = false;
            FloatList.InvertY = false;
            this.StartingPoint = TopCenterPos;
        }
        else if (this.DockStyle == DockStyle.TopRight)
        {
            FloatList.CenterX = false;
            FloatList.CenterY = false;
            FloatList.InvertX = true;
            FloatList.InvertY = false;
            this.StartingPoint = TopRightPos;
        }


        if (this.DockStyle == DockStyle.MiddleLeft)
        {
            FloatList.CenterY = true;
            FloatList.CenterX = false;
            FloatList.InvertX = false;
            FloatList.InvertY = false;
            this.StartingPoint = MiddleLeftPos;
        }
        else if (this.DockStyle == DockStyle.MiddleCenter)
        {
            FloatList.CenterX = true;
            FloatList.CenterY = true;
            FloatList.InvertX = false;
            FloatList.InvertY = false;
            this.StartingPoint = MiddleCenterPos;
        }
        else if (this.DockStyle == DockStyle.MiddleRight)
        {
            FloatList.InvertX = true;
            FloatList.CenterY = true;
            FloatList.CenterX = false;
            FloatList.InvertY = false;
            this.StartingPoint = MiddleRightPos;
        }

        else if (this.DockStyle == DockStyle.BottomLeft)
        {
            FloatList.InvertY = true;
            FloatList.CenterX = false;
            FloatList.CenterY = false;
            FloatList.InvertX = false;
            this.StartingPoint = BottomLeftPos;
        }
        else if (this.DockStyle == DockStyle.BottomCenter)
        {
            FloatList.InvertY = true;
            FloatList.CenterX = true;
            FloatList.CenterY = false;
            FloatList.InvertX = false;
            this.StartingPoint = BottomCenterPos;
        }
        else if (this.DockStyle == DockStyle.BottomRight)
        {
            FloatList.InvertY = true;
            FloatList.InvertX = true;
            FloatList.CenterX = false;
            FloatList.CenterY = false;
            this.StartingPoint = BottomRightPos;
        }
    }

    /// <summary>
    /// Add new Bar to 'Bars' List and let auto handle the position.
    /// </summary>
    /// <param name="newBar">Add new Bar to this Area.</param>
    public void AddNewBar(MonoTexture newBar)
    {
        //if the bar does not already exists, add it to the relevant list.
        if (!FloatList.OrderListBars.Contains(newBar))
        {
            //Initialize any new bar.
            newBar.InitializeBar();

            //Add new bar into list.
            FloatList.OrderListBars.Add(newBar);
        }
    }

    private void Update()
    {
        //Componenet must be placed at Zero point.
        this.transform.position = Vector3.zero;
        
        //Position list to relative dock point.
        PositionListToDockPoint();
        
        //Find new children.
        GetChildren();

        //Clear missing children.
        ClearMissingChildren();

        //Update list's order style.
        FloatList.OrderStyle = this.OrderStyle;

        //Draw-Position the list holding our textures.
        FloatList.Draw(StartingPoint);

    }
}