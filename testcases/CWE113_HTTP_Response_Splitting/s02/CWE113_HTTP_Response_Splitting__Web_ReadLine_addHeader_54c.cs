/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE113_HTTP_Response_Splitting__Web_ReadLine_addHeader_54c.cs
Label Definition File: CWE113_HTTP_Response_Splitting__Web.label.xml
Template File: sources-sinks-54c.tmpl.cs
*/
/*
 * @description
 * CWE: 113 HTTP Response Splitting
 * BadSource: ReadLine Read data from the console using ReadLine()
 * GoodSource: A hardcoded string
 * Sinks: addHeader
 *    GoodSink: URLEncode input
 *    BadSink : querystring to AddHeader()
 * Flow Variant: 54 Data flow: data passed as an argument from one method through three others to a fifth; all five functions are in different classes in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Web;
using System.Text;

namespace testcases.CWE113_HTTP_Response_Splitting
{
class CWE113_HTTP_Response_Splitting__Web_ReadLine_addHeader_54c
{
#if (!OMITBAD)
    public static void BadSink(string data , HttpRequest req, HttpResponse resp)
    {
        CWE113_HTTP_Response_Splitting__Web_ReadLine_addHeader_54d.BadSink(data , req, resp);
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(string data , HttpRequest req, HttpResponse resp)
    {
        CWE113_HTTP_Response_Splitting__Web_ReadLine_addHeader_54d.GoodG2BSink(data , req, resp);
    }

    /* goodB2G() - use badsource and goodsink */
    public static void GoodB2GSink(string data , HttpRequest req, HttpResponse resp)
    {
        CWE113_HTTP_Response_Splitting__Web_ReadLine_addHeader_54d.GoodB2GSink(data , req, resp);
    }
#endif
}
}
