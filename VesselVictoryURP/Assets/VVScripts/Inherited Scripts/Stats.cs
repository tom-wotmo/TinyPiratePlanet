using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    protected const float DEFAULT_HEALTH = 100f;
    public const float DEFAULT_MAXIMUM_HEALTH = 100f;
    public const float DEFAULT_MINIMUM_HEALTH = 0f;
    protected const int DEFAULT_ID = 0;

    protected string shipName = "ship";

    public virtual void Death()
    {
    }
   
}
