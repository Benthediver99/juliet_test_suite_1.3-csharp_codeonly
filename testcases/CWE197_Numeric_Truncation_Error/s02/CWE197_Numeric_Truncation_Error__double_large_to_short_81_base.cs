/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE197_Numeric_Truncation_Error__double_large_to_short_81_base.cs
Label Definition File: CWE197_Numeric_Truncation_Error__double.label.xml
Template File: sources-sink-81_base.tmpl.cs
*/
/*
 * @description
 * CWE: 197 Numeric Truncation Error
 * BadSource: large Set data to a number larger than float.MaxValue
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: to_short
 *    BadSink : Convert data to a short
 * Flow Variant: 81 Data flow: data passed in a parameter to an abstract method
 *
 * */

using TestCaseSupport;
using System;

namespace testcases.CWE197_Numeric_Truncation_Error
{
abstract class CWE197_Numeric_Truncation_Error__double_large_to_short_81_base
{
    public abstract void Action(double data );
}
}
