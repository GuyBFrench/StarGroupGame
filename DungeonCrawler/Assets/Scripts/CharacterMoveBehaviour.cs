/*Credit to the following tutorial for help with this script:
https://www.youtube.com/watch?v=_QajrabyTJc
*/
using UnityEngine;

public class CharacterMoveBehaviour : MonoBehaviour

{
    public Joystick joystick;
    public CharacterController control;
    public FloatData speed;
    private Vector3 moveDirection;
    private Vector3 playerVelocity;
    void Update()
    {
        moveDirection.Set(joystick.Horizontal , 0,joystick.Vertical);
        moveDirection = control.transform.TransformDirection(moveDirection);
        control.Move(moveDirection * (Time.deltaTime * speed.Value));
    }
    
    
}
