/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE563_Assign_to_Variable_Without_Use__unused_value_string_16.cs
Label Definition File: CWE563_Assign_to_Variable_Without_Use__unused_value.label.xml
Template File: sources-sinks-16.tmpl.cs
*/
/*
* @description
* CWE: 563 Assignment to Variable without Use
* BadSource:  Initialize data
* GoodSource: Initialize and use data
* Sinks:
*    GoodSink: Use data
*    BadSink : re-initialize and use data
* Flow Variant: 16 Control flow: while(true)
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE563_Assign_to_Variable_Without_Use
{
class CWE563_Assign_to_Variable_Without_Use__unused_value_string_16 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        string data;
        while (true)
        {
            /* POTENTIAL FLAW: Initialize, but do not use data */
            data = "Good";
            break;
        }
        while (true)
        {
            /* POTENTIAL FLAW: Possibly over-write the initial value of data before using it */
            data = "Reinitialize";
            IO.WriteLine(data);
            break;
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    private void GoodG2B()
    {
        string data;
        while (true)
        {
            /* FIX: Initialize and use data before it is overwritten */
            data = "Good";
            IO.WriteLine(data);
            break;
        }
        while (true)
        {
            /* POTENTIAL FLAW: Possibly over-write the initial value of data before using it */
            data = "Reinitialize";
            IO.WriteLine(data);
            break;
        }
    }

    /* goodB2G() - use badsource and goodsink */
    private void GoodB2G()
    {
        string data;
        while (true)
        {
            /* POTENTIAL FLAW: Initialize, but do not use data */
            data = "Good";
            break;
        }
        while (true)
        {
            /* FIX: Use data without over-writing its value */
            IO.WriteLine(data);
            break;
        }
    }

    public override void Good()
    {
        GoodG2B();
        GoodB2G();
    }
#endif //omitgood
}
}
