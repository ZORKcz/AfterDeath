using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class CharacterEvents
{
    // Ondra dostane damage a jeho hodnota
    public static UnityAction<GameObject, int> characterDamaged;

    // Ondra se vyhealuje a jeho hodnota
    public static UnityAction<GameObject, int> characterHealed;
}
