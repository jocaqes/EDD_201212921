using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WelcomeWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INavalTest" in both code and config file together.
    [ServiceContract]
    public interface INavalTest
    {
        [OperationContract]
        string saludo();

    }
}
