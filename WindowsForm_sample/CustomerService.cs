﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using Npgsql;


namespace WindowsForm_sample
{
    public class CustomerService
    {
        private readonly DbConnectionProvider _dbConnectionProvider;

        public CustomerService(DbConnectionProvider dbConnectionProvider)
        {
            _dbConnectionProvider = dbConnectionProvider;
            CreateCustomersTable();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            IList<Customer> customers = new List<Customer>();

            using (var connection = _dbConnectionProvider.GetConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT id, name FROM customers";
                    connection.Open();

                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            var id = dataReader.GetInt64(0);
                            var name = dataReader.GetString(1);
                            customers.Add(new Customer(id, name));
                        }
                    }
                }
            }

            return customers;
        }

        public void Create(Customer customer)
        {
            using (var connection = _dbConnectionProvider.GetConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    var id = command.CreateParameter();
                    id.ParameterName = "@id";
                    id.Value = customer.Id;

                    var name = command.CreateParameter();
                    name.ParameterName = "@name";
                    name.Value = customer.Name;

                    command.CommandText = "INSERT INTO customers (id, name) VALUES(@id, @name)";
                    command.Parameters.Add(id);
                    command.Parameters.Add(name);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void CreateCustomersTable()
        {
            using (var connection = _dbConnectionProvider.GetConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "CREATE TABLE IF NOT EXISTS customers (id BIGINT NOT NULL, name VARCHAR NOT NULL, PRIMARY KEY (id))";
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
