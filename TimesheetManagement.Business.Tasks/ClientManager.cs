using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TimesheetManagement.Business.Interfaces;
using TimesheetManagement.Business.Tasks.Entities;
using TimesheetManagement.Business.Tasks.Helpers;
using TimesheetManagement.Data.Interfaces;
using ClientDTO = TimesheetManagement.Data.Tasks.Entities.Client;

namespace TimesheetManagement.Business.Tasks.Managers
{
    public class ClientManager : IManager<Client, string>
    {
        private readonly IRepository<ClientDTO, string> clientRepository;

        public ClientManager(IRepository<ClientDTO, string> clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public Client Add(Client client)
        {
            ClientDTO clientDto = TasksBoMapper.CreateClientDto(client);

            clientDto = clientRepository.Add(clientDto);

            return TasksBoMapper.CreateClient(clientDto);
        }

        public bool Remove(Client client)
        {
            ClientDTO clientDto = TasksBoMapper.CreateClientDto(client);

            return clientRepository.Remove(clientDto);
        }

        public bool Update(Client client)
        {
            ClientDTO clientDto = TasksBoMapper.CreateClientDto(client);

            return clientRepository.Update(clientDto);
        }

        public Client Find(params string[] keys)
        {
            ClientDTO clientDto = clientRepository.Find(keys);

            return TasksBoMapper.CreateClient(clientDto);
        }

        public IEnumerable<Client> Find(Expression<Func<Client, bool>> predicate)
        {
            Expression<Func<ClientDTO, bool>> dataPredicate = TasksExpressionTransformer<Client, ClientDTO>.Tranform(predicate);

            return clientRepository.Find(dataPredicate).Select(TasksBoMapper.CreateClient);
        }

        public IEnumerable<Client> FindAll()
        {
            return clientRepository.FindAll().Select(TasksBoMapper.CreateClient);
        }
    }
}