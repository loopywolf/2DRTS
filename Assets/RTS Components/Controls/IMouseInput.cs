using System.Collections.Generic;
using UnityEngine;

public interface IMouseInput 
{
    public void MouseInput();
}

public interface ILeftMouseClick
{
    void LeftMouseClick(List<GameObject> clickedList);

    void LeftMouseClick(Vector3 MousePosition);
}


public interface IRightMouseClick
{
    void RightMouseClick(List<GameObject> clickedList);

    void RightMouseClick(Vector3 MousePosition);
}


