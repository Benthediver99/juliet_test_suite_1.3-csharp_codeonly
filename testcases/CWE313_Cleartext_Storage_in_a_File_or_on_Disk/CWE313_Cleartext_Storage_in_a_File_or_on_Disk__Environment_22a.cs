/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE313_Cleartext_Storage_in_a_File_or_on_Disk__Environment_22a.cs
Label Definition File: CWE313_Cleartext_Storage_in_a_File_or_on_Disk.label.xml
Template File: sources-sinks-22a.tmpl.cs
*/
/*
 * @description
 * CWE: 313 Cleartext storage in a File or on Disk
 * BadSource: Environment Read data from an environment variable
 * GoodSource: A hardcoded string
 * Sinks:
 *    GoodSink: Hash data before storing in registry
 *    BadSink : Store data directly in a file
 * Flow Variant: 22 Control flow: Flow controlled by value of a public static variable. Sink functions are in a separate file from sources.
 *
 * */

using TestCaseSupport;
using System;

using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Web;

namespace testcases.CWE313_Cleartext_Storage_in_a_File_or_on_Disk
{
class CWE313_Cleartext_Storage_in_a_File_or_on_Disk__Environment_22a : AbstractTestCase
{

    /* The public static variable below is used to drive control flow in the sink function. */
    public static bool badPublicStatic = false;
#if (!OMITBAD)
    public override void Bad()
    {
        string data = null;
        /* get environment variable ADD */
        /* POTENTIAL FLAW: Read data from an environment variable */
        data = Environment.GetEnvironmentVariable("ADD");
        badPublicStatic = true;
        CWE313_Cleartext_Storage_in_a_File_or_on_Disk__Environment_22b.BadSink(data );
    }
#endif //omitbad
    /* The public static variables below are used to drive control flow in the sink functions. */
    public static bool goodB2G1PublicStatic = false;
    public static bool goodB2G2PublicStatic = false;
    public static bool goodG2BPublicStatic = false;
#if (!OMITGOOD)
    public override void Good()
    {
        GoodB2G1();
        GoodB2G2();
        GoodG2B();
    }

    /* goodB2G1() - use badsource and goodsink by setting the static variable to false instead of true */
    private void GoodB2G1()
    {
        string data = null;
        /* get environment variable ADD */
        /* POTENTIAL FLAW: Read data from an environment variable */
        data = Environment.GetEnvironmentVariable("ADD");
        goodB2G1PublicStatic = false;
        CWE313_Cleartext_Storage_in_a_File_or_on_Disk__Environment_22b.GoodB2G1Sink(data );
    }

    /* goodB2G2() - use badsource and goodsink by reversing the blocks in the if in the sink function */
    private void GoodB2G2()
    {
        string data = null;
        /* get environment variable ADD */
        /* POTENTIAL FLAW: Read data from an environment variable */
        data = Environment.GetEnvironmentVariable("ADD");
        goodB2G2PublicStatic = true;
        CWE313_Cleartext_Storage_in_a_File_or_on_Disk__Environment_22b.GoodB2G2Sink(data );
    }

    /* goodG2B() - use goodsource and badsink */
    private void GoodG2B()
    {
        string data = null;
        /* FIX: Use a hardcoded string */
        data = "foo";
        goodG2BPublicStatic = true;
        CWE313_Cleartext_Storage_in_a_File_or_on_Disk__Environment_22b.GoodG2BSink(data );
    }
#endif //omitgood
}
}
