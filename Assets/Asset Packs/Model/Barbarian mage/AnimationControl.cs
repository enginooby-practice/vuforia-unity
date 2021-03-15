using UnityEngine;
using System.Collections;
using UnityEditor;

public class AnimationControl : MonoBehaviour
{
    public static AnimationControl Instance;
    public GameObject[] AinObjs;
    private int CurAinObjCount = 0;
    //public GameObject AinObj;
    private Animation ain;
    public AnimationClip[] clips;
    public int CurrentAnimClip = 0;
    public string CurrentAnimName;
    // Use this for initialization

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        AddAnim();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 210, 120, 50), "NestAnim"))
        {
            CurrentAnimClip++;
            if (CurrentAnimClip > clips.Length - 1)
                CurrentAnimClip = 0;
            PlayAnim();
        }
        if (GUI.Button(new Rect(10, 260, 120, 50), "On One Anim"))
        {
            PlayNextAnimation();
        }
        if (GUI.Button(new Rect(10, 310, 120, 50), "RepeatPlay"))
        {
            PlayAnim();
        }
        if (clips[CurrentAnimClip] != null)
            GUI.Label(new Rect(10, 10, 100, 20), clips[CurrentAnimClip].name);

        //		if (GUI.Button(new Rect(10, 110, 150, 30), "NextCommodity"))
        //			ChooseChar ();
    }

    public void PlayNextAnimation()
    {
        CurrentAnimClip--;
        if (CurrentAnimClip < 0)
            CurrentAnimClip = clips.Length - 1;
        PlayAnim();
    }

    public GameObject[] Chrs;
    public int i = 0;
    private int curi = 0;
    void ChooseChar()
    {
        CurAinObjCount = i;
        AinObjs[CurAinObjCount].SetActive(false);
        i += 1;
        if (i == AinObjs.Length)
        {
            i = 0;
        }
        AinObjs[i].SetActive(true);
        AddAnim();
    }


    void AddAnim()
    {
        ain = AinObjs[i].GetComponent<Animation>();
        clips = AnimationUtility.GetAnimationClips(ain);
    }
    void PlayAnim()
    {
        AinObjs[i].GetComponent<Animation>().Play(clips[CurrentAnimClip].name);
        CurrentAnimName = clips[CurrentAnimClip].name;
    }
}
