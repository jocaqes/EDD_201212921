using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceClasses" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceClasses.svc or ServiceClasses.svc.cs at the Solution Explorer and start debugging.
    public class ServiceClasses : IServiceClasses
    {
        public int getFactorial(int numero)
        {
            return new Persona().factorial(numero);
        }

        public Persona getPersona(string nombre, int edad, string mail)
        {
            return new Persona(nombre, edad, mail);
        }
    }
}
