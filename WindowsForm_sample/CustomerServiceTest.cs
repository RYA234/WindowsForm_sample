﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Testcontainers.PostgreSql;

namespace WindowsForm_sample
{
    public class CustomerServiceTest : IAsyncLifetime
    {
        public readonly PostgreSqlContainer _postgres = new PostgreSqlBuilder()
            .WithImage("postgres:15-alpine").Build();


        public Task InitializeAsync()
        {
            return _postgres.StartAsync();
        }

        public Task DisposeAsync()
        {
            return _postgres.DisposeAsync().AsTask();
        }

        [Fact]
        public void ShouldReturnTwoCustomers()
        {
            // Given  

            var customerService = new CustomerService(new DbConnectionProvider(_postgres.GetConnectionString()));

            // When  
            customerService.Create(new Customer(1, "George"));
            customerService.Create(new Customer(2, "John"));
            var customers = customerService.GetCustomers();

            // Then  
            Assert.Equal(2, customers.Count());
        }
    }
}
