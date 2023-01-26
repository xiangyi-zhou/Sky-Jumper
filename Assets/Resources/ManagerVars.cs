using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ManagerVars： 创建一个容器，管理各种素材资源
/// 需要创建【Resources】文件夹，并在其中创建 ManagerVarsContainer 容器
/// 在本文件中定义变量，再将素材拖拽到“容器”的属性面板中匹配
/// </summary>
//[CreateAssetMenu(menuName ="CreatManagerVarsContainer")]
// 创建完容器，就可以注释掉
public class ManagerVars : ScriptableObject
{
    public static ManagerVars GetManagerVars()
    {
        return Resources.Load<ManagerVars>("ManagerVarsContainer");
    }

    [Header("Sprite")]
    [Tooltip("游戏背景图片的主题"), SerializeField]
    public List<Sprite> bgThemeSpriteList = new List<Sprite>();
    [Tooltip("Platform平台图片的主题"), SerializeField]
    public List<Sprite> platformThemeSpriteList = new List<Sprite>();
    [Tooltip("角色正面图片"), SerializeField]
    public List<Sprite> skinSpriteList = new List<Sprite>();
    [Tooltip("角色背面图片"), SerializeField]
    public List<Sprite> characterSkinSpriteList = new List<Sprite>();

    [Header("Shop Skin (商店界面中购买皮肤)")]
    [Tooltip("商店界面中皮肤选择组件Prefab"), SerializeField]
    public GameObject skinChooseItemPre;
    [Tooltip("皮肤名称"), SerializeField]
    public List<string> skinNameList = new List<string>();
    [Tooltip("皮肤价格"), SerializeField]
    public List<int> skinPrice = new List<int>();

    [Header("Platform")]
    public GameObject normalPlatformPre;
    public List<GameObject> commonPlatformGroup = new List<GameObject>();
    public List<GameObject> grassPlatformGroup = new List<GameObject>();
    public List<GameObject> winterPlatformGroup = new List<GameObject>();
    [Tooltip("钉子平台左右生成"), SerializeField]
    public GameObject spikePlatformLeft, spikePlatformRight;

    [Header("Other")]
    [Tooltip("角色Prefab"), SerializeField]
    public GameObject characterPre;
    [Tooltip("钻石Prefab"), SerializeField]
    public GameObject diamondPre;
    [Tooltip("主角死亡特效"), SerializeField]
    public GameObject deathEffect;
    [Tooltip("向上移动一格的坐标距离（左右通用）"), SerializeField]
    public float nextXPos = 0.554f, nextYPos = 0.645f;
    [Tooltip("音效"), SerializeField]
    public AudioClip jumpClip, fallClip, hitClip, diamondClip, buttonClip;
    [Tooltip("音效开关按钮对应的图片"), SerializeField]
    public Sprite musicOn, musicOff;
}
