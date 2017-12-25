using System.ServiceModel;

namespace TestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceClasses" in both code and config file together.
    [ServiceContract]
    public interface IServiceClasses
    {
        [OperationContract]
        Persona getPersona(string nombre, int edad, string mail);
        [OperationContract]
        int getFactorial(int numero);
    }
}
