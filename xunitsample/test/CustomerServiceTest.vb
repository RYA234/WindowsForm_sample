Imports System.Threading.Tasks
Imports Xunit
Imports Testcontainers.PostgreSql
Imports Testcontainers.MsSql


Public Class CustomerServiceTest
    Implements IAsyncLifetime

    Private ReadOnly _sqlServer As MsSqlContainer = New MsSqlBuilder().Build()

    Public Function InitializeAsync() As Task Implements IAsyncLifetime.InitializeAsync
        Return _sqlServer.StartAsync()
    End Function

    Public Function DisposeAsync() As Task Implements IAsyncLifetime.DisposeAsync
        Return _sqlServer.DisposeAsync().AsTask()
    End Function

    <Fact>
    Public Sub ShouldReturnTwoCustomers()

        ' Given
        Dim provider As New DbConnectionProvider(_sqlServer.GetConnectionString())
        Dim customerService As New CustomerService(provider)

        ' When
        customerService.Create(New Customer(1, "George"))
        customerService.Create(New Customer(2, "John"))
        Dim customers = customerService.GetCustomers()

        ' Then
        Assert.Equal(2, customers.Count())
    End Sub

End Class

