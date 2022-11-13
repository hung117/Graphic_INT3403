using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public bool getSpaceBar()
    {
        // return Input.GetButtonDown(GameConstant.Input_Jump);
        return Input.GetButton(GameConstant.Input_Jump);
    }
    public bool getSprint()
    {
        return Input.GetButton(GameConstant.Input_Sprint);
    }
    public bool getCrouch()
    {
        return Input.GetButton(GameConstant.Input_Crouch);
    }
    public bool getLeanL()
    {
        return Input.GetButton(GameConstant.Input_LeanL);
    }
    public bool getLeanR()
    {
        return Input.GetButton(GameConstant.Input_LeanR);
    }
    public Vector3 getMove()
    {
        float vertical = Input.GetAxis(GameConstant.Input_Vertical);
        float horizontal = Input.GetAxis(GameConstant.Input_Horizontal);
        return new Vector3(horizontal, 0, vertical).normalized;
    }
    public Vector3 getLook()
    {
        float vertical = Input.GetAxis(GameConstant.Input_VMouseY);
        float horizontal = Input.GetAxis(GameConstant.Input_HMouseX);
        return new Vector3(vertical, horizontal, 0);
    }
    public Vector3 getMousePosition()
    {
        return Input.mousePosition;
    }
    public float getMouseZoom()
    {
        return Input.mouseScrollDelta.y;
    }
    public bool getLookMode()
    {
        return Input.GetButton(GameConstant.Input_LookMode);
    }
    public bool getRightClick()
    {
        return Input.GetButton(GameConstant.Input_Aim);
    }
    public bool getLeftClick()
    {
        // return Input.GetButtonDown(GameConstant.Input_Attack);
        return Input.GetMouseButtonDown(0);
    }
    public bool getAttackAuto()
    {
        return Input.GetButton(GameConstant.Input_Attack);
    }

    public bool getPrimary()
    {
        return Input.GetButton(GameConstant.Input_Equip_Primary);
    }
    public bool get2nd()
    {
        return Input.GetButton(GameConstant.Input_Equip_Secondary);
    }
    public bool getGrenade()
    {
        return Input.GetButton(GameConstant.Input_Equip_Grenade);
    }
    public bool getAccessory()
    {
        return Input.GetButton(GameConstant.Input_Equip_Accessory);
    }
    public bool getEnterCombat()
    {
        return Input.GetButtonDown(GameConstant.Input_Enter_Combat);
    }
    public bool getShift()
    {
        return Input.GetButton(GameConstant.Input_Run);

    }
}
