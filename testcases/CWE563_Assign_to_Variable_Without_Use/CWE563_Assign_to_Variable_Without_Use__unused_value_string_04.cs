/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE563_Assign_to_Variable_Without_Use__unused_value_string_04.cs
Label Definition File: CWE563_Assign_to_Variable_Without_Use__unused_value.label.xml
Template File: sources-sinks-04.tmpl.cs
*/
/*
* @description
* CWE: 563 Assignment to Variable without Use
* BadSource:  Initialize data
* GoodSource: Initialize and use data
* Sinks:
*    GoodSink: Use data
*    BadSink : re-initialize and use data
* Flow Variant: 04 Control flow: if(PRIVATE_CONST_TRUE) and if(PRIVATE_CONST_FALSE)
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE563_Assign_to_Variable_Without_Use
{
class CWE563_Assign_to_Variable_Without_Use__unused_value_string_04 : AbstractTestCase
{

    /* The two variables below are declared "const", so a tool should
     * be able to identify that reads of these will always return their
     * initialized values.
     */
    private const bool PRIVATE_CONST_TRUE = true;
    private const bool PRIVATE_CONST_FALSE = false;
#if (!OMITBAD)
    public override void Bad()
    {
        string data;
        if (PRIVATE_CONST_TRUE)
        {
            /* POTENTIAL FLAW: Initialize, but do not use data */
            data = "Good";
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        if (PRIVATE_CONST_TRUE)
        {
            /* POTENTIAL FLAW: Possibly over-write the initial value of data before using it */
            data = "Reinitialize";
            IO.WriteLine(data);
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B1() - use goodsource and badsink by changing first PRIVATE_CONST_TRUE to PRIVATE_CONST_FALSE */
    private void GoodG2B1()
    {
        string data;
        if (PRIVATE_CONST_FALSE)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        else
        {
            /* FIX: Initialize and use data before it is overwritten */
            data = "Good";
            IO.WriteLine(data);
        }
        if (PRIVATE_CONST_TRUE)
        {
            /* POTENTIAL FLAW: Possibly over-write the initial value of data before using it */
            data = "Reinitialize";
            IO.WriteLine(data);
        }
    }

    /* GoodG2B2() - use goodsource and badsink by reversing statements in first if */
    private void GoodG2B2()
    {
        string data;
        if (PRIVATE_CONST_TRUE)
        {
            /* FIX: Initialize and use data before it is overwritten */
            data = "Good";
            IO.WriteLine(data);
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        if (PRIVATE_CONST_TRUE)
        {
            /* POTENTIAL FLAW: Possibly over-write the initial value of data before using it */
            data = "Reinitialize";
            IO.WriteLine(data);
        }
    }

    /* goodB2G1() - use badsource and goodsink by changing second PRIVATE_CONST_TRUE to PRIVATE_CONST_FALSE */
    private void GoodB2G1()
    {
        string data;
        if (PRIVATE_CONST_TRUE)
        {
            /* POTENTIAL FLAW: Initialize, but do not use data */
            data = "Good";
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        if (PRIVATE_CONST_FALSE)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            /* FIX: Use data without over-writing its value */
            IO.WriteLine(data);
        }
    }

    /* goodB2G2() - use badsource and goodsink by reversing statements in second if  */
    private void GoodB2G2()
    {
        string data;
        if (PRIVATE_CONST_TRUE)
        {
            /* POTENTIAL FLAW: Initialize, but do not use data */
            data = "Good";
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        if (PRIVATE_CONST_TRUE)
        {
            /* FIX: Use data without over-writing its value */
            IO.WriteLine(data);
        }
    }

    public override void Good()
    {
        GoodG2B1();
        GoodG2B2();
        GoodB2G1();
        GoodB2G2();
    }
#endif //omitgood
}
}
