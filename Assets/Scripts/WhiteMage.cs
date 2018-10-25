using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteMage : Character3D {

    override protected void Start()
    {
        usesMana = true;

        base.Start();
    }
}
