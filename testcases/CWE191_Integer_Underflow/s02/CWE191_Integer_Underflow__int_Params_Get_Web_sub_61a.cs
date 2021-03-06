/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE191_Integer_Underflow__int_Params_Get_Web_sub_61a.cs
Label Definition File: CWE191_Integer_Underflow__int.label.xml
Template File: sources-sinks-61a.tmpl.cs
*/
/*
 * @description
 * CWE: 191 Integer Underflow
 * BadSource: Params_Get_Web Read data from a querystring using Params.Get()
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: sub
 *    GoodSink: Ensure there will not be an underflow before subtracting 1 from data
 *    BadSink : Subtract 1 from data, which can cause an Underflow
 * Flow Variant: 61 Data flow: data returned from one method to another in different classes in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE191_Integer_Underflow
{
class CWE191_Integer_Underflow__int_Params_Get_Web_sub_61a : AbstractTestCaseWeb
{
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        int data = CWE191_Integer_Underflow__int_Params_Get_Web_sub_61b.BadSource(req, resp);
        /* POTENTIAL FLAW: if data == int.MinValue, this will overflow */
        int result = (int)(data - 1);
        IO.WriteLine("result: " + result);
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good(HttpRequest req, HttpResponse resp)
    {
        GoodG2B(req, resp);
        GoodB2G(req, resp);
    }

    /* goodG2B() - use goodsource and badsink */
    private static void GoodG2B(HttpRequest req, HttpResponse resp)
    {
        int data = CWE191_Integer_Underflow__int_Params_Get_Web_sub_61b.GoodG2BSource(req, resp);
        /* POTENTIAL FLAW: if data == int.MinValue, this will overflow */
        int result = (int)(data - 1);
        IO.WriteLine("result: " + result);
    }

    /* goodB2G() - use badsource and goodsink */
    private static void GoodB2G(HttpRequest req, HttpResponse resp)
    {
        int data = CWE191_Integer_Underflow__int_Params_Get_Web_sub_61b.GoodB2GSource(req, resp);
        /* FIX: Add a check to prevent an overflow from occurring */
        if (data > int.MinValue)
        {
            int result = (int)(data - 1);
            IO.WriteLine("result: " + result);
        }
        else
        {
            IO.WriteLine("data value is too small to perform subtraction.");
        }
    }
#endif //omitgood
}
}
