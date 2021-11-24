/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE369_Divide_by_Zero__float_database_modulo_12.cs
Label Definition File: CWE369_Divide_by_Zero__float.label.xml
Template File: sources-sinks-12.tmpl.cs
*/
/*
* @description
* CWE: 369 Divide by zero
* BadSource: database Read data from a database
* GoodSource: A hardcoded non-zero number (two)
* Sinks: modulo
*    GoodSink: Check for zero before modulo
*    BadSink : Modulo by a value that may be zero
* Flow Variant: 12 Control flow: if(IO.StaticReturnsTrueOrFalse())
*
* */

using TestCaseSupport;
using System;

using System.Web;

using System.Data.SqlClient;

namespace testcases.CWE369_Divide_by_Zero
{
class CWE369_Divide_by_Zero__float_database_modulo_12 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        float data;
        if(IO.StaticReturnsTrueOrFalse())
        {
            data = -1.0f; /* Initialize data */
            /* Read data from a database */
            {
                try
                {
                    /* setup the connection */
                    using (SqlConnection connection = IO.GetDBConnection())
                    {
                        connection.Open();
                        /* prepare and execute a (hardcoded) query */
                        using (SqlCommand command = new SqlCommand(null, connection))
                        {
                            command.CommandText = "select name from users where id=0";
                            command.Prepare();
                            using (SqlDataReader dr = command.ExecuteReader())
                            {
                                /* POTENTIAL FLAW: Read data from a database query SqlDataReader */
                                string stringNumber = dr.GetString(1);
                                if (stringNumber != null) /* avoid NPD incidental warnings */
                                {
                                    try
                                    {
                                        data = int.Parse(stringNumber.Trim());
                                    }
                                    catch (FormatException exceptNumberFormat)
                                    {
                                        IO.Logger.Log(NLog.LogLevel.Warn, exceptNumberFormat, "Number format exception parsing data from string");
                                    }
                                }
                            }
                        }
                    }
                }
                catch (SqlException exceptSql)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptSql, "Error with SQL statement");
                }
            }
        }
        else
        {
            /* FIX: Use a hardcoded number that won't a divide by zero */
            data = 2.0f;
        }
        if(IO.StaticReturnsTrueOrFalse())
        {
            /* POTENTIAL FLAW: Possibly modulo by zero */
            int result = (int)(100.0 % data);
            IO.WriteLine(result);
        }
        else
        {
            /* FIX: Check for value of or near zero before modulo */
            if (Math.Abs(data) > 0.000001)
            {
                int result = (int)(100.0 % data);
                IO.WriteLine(result);
            }
            else
            {
                IO.WriteLine("This would result in a modulo by zero");
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink by changing the first "if" so that
     * both branches use the GoodSource */
    private void GoodG2B()
    {
        float data;
        if(IO.StaticReturnsTrueOrFalse())
        {
            /* FIX: Use a hardcoded number that won't a divide by zero */
            data = 2.0f;
        }
        else
        {
            /* FIX: Use a hardcoded number that won't a divide by zero */
            data = 2.0f;
        }
        if(IO.StaticReturnsTrueOrFalse())
        {
            /* POTENTIAL FLAW: Possibly modulo by zero */
            int result = (int)(100.0 % data);
            IO.WriteLine(result);
        }
        else
        {
            /* POTENTIAL FLAW: Possibly modulo by zero */
            int result = (int)(100.0 % data);
            IO.WriteLine(result);
        }
    }

    /* goodB2G() - use badsource and goodsink by changing the second "if" so that
     * both branches use the GoodSink */
    private void GoodB2G()
    {
        float data;
        if(IO.StaticReturnsTrueOrFalse())
        {
            data = -1.0f; /* Initialize data */
            /* Read data from a database */
            {
                try
                {
                    /* setup the connection */
                    using (SqlConnection connection = IO.GetDBConnection())
                    {
                        connection.Open();
                        /* prepare and execute a (hardcoded) query */
                        using (SqlCommand command = new SqlCommand(null, connection))
                        {
                            command.CommandText = "select name from users where id=0";
                            command.Prepare();
                            using (SqlDataReader dr = command.ExecuteReader())
                            {
                                /* POTENTIAL FLAW: Read data from a database query SqlDataReader */
                                string stringNumber = dr.GetString(1);
                                if (stringNumber != null) /* avoid NPD incidental warnings */
                                {
                                    try
                                    {
                                        data = int.Parse(stringNumber.Trim());
                                    }
                                    catch (FormatException exceptNumberFormat)
                                    {
                                        IO.Logger.Log(NLog.LogLevel.Warn, exceptNumberFormat, "Number format exception parsing data from string");
                                    }
                                }
                            }
                        }
                    }
                }
                catch (SqlException exceptSql)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptSql, "Error with SQL statement");
                }
            }
        }
        else
        {
            data = -1.0f; /* Initialize data */
            /* Read data from a database */
            {
                try
                {
                    /* setup the connection */
                    using (SqlConnection connection = IO.GetDBConnection())
                    {
                        connection.Open();
                        /* prepare and execute a (hardcoded) query */
                        using (SqlCommand command = new SqlCommand(null, connection))
                        {
                            command.CommandText = "select name from users where id=0";
                            command.Prepare();
                            using (SqlDataReader dr = command.ExecuteReader())
                            {
                                /* POTENTIAL FLAW: Read data from a database query SqlDataReader */
                                string stringNumber = dr.GetString(1);
                                if (stringNumber != null) /* avoid NPD incidental warnings */
                                {
                                    try
                                    {
                                        data = int.Parse(stringNumber.Trim());
                                    }
                                    catch (FormatException exceptNumberFormat)
                                    {
                                        IO.Logger.Log(NLog.LogLevel.Warn, exceptNumberFormat, "Number format exception parsing data from string");
                                    }
                                }
                            }
                        }
                    }
                }
                catch (SqlException exceptSql)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptSql, "Error with SQL statement");
                }
            }
        }
        if(IO.StaticReturnsTrueOrFalse())
        {
            /* FIX: Check for value of or near zero before modulo */
            if (Math.Abs(data) > 0.000001)
            {
                int result = (int)(100.0 % data);
                IO.WriteLine(result);
            }
            else
            {
                IO.WriteLine("This would result in a modulo by zero");
            }
        }
        else
        {
            /* FIX: Check for value of or near zero before modulo */
            if (Math.Abs(data) > 0.000001)
            {
                int result = (int)(100.0 % data);
                IO.WriteLine(result);
            }
            else
            {
                IO.WriteLine("This would result in a modulo by zero");
            }
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
