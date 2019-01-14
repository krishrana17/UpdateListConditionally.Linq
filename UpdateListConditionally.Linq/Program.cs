using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace UpdateListConditionally.Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringContent =
                @"
                MSH|^~\&|MyLAB|EMR||MyLAB|201412200943||ORU^R01|20141220094|P|2.4
                PID|1||5266||Test^Mouse^||20001218|F|||^^^^||||||||
                PV1|1||^^^MyLAB^Test Laboratories||||9999999999^DOCTOR^LAB|9999999999^DOCTOR^LABDAQ|||||
                ORC|RE||13461||||||201412181208|KJ||9999999999^DOCTOR^LAB^^^^^N|^^^MyLAB^Test Laboratories||||EMR^Test Laboratories
                NTE|1|L|
                ZEF|1|JVBERi0xLjQKJeLjz9MKMSAwIG9iago8PC9QYXJlbnQgNCAwIFIvTWVkaWFCb3hbMCAwIDYxMiA3OTJdL0Nyb3BCb3hbMCAwIDYxMiA3OTJdL1Jlc291cmNlcyA1IDAgUi9UeXBlL1BhZ2UvQ29udGVudHMgMjIgMCBSPj4KZW5kb2JqCjYgMCBvYmoKPDwvVHlwZS9YT2JqZWN0L1N1YnR5cGUvSW1hZ2UvV2lkdGggMTAwMDAvSGVpZ2h0IDExOTcvQ29sb3JTcGFjZS9EZXZpY2VSR0IvQml0c1BlckNvbXBvbmVudCA4L0RlY29kZVswIDEgMCAxIDAgM";

            // Split the string
            List<string> allSegments = stringContent.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            // Calling our generic method
            allSegments = allSegments.ConditionalUpdate(s => s.IndexOf("ZEF|1|") >= 0, s => s.Substring(0, 30)).ToList();

            // write the output in the console.
            //allSegments.ForEach(WriteLine);   // <= You can use this line to write output in console.
            allSegments.ForEach(s => WriteLine(s.Trim()));  // <= I have used this line just to remove the whitespace. Above line is also valid.
            ReadLine();
        }
    }
}
