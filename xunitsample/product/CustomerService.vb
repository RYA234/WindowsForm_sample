Imports System.Collections.Generic
Imports System.Data.Common

Public Class CustomerService
        Private ReadOnly _dbConnectionProvider As DbConnectionProvider

        Public Sub New(dbConnectionProvider As DbConnectionProvider)
            _dbConnectionProvider = dbConnectionProvider
            CreateCustomersTable()
        End Sub

        Public Function GetCustomers() As IEnumerable(Of Customer)
            Dim customers As IList(Of Customer) = New List(Of Customer)()

            Using connection = _dbConnectionProvider.GetConnection()
                Using command = connection.CreateCommand()
                    command.CommandText = "SELECT id, name FROM customers"
                    connection.Open()

                    Using dataReader = command.ExecuteReader()
                        While dataReader.Read()
                            Dim id = dataReader.GetInt64(0)
                            Dim name = dataReader.GetString(1)
                            customers.Add(New Customer(id, name))
                        End While
                    End Using
                End Using
            End Using

            Return customers
        End Function

        Public Sub Create(customer As Customer)
            Using connection = _dbConnectionProvider.GetConnection()
                Using command = connection.CreateCommand()
                    Dim id = command.CreateParameter()
                    id.ParameterName = "@id"
                    id.Value = customer.Id

                    Dim name = command.CreateParameter()
                    name.ParameterName = "@name"
                    name.Value = customer.Name

                    command.CommandText = "INSERT INTO customers (id, name) VALUES(@id, @name)"
                    command.Parameters.Add(id)
                    command.Parameters.Add(name)
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Private Sub CreateCustomersTable()
            Using connection = _dbConnectionProvider.GetConnection()
                Using command = connection.CreateCommand()
                command.CommandText =
                        "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'customers') BEGIN CREATE TABLE customers (id BIGINT NOT NULL, name VARCHAR(255) NOT NULL, PRIMARY KEY (id)) END"
                connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        End Sub
    End Class
