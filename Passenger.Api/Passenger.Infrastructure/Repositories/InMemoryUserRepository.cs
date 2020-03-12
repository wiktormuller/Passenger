﻿using Passenger.Core.Repositories;
using Passenger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>()
        {
            new User("user1@email.com", "user1", "secret", "salt"),
            new User("user2@email.com", "user2", "secret", "salt"),
            new User("user3@email.com", "user3", "secret", "salt")
        };

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User Get(Guid id)
        {
            return _users.Where(x => x.Id == id).FirstOrDefault();
        }

        public User Get(string email)
        {
            return _users.Where(x => x.Email == email.ToLowerInvariant()).FirstOrDefault();
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public void Remove(Guid id)
        {
            var user = Get(id); //USER EXISTS?
            _users.Remove(user);
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
