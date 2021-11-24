/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE563_Assign_to_Variable_Without_Use__unused_init_variable_string_16.cs
Label Definition File: CWE563_Assign_to_Variable_Without_Use__unused_init_variable.label.xml
Template File: source-sinks-16.tmpl.cs
*/
/*
* @description
* CWE: 563 Assignment to Variable without Use
* BadSource:  Initialize data
* Sinks:
*    GoodSink: Use data
*    BadSink : do nothing
* Flow Variant: 16 Control flow: while(true)
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE563_Assign_to_Variable_Without_Use
{
class CWE563_Assign_to_Variable_Without_Use__unused_init_variable_string_16 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        string data;
        /* POTENTIAL FLAW: Initialize, but do not use data */
        data = "Good";
        while (true)
        {
            /* FLAW: Do not use the variable */
            /* do nothing */
            ; /* empty statement needed for some flow variants */
            break;
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodB2G() - use badsource and goodsink */
    private void GoodB2G()
    {
        string data;
        /* POTENTIAL FLAW: Initialize, but do not use data */
        data = "Good";
        while (true)
        {
            /* FIX: Use data */
            IO.WriteLine(data);
            break;
        }
    }

    public override void Good()
    {
        GoodB2G();
    }
#endif //omitgood
}
}
