using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
   void DealDamage(int damage); //any script with IDamagable must have a function called deal damage

}
