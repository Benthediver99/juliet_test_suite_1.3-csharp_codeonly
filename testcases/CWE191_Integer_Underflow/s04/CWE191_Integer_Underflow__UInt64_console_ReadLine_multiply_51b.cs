/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE191_Integer_Underflow__UInt64_console_ReadLine_multiply_51b.cs
Label Definition File: CWE191_Integer_Underflow.label.xml
Template File: sources-sinks-51b.tmpl.cs
*/
/*
 * @description
 * CWE: 191 Integer Underflow
 * BadSource: console_ReadLine Read data from the console using ReadLine
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: multiply
 *    GoodSink: Ensure there will not be an underflow before multiplying data by 2
 *    BadSink : If data is negative, multiply by 2, which can cause an underflow
 * Flow Variant: 51 Data flow: data passed as an argument from one function to another in different classes in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE191_Integer_Underflow
{
class CWE191_Integer_Underflow__UInt64_console_ReadLine_multiply_51b
{
#if (!OMITBAD)
    public static void BadSink(ulong data )
    {
        if(data < 0) /* ensure we won't have an overflow */
        {
            /* POTENTIAL FLAW: if (data * 2) < ulong.MinValue, this will underflow */
            ulong result = (ulong)(data * 2);
            IO.WriteLine("result: " + result);
        }
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(ulong data )
    {
        if(data < 0) /* ensure we won't have an overflow */
        {
            /* POTENTIAL FLAW: if (data * 2) < ulong.MinValue, this will underflow */
            ulong result = (ulong)(data * 2);
            IO.WriteLine("result: " + result);
        }
    }

    /* goodB2G() - use badsource and goodsink */
    public static void GoodB2GSink(ulong data )
    {
        if(data < 0) /* ensure we won't have an overflow */
        {
            /* FIX: Add a check to prevent an underflow from occurring */
            if (data > (ulong.MinValue/2))
            {
                ulong result = (ulong)(data * 2);
                IO.WriteLine("result: " + result);
            }
            else
            {
                IO.WriteLine("data value is too small to perform multiplication.");
            }
        }
    }
#endif
}
}
