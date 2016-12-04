using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseHandler : MonoBehaviour
{
    public abstract int type { get; }

    public virtual void Start()
    {
        MainClient.Instance.RegisterHandler(type, this);
    }

    public abstract void Dispatch(int command, List<String> message);
}
