﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class OnInteract : MonoBehaviour {

    public virtual void StartInteraction() {
        GameData.PlayerCanMove = true;
    }
}
