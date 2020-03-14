using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json;

namespace XUnitTest.Utilities
{
    public class Converter
    {
        public string LoadJson(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return json;
            }
        }
    }
}
