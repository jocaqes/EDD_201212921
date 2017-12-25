using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WelcomeWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NavalTest" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select NavalTest.svc or NavalTest.svc.cs at the Solution Explorer and start debugging.
    public class NavalTest : INavalTest
    {
        public string saludo()
        {
            return "hola mi amigo";
        }
    }
}
