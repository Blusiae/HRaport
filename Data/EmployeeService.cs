using HRaport.Models;
using SQLite;
namespace HRaport.Data;
public class EmployeeService(string dbPath)
{
    string _dbPath = dbPath;
    public string StatusMessage { get; set; }
    private SQLiteAsyncConnection _conn;

    private async Task InitAsync()
    {
        // Nie tworz bazy danych jesli juz istnieje
        if (_conn != null)
            return;
        // Utworz baze danych i tabele "Employee" w lokalizacji _dbPath
        _conn = new SQLiteAsyncConnection(_dbPath);
        await _conn.CreateTableAsync<Employee>();
    }

    public async Task<bool> CheckIfExistsAsync()
    {
        await InitAsync();

        // Mozliwosc korzystania z bazy danych chcemy wyswietlic uzytkownikowi, jezeli w bazie danych sa jakies elementy
        return await _conn.Table<Employee>().CountAsync() > 0;
    }

    public async Task ClearDatabase()
    {
        await _conn.DeleteAllAsync<Employee>();
    }

    public async Task<List<Employee>> GetAllAsync()
    {
        return await _conn.Table<Employee>().ToListAsync();
    }
    public async Task<bool> CreateAsync(
        Employee employee)
    {
        return await _conn.InsertAsync(employee) > 0; // Zwraca informacje, czy dodawanie do bazy danych sie powiodlo
    }
    public async Task<bool> UpdateAsync(
        Employee employee)
    {
        return await _conn.UpdateAsync(employee) > 0; // Zwraca informacje, czy edytowanie encji sie powiodlo
    }
    public async Task<bool> DeleteAsync(
        Employee employee)
    {
        return await _conn.DeleteAsync(employee) > 0; // Zwraca informacje, czy usuwanie z bazy danych sie powiodlo
    }
}