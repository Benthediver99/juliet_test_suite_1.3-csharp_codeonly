/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE690_NULL_Deref_From_Return__Class_string_42.cs
Label Definition File: CWE690_NULL_Deref_From_Return__Class.label.xml
Template File: sources-sinks-42.tmpl.cs
*/
/*
 * @description
 * CWE: 690 Unchecked return value is null, leading to a null pointer dereference.
 * BadSource:  Use a custom method which may return null
 * GoodSource: Use a custom method that never returns null
 * Sinks: trim
 *    GoodSink: Check data for null before calling trim()
 *    BadSink : Call trim() on possibly null object
 * Flow Variant: 42 Data flow: data returned from one method to another in the same class
 *
 * */

using TestCaseSupport;
using System;

using System.Text;

namespace testcases.CWE690_NULL_Deref_From_Return
{
class CWE690_NULL_Deref_From_Return__Class_string_42 : AbstractTestCase
{
#if (!OMITBAD)
    private static String BadSource()
    {
        String data;
        /* POTENTIAL FLAW: Call getStringBad(), which may return null */
        data = CWE690_NULL_Deref_From_Return__Class_Helper.getStringBad();
        return data;
    }

    public override void Bad()
    {
        String data = BadSource();
        /* POTENTIAL FLAW: data could be null */
        string stringTrimmed = data.Trim();
        IO.WriteLine(stringTrimmed);
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    private static String GoodG2BSource()
    {
        String data;
        /* FIX: call getStringGood(), which will never return null */
        data = CWE690_NULL_Deref_From_Return__Class_Helper.getStringGood();
        return data;
    }

    private static void GoodG2B()
    {
        String data = GoodG2BSource();
        /* POTENTIAL FLAW: data could be null */
        string stringTrimmed = data.Trim();
        IO.WriteLine(stringTrimmed);
    }

    /* goodB2G() - use badsource and goodsink */
    private static String GoodB2GSource()
    {
        String data;
        /* POTENTIAL FLAW: Call getStringBad(), which may return null */
        data = CWE690_NULL_Deref_From_Return__Class_Helper.getStringBad();
        return data;
    }

    private static void GoodB2G()
    {
        String data = GoodB2GSource();
        /* FIX: explicit check for null */
        if (data != null)
        {
            string stringTrimmed = data.Trim();
            IO.WriteLine(stringTrimmed);
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
