using Models.TbModels;
using SQLite;

namespace Services;

public static class AtividadeService
{
    static SQLiteAsyncConnection db;
    static async Task Init()
    {
        if(db != null)
            return;

        var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RutinData.db");

        db = new SQLiteAsyncConnection(databasePath);
        await db.CreateTableAsync<AtividadeModel>();
    }

    public static async Task AddAtividade(string nome, TimeSpan hrinicial, TimeSpan hrfinal, string notificacao, string descricao)
    {
        await Init();
        AtividadeModel atividade = new AtividadeModel()
        { 
            Nome = nome,
            HorarioInicio = hrinicial,
            HorarioFinal = hrfinal,
            TipoNotificacao = notificacao,
            Descricao = descricao
        };

        await db.InsertAsync(atividade);
    }

    public static async Task UpdateAtividade(int id, string nome, TimeSpan hrinicial, TimeSpan hrfinal, string notificacao, string descricao)
    {
        await Init();
        AtividadeModel atividade = new AtividadeModel()
        {
            Id = id,
            Nome = nome,
            HorarioInicio = hrinicial,
            HorarioFinal = hrfinal,
            TipoNotificacao = notificacao,
            Descricao = descricao
        };
        await db.UpdateAsync(atividade);
    }

    public static async Task<List<AtividadeModel>> GetAllAtividades()
    {
        await Init();
        return await db.Table<AtividadeModel>().ToListAsync();
    }

    public static async Task<AtividadeModel> GetAtividade(int id)
    {
        await Init();
        return await db.Table<AtividadeModel>().ElementAtAsync(id);
    }

    public static async Task RemoveAtividade(int id)
    {
        await Init();
        await db.DeleteAsync<AtividadeModel>(id);
    }
}
