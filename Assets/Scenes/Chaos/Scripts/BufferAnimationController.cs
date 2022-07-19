using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BufferAnimationController : MonoBehaviour
{
    public VisualEffect vfx;

    private LinkedList<string> sequences = new LinkedList<string>();
    private LinkedList<string> qualities;

    int numberOfTs = 0;
    int numberOfCs = 0;
    int numberOfGs = 0;
    int numberOfAs = 0;

    string dummy_seq = "CATTGTACTTCGTTCAATTTTTCGAATTTGAGTGTTTAACCGTTTTCGCATTTATCGTGAAACGCTTTCGCGTTTTTCGTGCACCGCTTCAATATACCAAATGTCATATCTATAATCTGGTTTTGTTTTTTTGAATAATAAATATTTTCATTCTTGCGGTTTGGAGGAATTGATTCAAATTCAAGCAGAAATAATTCCAGGAGTCCAAAATATGTATCAATGCAGCATTTGAGCAAGTGCGATAAATCTTTAAGTGCTTCTTTCCCATGGTTTTAGTCATAAAACTCTCCATTTTGATAGGTTGCATGCTAGATGCTGAAGTATATTTTTGAAAATTTGTCGATGCTACTTAACTGTCAATATGGCCACAAGTTGTTTGATCTTTGCAATGATTTATATCAGAAACCATATAGTAAATTAGTTACACAGGAAATTTTTATATGTCCTTATTATCATTCATTATGTATTAAAATTAGAGTTGTGGCTTGGCTCTGCTAACACGTTGCTCATAGGAGATATGGTAGAGCCGCAGACACGTCGTATGCAGGAACGTGCTGCGGCTGGCTGGTGAACTTCCGATAGTGCGGGTGTTAGACGTTGATTCTTATACCGATTTTACATATTTTTTGCATGAGAA";
    string dummy_qual = "+&%%%%$#$%%%./8)(''242,$#*'+,-'-)+DFECCA><9>QAB.-379;:;<6867//000021/+++,-6A@:3301''(++*,,***]29646<=?10022422&--7<?<5452<;;-,/8=?@?<;<@],.+0572/0884+--@;=<6(()8@;8<]+*1223567502AC8::630*)+;DB@@??>,-./.&&.((<@=C]]:9<:;(79421....00..1/;;<<<B>>>BB??==A>;..+''-868@AJ><44002<F@2125))))/135]]C>;9>@A@?=@8:9GA>CC>@<><=@B?9822)&&@]=7654'&'&&%%%)),%%'''',+++*+//39:;:9'%%$%'']79913=9:82*((:=A4210,+---/))):8./142((5<<]656=;;A=:679541]3.0398::;74.')'$$#&&)-28:>;89:7,+,-88:<=?<=500374=].165=4554..08/6/,*9:>8====62..++,5<<795?]71122;=56'&&)0/+.333447:**))-9?==99?;;<32=;>876)(*-4645785654,&&%+*143]?;%$%%(''%$$%##%%''((&%&+/++,14465>JDD+(('%%2,-";

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 50; i++)
        {
            sequences.AddLast("0");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fillBuffer()
    {
        string next = dummy_seq.Substring(0, 1);
        string first = sequences.First.Value;
        sequences.RemoveFirst();
        sequences.AddLast(next);
        if (first.Equals("A"))
        {
            numberOfAs--;
        }
        if (next.Equals("A"))
        {
            numberOfAs++;
        }

        dummy_seq.Remove(0, 1);
    }
}
