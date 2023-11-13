using DemoExam.Model;
using System.Collections.Generic;
using System.Linq;

namespace DemoExam.Repository
{
    class RequestRepository
    {
        private readonly UserRepository userRepository = new();

        private readonly List<Request> requests = new()
        {
            new Request("Ноутбук Acer", Type.BrokenDisplay, "Сильно перегревается", new UserRepository().GetUserByLogin("client"))

        };

        public void AddRequest(Request request)
        {
            requests.Add(request);
        }

        public List<Request> GetRequestsByUserId(int id)
        {
            return requests.FindAll(it => it.Client.Id == id);
        }

        public void AssignExecutor(int requestId, int executorId)
        {

        } 

        public void ChangeRequestStatus(int requestId, int status)
        {

        }
    }
}
