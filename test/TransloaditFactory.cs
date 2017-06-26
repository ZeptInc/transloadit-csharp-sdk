using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public static class TransloaditFactory
    {
        public static Transloadit.Transloadit CreateInstance()
        {
            return new Transloadit.Transloadit("YOUR-PUBLIC-API-KEY", "YOUR-SECRET-KEY");
        }
    }
}
