using SQLite;

namespace Models.TbModels;

[Table("tbatividade")]
public class AtividadeModel
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }
    [Column("nome")]
    public string Nome { get; set; }
    [Column("hrinicio")]
    public DateTime HorarioInicio { get; set; }
    [Column("hrfinal")]
    public DateTime HorarioFinal { get; set; }
    [Column("notificacao")]
    public string TipoNotificacao { get; set; }
    [Column("descricao")]
    public string Descricao { get; set; }
}
