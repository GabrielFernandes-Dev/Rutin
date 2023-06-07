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
    static SQLiteAsyncConnection dataBase;
    static async Task Init()
    {
        if(dataBase != null)
        {
            return;
        }
        var dataBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");
        dataBase = new SQLiteAsyncConnection(dataBasePath);
        await dataBase.CreateTableAsync<UsuarioModel>();
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
        int id = await dataBase.InsertAsync(usuario);
    }

    public static async Task<IEnumerable<UsuarioModel>> Acessar()
    {
        await Init();
        var usuario = await dataBase.Table<UsuarioModel>().ToListAsync();
        return usuario;
    }

    public static async Task Excluir(int id)
    {
        await Init();
        await dataBase.DeleteAsync<UsuarioModel>(id);
    }

}
