/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE546_Suspicious_Comment__LATER_02.cs
Label Definition File: CWE546_Suspicious_Comment.label.xml
Template File: point-flaw-02.tmpl.cs
*/
/*
* @description
* CWE: 546 Suspicious Comment
* Sinks: LATER
*    GoodSink: does not contain suspicious comment
*    BadSink : does not contain a suspicious comment
* Flow Variant: 02 Control flow: if(true) and if(false)
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE546_Suspicious_Comment
{
class CWE546_Suspicious_Comment__LATER_02 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (true)
        {
            /* FLAW: This is the suspicious comment */
            /* LATER: There is a bug at this location...I'm not sure why! */
            IO.WriteLine("This a test of the emergency broadcast system");
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes true to false */
    private void Good1()
    {
        if (false)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            /* FIX: don't have those types of comments :) */
            IO.WriteLine("This a test of the emergency broadcast system");
        }
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (true)
        {
            /* FIX: don't have those types of comments :) */
            IO.WriteLine("This a test of the emergency broadcast system");
        }
    }

    public override void Good()
    {
        Good1();
        Good2();
    }
#endif //omitgood
}
}
