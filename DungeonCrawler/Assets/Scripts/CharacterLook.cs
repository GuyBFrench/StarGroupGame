/*Credit to the following tutorial for help with this script:
 https://youtu.be/YV5KOZHsIz4?feature=shared
*/

using System;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class CharacterLook : MonoBehaviour
{
    
    [SerializeField] private float lookSpeed = 1;
    
    private CinemachineFreeLook cinema;
    private LookChar playerInput;

    private void Awake()
    {
        playerInput = new LookChar();
        cinema = GetComponent<CinemachineFreeLook>();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Update()
    {

        Vector2 delta = playerInput.Main.Look.ReadValue<Vector2>();
        cinema.m_XAxis.Value += delta.x * lookSpeed * 200 * Time.deltaTime;

    }

    
}
