/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE511_Logic_Time_Bomb__counter_13.cs
Label Definition File: CWE511_Logic_Time_Bomb.label.xml
Template File: point-flaw-13.tmpl.cs
*/
/*
* @description
* CWE: 511 Logic Time Bomb
* Sinks: counter
*    GoodSink: If counter reaches a certain value, print to the console
*    BadSink : If counter reaches a certain value, launch an executable
* Flow Variant: 13 Control flow: if(IO.STATIC_READONLY_FIVE==5) and if(IO.STATIC_READONLY_FIVE!=5)
*
* */

using TestCaseSupport;
using System;

using System.Diagnostics;

namespace testcases.CWE511_Logic_Time_Bomb
{
class CWE511_Logic_Time_Bomb__counter_13 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.STATIC_READONLY_FIVE == 5)
        {
            int count = 0;
            do
            {
                /* FLAW: counter triggered backdoor */
                if (count == 20000)
                {
                    using (Process myProcess = new Process())
                    {
                        myProcess.StartInfo.UseShellExecute = false;
                        myProcess.StartInfo.FileName = "c:\\windows\\system32\\evil.exe";
                        myProcess.Start();
                    }
                }
                count++;
            }
            while (count < int.MaxValue);
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes IO.STATIC_READONLY_FIVE==5 to IO.STATIC_READONLY_FIVE!=5 */
    private void Good1()
    {
        if (IO.STATIC_READONLY_FIVE != 5)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            int count = 0;
            do
            {
                /* FIX: no backdoor exists */
                if (count == 20000)
                {
                    IO.WriteLine("Sorry, your license has expired.  Please contact support.");
                }
                count++;
            }
            while (count < int.MaxValue);
        }
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (IO.STATIC_READONLY_FIVE == 5)
        {
            int count = 0;
            do
            {
                /* FIX: no backdoor exists */
                if (count == 20000)
                {
                    IO.WriteLine("Sorry, your license has expired.  Please contact support.");
                }
                count++;
            }
            while (count < int.MaxValue);
        }
    }

    public override void Good()
    {
        Good1();
        Good2();
    }
#endif //omitgood
}
}
