using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Observable
{
    void RegisterObserver(Observer obs);

    void Notify(object observable);
}
