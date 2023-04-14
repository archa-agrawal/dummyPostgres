using Npgsql;

var con = new NpgsqlConnection(
    connectionString: "Server=localhost;Port=55000;User Id=postgres;Password=postgrespw;Database=testdb;");
con.Open();
using var cmd = new NpgsqlCommand();
cmd.Connection = con;

cmd.CommandText = $"DROP TABLE IF EXISTS teachers";
await cmd.ExecuteNonQueryAsync();
cmd.CommandText = "CREATE TABLE teachers (id SERIAL PRIMARY KEY," +
    "first_name VARCHAR(255)," +
    "last_name VARCHAR(255)," +
    "subject VARCHAR(255)," +
    "salary INT)";
await cmd.ExecuteNonQueryAsync();

cmd.CommandText = $"INSERT INTO teachers (first_name, last_name, subject, salary) VALUES ('Severus', 'Snape', 'Potions', 10000)";
await cmd.ExecuteNonQueryAsync();

cmd.CommandText = $"INSERT INTO TEACHERS (first_name, last_name, subject, salary) VALUES (@firstName, @lastName, @subject, @salary)";
cmd.Parameters.AddWithValue("firstName", "Albus");
cmd.Parameters.AddWithValue("lastName", "Dumbledore");
cmd.Parameters.AddWithValue("subject", "DADA");
cmd.Parameters.AddWithValue("salary", 100000);
await cmd.ExecuteNonQueryAsync();

/*
cmd.CommandText = $"UPDATE teachers" +
    $"SET first_name='{newValues.firstName}', " +
    $"last_name='{newValues.LastName}'," +
    $"subject='{newValues.Subject}'," +
    $"salary={newValues.Salary}" +
    $" WHERE id = {id}";

await cmd.ExecuteNonQueryAsync();
*/
int id = 1;

cmd.CommandText = $"DELETE FROM teachers WHERE id = {id}";
await cmd.ExecuteNonQueryAsync();