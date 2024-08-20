using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHpSystem
{
    public void Hurt(bool HurtState);
    public void Dead();
}
