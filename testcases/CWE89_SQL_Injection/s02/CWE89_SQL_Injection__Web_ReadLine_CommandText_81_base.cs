/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE89_SQL_Injection__Web_ReadLine_CommandText_81_base.cs
Label Definition File: CWE89_SQL_Injection__Web.label.xml
Template File: sources-sinks-81_base.tmpl.cs
*/
/*
 * @description
 * CWE: 89 SQL Injection
 * BadSource: ReadLine Read data from the console using ReadLine()
 * GoodSource: A hardcoded string
 * Sinks: CommandText
 *    GoodSink: Use prepared statement and concatenate CommandText (properly)
 *    BadSink : data concatenated into SQL statement used in CommandText, which could result in SQL Injection
 * Flow Variant: 81 Data flow: data passed in a parameter to an abstract method
 *
 * */

using TestCaseSupport;
using System;

using System.Data.SqlClient;
using System.Data;
using System.Web;

namespace testcases.CWE89_SQL_Injection
{
abstract class CWE89_SQL_Injection__Web_ReadLine_CommandText_81_base
{
    public abstract void Action(string data , HttpRequest req, HttpResponse resp);
}
}
