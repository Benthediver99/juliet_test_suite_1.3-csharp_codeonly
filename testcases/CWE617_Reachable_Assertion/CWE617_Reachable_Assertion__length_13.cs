/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE617_Reachable_Assertion__length_13.cs
Label Definition File: CWE617_Reachable_Assertion.label.xml
Template File: point-flaw-13.tmpl.cs
*/
/*
* @description
* CWE: 617 Assertion is reachable
* Sinks: length
*    GoodSink: assert true, which will never trigger
*    BadSink : assert false, which will always trigger
* Flow Variant: 13 Control flow: if(IO.STATIC_READONLY_FIVE==5) and if(IO.STATIC_READONLY_FIVE!=5)
*
* */

using TestCaseSupport;
using System;

using System.Diagnostics;

namespace testcases.CWE617_Reachable_Assertion
{
class CWE617_Reachable_Assertion__length_13 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.STATIC_READONLY_FIVE == 5)
        {
            /* FLAW: assertion is false */
            Trace.Assert("".Length > 0);
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes IO.STATIC_READONLY_FIVE==5 to IO.STATIC_READONLY_FIVE!=5 */
    private void Good1()
    {
        if (IO.STATIC_READONLY_FIVE != 5)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            /* FIX: assertion is true */
            Trace.Assert("cwe617".Length > 0);
        }
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (IO.STATIC_READONLY_FIVE == 5)
        {
            /* FIX: assertion is true */
            Trace.Assert("cwe617".Length > 0);
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
