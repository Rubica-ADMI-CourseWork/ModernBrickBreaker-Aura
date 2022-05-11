using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxBehaviour : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 1f);
    }
}
