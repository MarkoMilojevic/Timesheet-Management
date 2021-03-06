﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TimesheetManagement.Data.EntityFramework.Entities;
using TimesheetManagement.Data.EntityFramework.Helpers;
using ClientDTO = TimesheetManagement.Data.Tasks.Entities.Client;

namespace TimesheetManagement.Data.EntityFramework.Repositories
{
    public class ClientRepository : EfRepository<ClientDTO, string>
    {
        public override ClientDTO Add(ClientDTO clientDto)
        {
            Client client = EfDtoMapper.CreateClient(clientDto);

            client = context.Clients.Add(client);
            context.SaveChanges();

            return EfDtoMapper.CreateClientDto(client);
        }

        public override bool Remove(ClientDTO clientDto)
        {
            Client client = context.Clients.Local.FirstOrDefault(c => c.TaxpayerIdentificationNumber == clientDto.TaxpayerIdentificationNumber);
            if (client == null)
            {
                client = EfDtoMapper.CreateClient(clientDto);
                context.Clients.Attach(client);
            }

            context.Clients.Remove(client);

            return context.SaveChanges() != 0;
        }

        public override bool Update(ClientDTO clientDto)
        {
            Client existingClient = context.Clients.FirstOrDefault(c => c.TaxpayerIdentificationNumber == clientDto.TaxpayerIdentificationNumber);
            if (existingClient == null)
            {
                return false;
            }

            context.Entry(existingClient).State = EntityState.Detached;

            Client updatedClient = EfDtoMapper.CreateClient(clientDto);
            context.Clients.Attach(updatedClient);
            context.Entry(updatedClient).State = EntityState.Modified;

            return context.SaveChanges() != 0;
        }

        public override ClientDTO Find(params string[] keys)
        {
            string clientId = keys[0];

            Client client = context.Clients.Find(clientId);

            return EfDtoMapper.CreateClientDto(client);
        }

        public override IEnumerable<ClientDTO> Find(Expression<Func<ClientDTO, bool>> predicate)
        {
            Expression<Func<Client, bool>> efPredicate = EfExpressionTransformer<ClientDTO, Client>.Tranform(predicate);

            return context.Clients
                .Where(efPredicate)
                .Select(EfDtoMapper.CreateClientDto);
        }

        public override IEnumerable<ClientDTO> FindAll()
        {
            return context.Clients.Select(EfDtoMapper.CreateClientDto);
        }
    }
}
