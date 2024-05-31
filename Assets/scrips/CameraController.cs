using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CameraController : MonoBehaviour
{
    //我们通过控制Player的旋转方法，来控制相机视角的左右移动，所以我们需要一个Player的Tranform
    public Transform player;
 
 
    //定义两个float变量，来获取鼠标移动的值
    private float mouseX, mouseY;
    //我们可以给鼠标增加一个灵敏度
    public float mouseSensitivity;
 
    //mouseY中的GetAxis方法会返回-1到1之间的浮点数，在鼠标移动的时候，数值会随着方向的变化而变化，在鼠标不动时，数值会回弹到0，所以我们就会遇到鼠标上下移动时回弹的问题
    private float xRotation;
 
    private void Update()
    {
        //在Update方法中，我们使用输入系统中的GetAxis方法来获取鼠标移动的值，乘以鼠标灵敏度再乘以Time.deltatime,鼠标移动的值就这样得到了
        //Input.GetAxis:它会在鼠标移动相应对应轴的过程中返回 -1 到 1 的值
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
 
        xRotation -= mouseY;
 
        //使用数学函数Clamp限制
        xRotation = Mathf.Clamp(xRotation,-70f,70f);
 
        //这里使用Transform的Rotate()方法来旋转player
        //Vector3.up是向上的一个三维变量，和一个0，1，0的三维变量是一样的
        //我们需要控制player的y轴旋转才能让它左右旋转
        player.Rotate(Vector3.up * mouseX);
        //接下来我们要选转相机了，我们使用tranform.localRotation方法，让相机上下旋转，使用localRotation就可以不被父对象旋转影响，造成一些奇怪的问题
        //因为localRotation是属性，我们还要给他赋值
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}