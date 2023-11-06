using DemoExam.Model;
using System.Collections.Generic;

namespace DemoExam.Repository
{
    class RequestRepository
    {
        private readonly List<Request> requests = new List<Request>();

        public void AddRequest(Request request)
        {
            requests.Add(request);
        }

        public List<Request> GetRequestsByUserId(int id)
        {
            return requests.FindAll(it => it.Client.Id == id);
        }
    }
}
