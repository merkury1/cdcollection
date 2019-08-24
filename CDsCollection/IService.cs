using CDsCollection.Model;
using System.Collections.Generic;
using System.ServiceModel;

namespace CDsCollection
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        List<CD> GetCDCollection();
    }
}
