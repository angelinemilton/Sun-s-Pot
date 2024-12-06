using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Counter : MonoBehaviour
{
    [SerializeField] List<Transform> slots;
    [SerializeField] int nextAvailableSlot;
}
