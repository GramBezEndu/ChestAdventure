using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LayerMaskExtensions
{
    public static bool IsLayerInMask(this LayerMask layerMask, int layer)
    {
        return layerMask == (layerMask | (1 << layer));
    }
}
