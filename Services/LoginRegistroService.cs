using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.TbModels;
using SQLite;
namespace Services;

public static class LoginRegistroService
{
    static SQLiteAsyncConnection db;
    static async Task Init()
    {
        if(db != null)
            return;

        var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RutinData.db");

        bool isDatabaseCreated = File.Exists(databasePath);

        db = new SQLiteAsyncConnection(databasePath);
        await db.CreateTableAsync<UsuarioModel>();
    }

    public static async Task Registrar(String nome, String cpf, String email, String senha)
    {
        await Init();
        var usuario = new UsuarioModel
        {
            Nome = nome,
            Cpf = cpf,
            Email = email,
            Senha = senha
        };
        int id = await db.InsertAsync(usuario);
    }

    public static async Task<IEnumerable<UsuarioModel>> Acessar()
    {
        await Init();
        var usuario = await db.Table<UsuarioModel>().ToListAsync();
        return usuario;
    }

    public static async Task Excluir(int id)
    {
        await Init();
        await db.DeleteAsync<UsuarioModel>(id);
    }

    public static async Task<bool> ValidarUsuario(string email, string senha)
    {
        await Init();
        try
        {
            var usuario = await db.Table<UsuarioModel>().Where(x => x.Email == email).FirstOrDefaultAsync();
            return usuario.Senha == senha;
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
            return false;
        }
    }

}
